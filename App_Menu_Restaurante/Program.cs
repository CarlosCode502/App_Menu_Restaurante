using System;
using System.Collections.Generic;
using System.Linq;

namespace App_Menu_Restaurante
{
    class Program
    {
        //CREAR UN PROGRAMA QUE CONTENGA UN MENU DE OPCIONES PARA (DESAYUNO, ALMUERZO Y CENA)
        //EL PROGRAMA DEBE DESPLEGAR POR LO MENOS OTRAS 3 OPCIONES PARA CADA OPCIÓN PRINCIPAL

        //IMPORTANTE EL MENU DEBERA MOSTRAR LA HORA y FECHA DEL SISTEMA

        /// <summary>
        /// variables globales
        /// </summary>
        private static String fecha;
        private static String hora;
        private static String teclado;
        private static String txt_MenuStd;
        private static String elegir;
        private static String confirmar;
        //private static String contra;
        //private static String op_nueva;
        private static String[] arr_Desayuno = { "A. Huevos y jugo de naranja.", "B. Panqueques y café.", "C. Pan y café." };
        private static String[] arr_Almuerzo = { "A. Caldo de res y fresco de frutas.", "B. Churrasco y gaseosa", "C. Pollo frito y gaseosa"};
        private static String[] arr_Cena = { "A. Panes con carne y gaseosa", "B. Pollo frito y café"};
        private static String[] arr_TipoComida;
        private static List<String> facturas_Comidas = new List<string>();
        //private static String[] facturas_comidas = { };

        private static Decimal[] arr_Des_Precios = { 12.50M, 14.10M, 8.99M };
        private static Decimal[] arr_Alm_Precios = { 22.50M, 28.60M, 19.99M };
        private static Decimal[] arr_Cen_Precios = { 17.15M, 16.30M };
        private static List<Decimal> facturas_Total = new List<Decimal>();
        private static Decimal[] arr_TipoComida_Precio;
        private static Decimal suma_Total;
        //private static Decimal op_nueva_Precios;
        //private static Decimal[] facturas_total = { };

        

        private static int opcion = 1;//se usara para detener el ciclo repetitivo
        private static int op_Switch = 1;//mientras se siga cumpliendo la ejecución se seguira repitiendo
        private static int aum_pc;

        /// <summary>
        /// Contiene la altura original y la nueva
        /// </summary>
        //private static int origWidth, width;
        /// <summary>
        /// Contiene el alto original y el nuevo
        /// </summary>
        //private static int origHeight, height;


        /// <summary>
        /// Fragmento de código que mostrara el título.
        /// </summary>
        private static void Cabecera()
        {
            //fecha = "martes, 25 de julio de 2023";
            fecha = DateTime.Today.ToString("D");
            hora = DateTime.Now.ToString("HH:mm:ss");

            //Fragmento de código que representa un encabezado
            Console.Title = "RESTAURANTE EL CÓDIGO VENADO";
            Console.WriteLine("\n\t     " + fecha + "\t\t\t" + hora);
            Console.WriteLine("\n\t#############################################################");
            Console.WriteLine("\n\t\t\t\tMENÚ DE OPCIONES\n");
            Console.WriteLine("\t#############################################################\n");
                                 
        }

        /// <summary>
        /// Desplegara las opciones disponibles para ordenar,
        /// además recibe la opción que elije el usuario
        /// </summary>
        private static void OpcionesMenu()
        {
            //mostrara las opciones disponibles
            Console.WriteLine("1. Desayuno.\n2. Almuerzo.\n3. Cena.\n0. Salir."
                + "\n\nElija la opción de lo que desea ordenar:");

            teclado = Console.ReadLine();//recibira la opción que elija el usuario

            Console.WriteLine("\n\n\t");//espacio en pantalla
        }

        /// <summary>
        /// Evita crear una función para cada opción del menú se realiza la operación
        /// y en base a esta se asignan y reemplazan los valores correspondientes
        /// </summary>
        private static void MenuStandard()
        {
            Console.WriteLine(txt_MenuStd);
            for(int i = 0; i < arr_TipoComida.Length; i++)
            {
                Console.WriteLine(arr_TipoComida[i] + " = Q " + arr_TipoComida_Precio[i]);
            }

            Console.WriteLine("\n0. Volver al menú anterior.");
        }

        ///// <summary>
        ///// Funcion que desplegara la opción DESAYUNOS elegida:
        ///// </summary>
        //private static void MenuDesayuno()
        //{
        //    Console.WriteLine("MENÚ DESAYUNO:");

        //    //recorrera los arreglos Desayunos "= Q" Precios, esto en base a la longitud del arr_Desayuno
        //    for(int i = 0; i < arr_Desayuno.Length; i++)
        //    {
        //        Console.WriteLine(arr_Desayuno[i] + " = Q " + arr_Des_Precios[i]);
        //    }

        //    Console.WriteLine("\n+. Agregar otra opción.");
        //    Console.WriteLine("0. Volver al menú anterior.");
        //}

        ///// <summary>
        ///// Desplegara el menú Almuerzo seleccionado
        ///// </summary>
        //private static void MenuAlmuerzo()
        //{
        //    Console.WriteLine("MENÚ ALMUERZO:");

        //    for (int i = 0; i < arr_Almuerzo.Length; i++)
        //    {
        //        Console.WriteLine(arr_Almuerzo[i] + " = Q " +arr_Alm_Precios[i]);
        //    }

        //    Console.WriteLine("\n0. Volver al menú anterior.");
        //}

        ///// <summary>
        ///// Desplegará el menú cena seleccionado 
        ///// </summary>
        //private static void MenuCena()
        //{
        //    Console.WriteLine("MENÚ CENA:");

        //    for (int i = 0; i < arr_Cena.Length; i++)
        //    {
        //        Console.WriteLine(arr_Cena[i] + " = Q " +arr_Cen_Precios[i]);
        //    }

        //    Console.WriteLine("\n0. Volver al menú anterior.");
        //}


        /// <summary>
        ///Desplega el resultado en base a la opcción elegida por el usuario, 
        ///luego realiza una serie de pasos que son: mostrar la orden realizada,
        ///factura actual(productos y precios), suma de totales(con formato).
        ///Por último lanza una opción al usuario para saber si desea realizar 
        ///otra orden o finalizar con el programa
        /// </summary>
        private static void BuscarCoicidencia()
        {
            Console.Clear();
            Console.WriteLine("!LISTO!\nUsted ordeno:\n\n"
                + arr_TipoComida[int.Parse(teclado)-aum_pc]
                + "\nEl costo es: " + arr_TipoComida_Precio[int.Parse(teclado)-aum_pc]);

            //agrega la opción elegida para poder generar una factura de compra
            //que incluye la orden y el total de compra y la suma total de compra
            //PROCESO USANDO LISTAS
            System.Threading.Thread.Sleep(500);
            facturas_Comidas.Add(arr_TipoComida[int.Parse(teclado)-aum_pc]);
            facturas_Total.Add(arr_TipoComida_Precio[int.Parse(teclado)-aum_pc]);

            Console.WriteLine("\nFACTURA ACTUAL:");
            for (int i = 0; i < facturas_Comidas.Count; i++)
            {
                Console.WriteLine(facturas_Comidas[i] + " = " + facturas_Total[i]);
                suma_Total = facturas_Total.Sum();
            }

            //Formato y formateo de texto
            Console.WriteLine($"{suma_Total.ToString("Q 0,0.00")}");

            ////USANDO ARREGLOS
            //facturas_comidas.Append(arr_Desyuno[int.Parse(teclado) - 1]);
            //facturas_total.Append(arr_Des_Precios[int.Parse(teclado) - 1]);

            System.Threading.Thread.Sleep(500);
            Console.WriteLine("\n¿Desea volver a ordenar?");
            confirmar = Console.ReadLine();

            String[] igual = { "S", "s", "1", "Si" };

            int indice = Array.IndexOf(igual, confirmar);
            if (indice == -1)
            {
                //return;
                //Se utiliza para cerrar o salir del programa de un solo golpe sin tanto rollo

                //opcion = 0;
                op_Switch = 0;
                Console.Clear();
                Console.Write("Adiós...");
                Environment.Exit(0);//cerrar el programa de forma más genial
            }
            else
            {
                op_Switch = 1;
            }
        }

        //private static void AdminAgregar()
        //{
        //    Console.Clear();
        //    Console.WriteLine("Ingrese la contraseña:");
        //    contra = Console.ReadLine();

        //    if(contra == "1234")
        //    {
        //        Console.WriteLine("Ingrese la nueva opción:");
        //        op_nueva = Console.ReadLine();

        //        Console.WriteLine("Ingrese el precio:");
        //        op_nueva_Precios = Convert.ToDecimal(Console.ReadLine());

        //    }

        //}

        /// <summary>
        /// Función que se lanzara luego de que el usuario elija una opción erronea o que no corresponda 
        /// a ninguna opción existente
        /// </summary>
        private static void Op_Incorrecta()
        {
            Console.Clear();
            Console.WriteLine("Opción incorrecta, vuelva a elegir...");
            System.Threading.Thread.Sleep(500);
            Console.Clear();
        }


        /// <summary>
        /// Método main principal
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //origWidth = Console.WindowWidth; //obtiene el ancho actual de la ventana
            //origHeight = Console.WindowHeight; //obtiene el alto actual de la ventana

            ////Console.SetWindowPosition(star)

            //width = 80;
            //height = 18;

            //Console.SetWindowSize(width, height);
            //Console.SetCursorPosition(0,0);

            while (opcion == 1)
            {                
                Cabecera();
                OpcionesMenu();
                
                while (op_Switch == 1)
                {
                    //sentencia multiple que detectara si la entrada por el teclado corresponde a un "caso" existente
                    switch (teclado)
                    {
                        case "1":
                            Console.Clear();//borra la consola 

                            txt_MenuStd = "MENÚ DESAYUNO:";
                            arr_TipoComida = arr_Desayuno;
                            arr_TipoComida_Precio = arr_Des_Precios;

                            Cabecera();//cabecera                             
                            MenuStandard();//que corresponde a la opción 1 

                            //Console.WriteLine("0. Volver al menú anterior.");

                            //Msje y elección del usuario
                            Console.WriteLine("\nElija una opción:");
                            elegir = Console.ReadLine();
                            
                            //determina si el valor ingresado por el usuario coincide con alguna condicional
                            if (elegir == "A" || elegir == "a" || elegir == "A." || elegir == "a.")
                            {
                                aum_pc = 1;//corresponde a la variable teclado opc1-1
                                arr_TipoComida = arr_Desayuno;
                                arr_TipoComida_Precio = arr_Des_Precios;
                                BuscarCoicidencia();
                            }
                            else if (elegir == "B" || elegir == "b" || elegir == "B." || elegir == "b.")
                            {
                                aum_pc = 0;//corresponde a la variable teclado opc1 - 0
                                arr_TipoComida = arr_Desayuno;
                                arr_TipoComida_Precio = arr_Des_Precios;
                                BuscarCoicidencia();                                
                            }
                            else if (elegir == "C" || elegir == "c" || elegir == "C." || elegir == "c.")
                            {
                                aum_pc = -1;//corresponde a la variable teclado opc1 -1
                                arr_TipoComida = arr_Desayuno;
                                arr_TipoComida_Precio = arr_Des_Precios;
                                BuscarCoicidencia();
                            }
                            else if(elegir == "0")
                            {
                                Console.Clear();
                                Cabecera();
                                OpcionesMenu();
                            }
                            //else if(elegir == "+")
                            //{
                            //    Console.Clear();

                            //    AdminAgregar();

                            //    arr_Desayuno.Append()                                
                            //}
                            else
                            {
                                //si la opción elegida no coincide con ninguna, entonces el ciclo 
                                //repetitivo se volvera a ejecutar
                                Op_Incorrecta();
                                //opcion = 1;
                            }
                            break;

                        case "2":
                            Console.Clear();

                            txt_MenuStd = "MENÚ ALMUERZO:";
                            arr_TipoComida = arr_Almuerzo;
                            arr_TipoComida_Precio = arr_Alm_Precios;

                            Cabecera();
                            MenuStandard();

                            Console.WriteLine("\nElija una opción:");
                            elegir = Console.ReadLine();

                            if(elegir == "A" || elegir == "a" || elegir == "A." || elegir == "a.")
                            {
                                aum_pc = 2;//corresponde a la variable teclado opc2-2
                                arr_TipoComida = arr_Almuerzo;
                                arr_TipoComida_Precio = arr_Alm_Precios;
                                BuscarCoicidencia();
                            }
                            else if(elegir == "B" || elegir == "b" || elegir == "B." || elegir == "b.")
                            {
                                aum_pc = 1;//corresponde a la variable teclado opc2-1
                                arr_TipoComida = arr_Almuerzo;
                                arr_TipoComida_Precio = arr_Alm_Precios;
                                BuscarCoicidencia();
                            }
                            else if(elegir == "C" || elegir == "c" || elegir == "C." || elegir == "c.")
                            {
                                aum_pc = 0;//corresponde a la variable teclado opc2-0
                                arr_TipoComida = arr_Almuerzo;
                                arr_TipoComida_Precio = arr_Alm_Precios;
                                BuscarCoicidencia();
                            }
                            else if(elegir == "0")
                            {
                                Console.Clear();
                                Cabecera();
                                OpcionesMenu();
                            }
                            else
                            {
                                Op_Incorrecta();
                            }
                            break;

                        case "3":
                            Console.Clear();

                            txt_MenuStd = "MENÚ CENA:";
                            arr_TipoComida = arr_Cena;
                            arr_TipoComida_Precio = arr_Cen_Precios;

                            Cabecera();
                            MenuStandard();

                            Console.WriteLine("\nElija una opción:");
                            elegir = Console.ReadLine();

                            if(elegir == "A" || elegir == "a" || elegir == "A." || elegir == "a.")
                            {
                                aum_pc = 3;//corresponde a la variable teclado opc3-2
                                arr_TipoComida = arr_Cena;
                                arr_TipoComida_Precio = arr_Cen_Precios;
                                BuscarCoicidencia();
                            }
                            else if(elegir == "B" || elegir == "b" || elegir == "B." || elegir == "b.")
                            {
                                aum_pc = 2;//corresponde a la variable teclado opc3-1
                                arr_TipoComida = arr_Cena;
                                arr_TipoComida_Precio = arr_Cen_Precios;
                                BuscarCoicidencia();
                            }
                            else if(elegir == "C" || elegir == "c" || elegir == "C." || elegir == "c.")
                            {
                                aum_pc = 1;//corresponde a la variable teclado opc3-0
                                arr_TipoComida = arr_Cena;
                                arr_TipoComida_Precio = arr_Cen_Precios;
                                BuscarCoicidencia();
                            }
                            else if(elegir == "0")
                            {
                                Console.Clear();
                                Cabecera();
                                OpcionesMenu();
                            }
                            else
                            {
                                Op_Incorrecta();                                
                            }
                            break;

                        case "0":
                            Environment.Exit(0);
                            break;

                        default:
                            Op_Incorrecta();
                            //opcion = 1;
                            Cabecera();
                            OpcionesMenu();
                            break;
                    }
                    opcion = 0;
                }                
            }
            Console.ReadLine();
        }
    }
}