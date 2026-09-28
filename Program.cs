using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caso_semana7
{
    internal class Program
    {
        static int max = 100;
        static String[] nombres = new String[max];
        static double[] notas = new double[max];
        static int contador = 0;
        static public void Titulo()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Sistema de Notas");
            Console.WriteLine("-------------------------------------------------");
        }
        static public void registrar_estudiante()
        {
            Console.WriteLine("Registro del estudiante nuevo: ");
            if (contador >= max)
            {
                Console.WriteLine("No se pueden registrar más estudiantes[max:100].");
                return;
            }
            Console.Write("Ingresar nombres: ");
            string nombre = Console.ReadLine();
            double nota;
            while (true)
            {
                Console.Write("Ingresar la nota: ");
                nota = double.Parse(Console.ReadLine());
                if (nota >= 0 && nota <= 20)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Nota inválida. Debe ser un número entre 0 y 20.");
                }
            }
            nombres[contador] = nombre;
            notas[contador] = nota;
            contador++;
            Console.WriteLine("Estudiante registrado correctamente.");
        }
        static public void mostrar_lista()
        {
            Console.WriteLine("*********Lista de estudiantes registrados**********");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine((i + 1) + ".-" + nombres[i] + ".-Nota: " + notas[i]);
            }
        }
        static void Main(string[] args)
        {
            Titulo();
            int opc=0;
            while (opc != 6)
            {
                Console.WriteLine("-------------------------Menu Principal------------------------");
                Console.WriteLine("1.- Registrar estudiante");
                Console.WriteLine("2.- buscar estudiantes");
                Console.WriteLine("3.- Modificar nota");
                Console.WriteLine("4.- Mostrar lista sin ordenar");
                Console.WriteLine("5.- Mostrar reporte ordenado por burbuja");
                Console.WriteLine("6.- Salir");
                Console.Write("Ingrese una opción: ");
                opc = int.Parse(Console.ReadLine());
                if(opc < 1 || opc > 6)
                {
                    Console.WriteLine("Opción Fuera de rango. Intente nuevamente[1-6].");
                    continue;
                }
                switch (opc)
                {
                    case 1:
                        registrar_estudiante();
                        break;
                    case 2:
                        //buscar_estudiante();
                        break;
                    case 3:
                        //modificar_nota();
                        break;
                    case 4:
                        mostrar_lista();
                        break;
                    case 5:
                        //burbuja();
                        break;
                    case 6: 
                        Console.WriteLine("Saliendo del programa... Gracias por usar el sistema");
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta...!!!");
                        break;
                }
            }
        }
    }
}