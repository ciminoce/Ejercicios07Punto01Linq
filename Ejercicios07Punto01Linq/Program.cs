using System;
using System.Linq;
using ConsoleTables;

namespace Ejercicios07Punto01Linq
{
    class Program
    {
        static void Main()
        {
            double[] tempSemana = new[] { 14.5, 10.7, 8.7, 10, 12, 14, 18 };//se define e inicializa el vector
            //double[]tempSemana=new double[7];
            do
            {
                #region Menu Principal

                int intOpcion;
                Console.Clear();//Limpia la pantalla
                Console.WriteLine("Menú Principal");
                Console.WriteLine("0 - Salir");
                Console.WriteLine("1 - Ingresar Datos");
                Console.WriteLine("2 - Modificar Datos x Indice");
                Console.WriteLine("3 - Modificar Datos x Contenido");
                Console.WriteLine("4 - Listar Datos");
                Console.WriteLine("5 - Estadísticas de Datos");
                Console.WriteLine("6 - Listado Estadístico");
                Console.WriteLine("7 - Filtrar Datos");
                Console.WriteLine("8 - Ordenar Datos");
                Console.WriteLine("9 - Mostrar Temperaturas Superiores al Promedio");
                Console.WriteLine("10 - Reiniciar");
                Console.WriteLine();
                do
                {
                    Console.Write("Ingrese una opción del menú:");
                    if (!int.TryParse(Console.ReadLine(), out intOpcion))
                    {
                        Console.WriteLine("Opción mal ingresada");
                    }
                    else
                    {
                        break;//me saca del ciclo
                    }

                } while (true);
                #endregion

                #region Opcion Elegida

                string opcionElegida;
                switch (intOpcion)
                {
                    case 0://Salir del Programa
                        Environment.Exit(0);
                        break;
                    case 1://Ingresar datos
                        opcionElegida = "Ingreso de datos";
                        IngresarDatos(opcionElegida, tempSemana);
                        break;
                    case 2://Modificar datos
                        opcionElegida = "Modificación de Datos";
                        ModificarDatos(opcionElegida, tempSemana);
                        break;
                    case 3://Modifcar datos por contenido
                        opcionElegida = "Modificar datos por Contenido";
                        ModificarDatosPorContenido(opcionElegida, tempSemana);
                        break;
                    case 4://Listar Datos
                        opcionElegida = "Listado de Datos";
                        ListarDatos(opcionElegida, tempSemana);
                        break;
                    case 5://Estadisticas
                        opcionElegida = "Estadísticas";
                        Estadisticas(opcionElegida, tempSemana);
                        break;
                    case 6://Listado Estadístico
                        opcionElegida = "Listado Estadístico";
                        ListaEstadistico(opcionElegida, tempSemana);
                        break;
                    case 7://Filtrar Vector
                        opcionElegida = "Filtrar Datos";
                        FiltrarDatos(opcionElegida, tempSemana);
                        break;
                    case 8://Ordenar Vector
                        opcionElegida = "Ordenar Vector";
                        OrdenarVector(opcionElegida, tempSemana);
                        break;
                    case 9://Mostrar temp sup al promedio
                        opcionElegida = "Listado de Temperaturas Superiores al Promedio";
                        ListadoTemperaturasSuperioresPromedio(opcionElegida, tempSemana);
                        break;
                    case 10://Reiniciar Vector
                        opcionElegida = "Reinicio";
                        ReinicioDelVector(opcionElegida, tempSemana);
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }

                #endregion

            } while (true);

        }

        private static void ListadoTemperaturasSuperioresPromedio(string opcionElegida, double[] tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            var vectorFiltrado = tempSemana.Where(t => t > tempSemana.Average());
            ConsoleTable tabla;
            tabla = new ConsoleTable("Temperatura");
            foreach (var tempFiltrada in vectorFiltrado)
            {
                tabla.AddRow(tempFiltrada);
            }

            tabla.Write(); //Muestra la tabla en consola

            SalidaDelMetodo(opcionElegida);

        }

        private static void FiltrarDatos(string opcionElegida, double[] tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            Console.Write("Ingrese una temperatura para filtrar el vector:");
            var iFiltrar = int.Parse(Console.ReadLine());
            var vectorFiltrado = tempSemana.Where(t => t > iFiltrar);
            ConsoleTable tabla;
            tabla = new ConsoleTable("Temperatura");
            foreach (var tempFiltrada in vectorFiltrado)
            {
                tabla.AddRow(tempFiltrada);
            }

            tabla.Write(); //Muestra la tabla en consola

            SalidaDelMetodo(opcionElegida);

        }

        private static void ReinicioDelVector(string opcionElegida, double[] tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            string respuesta;
            do
            {
                Console.Write("¿Desea borrar todos los datos del vector?(S/N):");
                respuesta = Console.ReadLine();
                if (respuesta.ToUpper() != "S" && respuesta.ToUpper() != "N")
                {
                    Console.WriteLine("Debe ingresar S o N... pruebe otra vez");
                }
                else
                {
                    break;
                }

            } while (true);

            if (respuesta.ToUpper() == "S")
            {
                Array.Clear(tempSemana, 0, tempSemana.Length);
            }
        }

        private static void OrdenarVector(string opcionElegida, double[] tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            OrdenamientoDelVector(tempSemana);
            MostrarDatosEnTabla(tempSemana, false);
            SalidaDelMetodo(opcionElegida);
        }

        private static void OrdenamientoDelVector(double[] tempSemana)
        {
            /*ciclo para ir moviendo la posicion que se ordena
             siempre arranca de la primera posicion esto es 0 y 
            llega hasta la anteúltima */
            //for (int posicionOrdenar = 0; posicionOrdenar < tempSemana.Length - 1; posicionOrdenar++)
            //{
            //    /*ciclo para ir moviendo la posicion contra la cual voy comparando
            //     siempre arranca desde la posicion que estoy ordenando +1
            //    y llega hasta el final del vector */
            //    for (int posicionComparar = posicionOrdenar + 1; posicionComparar < tempSemana.Length; posicionComparar++)
            //    {
            //        if (tempSemana[posicionOrdenar] > tempSemana[posicionComparar])
            //        {
            //            var auxiliar = tempSemana[posicionOrdenar]; //reservo el valor de la posicion que comparo
            //            tempSemana[posicionOrdenar] = tempSemana[posicionComparar];
            //            tempSemana[posicionComparar] = auxiliar;
            //        }
            //    }
            //}
            Array.Sort(tempSemana);
        }

        private static void ListaEstadistico(string opcionElegida, double[] tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            double promedio = CalcularPromedio(tempSemana);
            MostrarDatosEnTabla(tempSemana, promedio);
            SalidaDelMetodo(opcionElegida);
        }

        private static void Estadisticas(string opcionElegida, double[] tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            MostrarDatosEnTabla(tempSemana, false);
            var mayorTemperatura = HallarMayorTemperatura(tempSemana);
            var menorTemperatura = HallarMenorTemperatura(tempSemana);
            var promedioTemperaturas = CalcularPromedio(tempSemana);
            Console.WriteLine($"Mayor Temperatura:{mayorTemperatura}");
            Console.WriteLine($"Menor Temperatura:{menorTemperatura}");
            Console.WriteLine($"Promedio:{promedioTemperaturas:N2}");
            SalidaDelMetodo(opcionElegida);
        }

        private static double CalcularPromedio(double[] tempSemana)
        {
            //double promedio = 0;
            //foreach (var temperatura in tempSemana)
            //{
            //    promedio += temperatura;
            //}

            //promedio /= tempSemana.Length;
            //return promedio;
            return tempSemana.Average();
        }

        private static double HallarMenorTemperatura(double[] tempSemana)
        {
            //double menorTemperatura = 25;
            //foreach (var temperatura in tempSemana)
            //{
            //    if (temperatura < menorTemperatura)
            //    {
            //        menorTemperatura = temperatura;
            //    }
            //}

            //return menorTemperatura;
            return tempSemana.Min();
        }

        private static double HallarMayorTemperatura(double[] tempSemana)
        {
            //double mayorTemperatura = -11;
            //foreach (var temperatura in tempSemana)
            //{
            //    if (temperatura > mayorTemperatura)
            //    {
            //        mayorTemperatura = temperatura;
            //    }
            //}

            //return mayorTemperatura;
            return tempSemana.Max();
        }

        private static void ModificarDatosPorContenido(string opcionElegida, double[] tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            MostrarDatosEnTabla(tempSemana, false);
            Console.Write("Ingrese el valor a modificar:");
            var elementoModificar = double.Parse(Console.ReadLine());
            /*El metodo IndexOf me devuelve el indice del elemento a modificar
             de acuerdo con el vector que le pase en el primer argumento*/
            var intIndex = Array.IndexOf(tempSemana, elementoModificar);
            if (intIndex >= 0)
            {
                Console.WriteLine($"El valor {elementoModificar} se encuentra en la posición {intIndex} del vector");
                Console.Write("Ingrese un nuevo contenido:");
                tempSemana[intIndex] = double.Parse(Console.ReadLine());

            }
            else
            {
                Console.WriteLine($"El elemento {elementoModificar} no se encuentra en el vector");
            }
            SalidaDelMetodo(opcionElegida);
        }

        private static void ListarDatos(string opcionElegida, double[] tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            MostrarDatosEnTabla(tempSemana, true);
            SalidaDelMetodo(opcionElegida);
        }

        private static void MostrarDatosEnTabla(double[] tempSemana, double promedio)
        {
            Console.WriteLine($"El promedio de temperaturas es {promedio}");
            ConsoleTable tabla = new ConsoleTable("Día Nro", "Temperatura", "Mayor a Promedio");
            for (int i = 0; i < tempSemana.Length; i++)
            {
                if (tempSemana[i] > promedio)
                {
                    tabla.AddRow(i+1, tempSemana[i], "*");
                }
                else
                {
                    tabla.AddRow(i+1, tempSemana[i], string.Empty);
                }
            }
            tabla.Write();
        }
        private static void MostrarDatosEnTabla(double[] tempSemana, bool mostrarFahrenheit)
        {
            ConsoleTable tabla;
            if (mostrarFahrenheit)
            {
                tabla = new ConsoleTable("Día Nro", "Temperatura", "Fahrenheit"); //Crea una tabla en consola

            }
            else
            {
                tabla = new ConsoleTable("Día Nro", "Temperatura");
            }
            for (int i = 0; i < tempSemana.Length; i++)
            {
                //Console.WriteLine($"{tempSemana[i]}");
                if (mostrarFahrenheit)
                {
                    var fahrenheit = ConvertirFahrenheit(tempSemana[i]);
                    tabla.AddRow(i + 1, tempSemana[i], fahrenheit); //Agrega una fila a la tabla en consola
                }
                else
                {
                    tabla.AddRow(i + 1, tempSemana[i]); //Agrega una fila a la tabla en consola
                }
            }

            tabla.Write(); //Muestra la tabla en consola
        }

        private static double ConvertirFahrenheit(double celsius)
        {
            return celsius * 1.8 + 32;
        }

        private static void IngresoAlMetodo(string opcionElegida)
        {
            Console.Clear();
            Console.WriteLine($"{opcionElegida}");
        }

        private static void ModificarDatos(string opcionElegida, double[] tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            MostrarDatosEnTabla(tempSemana, false);
            var intIndex = 0;
            do
            {
                Console.Write("Ingrese el nro. de elemento a modificar:");
                if (!int.TryParse(Console.ReadLine(), out intIndex))
                {
                    Console.WriteLine("Indice mal ingresado");
                }
                else if (intIndex < 0 || intIndex > tempSemana.Length - 1)//me fijo que esté entre 0 y la cantidad de elementos menos 1
                {
                    Console.WriteLine("Indice fuera del rango permitido");
                }
                else
                {
                    break;
                }

            } while (true);
            Console.WriteLine($"El elemento {intIndex} del vector es {tempSemana[intIndex]}");
            Console.Write("Ingrese la nueva temperatura:");
            tempSemana[intIndex] = double.Parse(Console.ReadLine());
            SalidaDelMetodo(opcionElegida);

        }

        private static void IngresarDatos(string opcionElegida, double[] tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            for (int i = 0; i < tempSemana.Length; i++)
            {
                do
                {
                    Console.Write($"Ingrese la temperatura {i + 1}:");
                    if (!double.TryParse(Console.ReadLine(), out tempSemana[i]))
                    {
                        Console.WriteLine("Temperatura mal ingresada");
                    }
                    else if (tempSemana[i] < -10 || tempSemana[i] > 24)
                    {
                        Console.WriteLine("Temperatura fuera del rango permitido");
                    }
                    else
                    {
                        break;
                    }

                } while (true);
            }
            SalidaDelMetodo(opcionElegida);
        }

        private static void SalidaDelMetodo(string opcionElegida)
        {
            Console.WriteLine($"Fin de {opcionElegida}... Tecla para continuar");
            Console.ReadLine();
        }
    }
}

