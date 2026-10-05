using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        static public void buscar_estudiante()
        {
            Console.WriteLine("*********Buscar estudiante**********");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }
            Console.Write("Ingrese el nombre del estudiante a buscar: ");
            string nom_buscar = Console.ReadLine();
            bool encontrado = false;
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine(nombres[i] + ".-Nota: " + notas[i]);
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Estudiante no encontrado.");
            }
        }
        static public void modificar_nota()
        {
            Console.WriteLine("*********Modificar nota de estudiante**********");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }
            Console.Write("Ingrese el nombre del estudiante a modificar: ");
            string nombre_buscar = Console.ReadLine().ToLower();
            bool encontrado = false;
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nombre_buscar)
                {
                    Console.WriteLine(nombres[i] + ".-Nota actual: " + notas[i]);
                    double nueva_nota;
                    while (true)
                    {
                        Console.Write("Ingrese la nueva nota: ");
                        nueva_nota = double.Parse(Console.ReadLine());
                        if (nueva_nota >= 0 && nueva_nota <= 20)
                        {
                            notas[i] = nueva_nota;
                            Console.WriteLine("Nota modificada correctamente.");
                            break;
                        }
                        Console.WriteLine("Error: Nota no valida.");
                    }
                }
            }
            if (!encontrado)
                Console.WriteLine("Estudiante no encontrado.");
        }
        static public void burbuja()
        {
            double tempNota;
            string tempNombre;
            for (int i = 0; i < contador - 1; i++)
            {
                for (int j = 0; j < contador - i - 1; j++)
                {
                    if (notas[j] > notas[j + 1])
                    {
                        tempNota = notas[j];
                        notas[j] = notas[j + 1];
                        notas[j + 1] = tempNota;
                        

                        tempNombre = nombres[j];
                        nombres[j] = nombres[j + 1];
                        nombres[j + 1] = tempNombre;
                    }
                }
            }
        }

        static public void seleccion_desc()
        {
            for (int i = 0; i < contador - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < contador; j++)
                {
                    if (notas[j] > notas[maxIndex])
                    {
                        maxIndex = j;
                    }
                }
                if (maxIndex != i)
                {
                    double tempNota = notas[i];
                    string tempNombre = nombres[i];
                    notas[i] = notas[maxIndex];
                    nombres[i] = nombres[maxIndex];
                    notas[maxIndex] = tempNota;
                    nombres[maxIndex] = tempNombre;
                }
            }
        }

        static public void promedio_nota_maxima()
        {
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }
            double suma = 0;
            double notaMaxima = notas[0];
            for (int i = 0; i < contador; i++)
            {
                suma += notas[i];
                if (notas[i] > notaMaxima)
                {
                    notaMaxima = notas[i];
                }
            }
            double promedio = suma / contador;
            Console.WriteLine("Promedio de notas: " + promedio);
            Console.WriteLine("Nota máxima: " + notaMaxima);
        }
        static void Main(string[] args)
        {
            Titulo();
            int opc = 0;
            while (opc != 8)
            {
                Console.Clear();
                Console.WriteLine("-------------------------Menu Principal------------------------");
                Console.WriteLine("1.- Registrar estudiante");
                Console.WriteLine("2.- buscar estudiantes");
                Console.WriteLine("3.- Modificar nota");
                Console.WriteLine("4.- Mostrar lista sin ordenar");
                Console.WriteLine("5.- Mostrar reporte ordenado por burbuja");
                Console.WriteLine("6.- Mostrar por seleccion DESC");
                Console.WriteLine("7.- Promedio y nota maxima");
                Console.WriteLine("8.- Salir");
                Console.Write("Ingrese una opción: ");
                if(!int.TryParse(Console.ReadLine(), out opc))
                {
                    Console.WriteLine("*******************************************************");
                    Console.WriteLine("Error: Ingresar valor numerico.");
                    Console.WriteLine("*******************************************************");
                    continue;
                }
                if (opc < 1 || opc > 8)
                {
                    Console.WriteLine("*******************************************************");
                    Console.WriteLine("Opción Fuera de rango. Intente nuevamente[1-8].");
                    Console.WriteLine("*******************************************************");
                    continue;
                }
                switch (opc)
                {

                    case 1:
                        registrar_estudiante();
                        break;
                    case 2:
                        buscar_estudiante();
                        break;
                    case 3:
                        modificar_nota();
                        break;
                    case 4:
                        mostrar_lista();
                        break;
                    case 5:
                        burbuja();
                        break;
                    case 6:
                        seleccion_desc();
                        break;
                    case 7: 
                        promedio_nota_maxima();
                        break;
                    case 8:
                        Console.WriteLine("Saliendo del programa... Gracias por usar el sistema");
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta...!!!");
                        break;

                }
                Console.ReadKey();
            }
        }
    }
}
