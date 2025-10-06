using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_9_5
{
    internal class Aleatorios
    {
        private Random random;

        public Aleatorios()
        {
            random = new Random();
        }

        public int GenerarNumero(int num1, int num2)
        {
            return random.Next(num1, num2 + 1);
        }

        public int[] GenerarArreglo(int num1, int num2, int tamaño)
        {
            int[] arreglo = new int[tamaño];
            for (int i = 0; i < tamaño; i++)
            {
                arreglo[i] = random.Next(num1, num2 + 1);
            }
            return arreglo;
        }

        public int[] GenerarArregloSinRepetir(int num1, int num2, int tamaño)
        {
            int cantidadPosible = num2 - num1 + 1;

            if (tamaño > cantidadPosible)
            {
                Console.WriteLine($"Error: No se pueden generar {tamaño} números únicos entre {num1} y {num2}");
                Console.WriteLine($"Máximo posible: {cantidadPosible} números");
                return new int[0];
            }

            int[] arreglo = new int[tamaño];
            int contador = 0;

            while (contador < tamaño)
            {
                int numeroAleatorio = random.Next(num1, num2 + 1);

                bool existe = false;
                for (int i = 0; i < contador; i++)
                {
                    if (arreglo[i] == numeroAleatorio)
                    {
                        existe = true;
                        break;
                    }
                }

                if (!existe)
                {
                    arreglo[contador] = numeroAleatorio;
                    contador++;
                }
            }

            return arreglo;
        }

        public void MostrarArreglo(int[] arreglo)
        {
            Console.Write("[ ");
            for (int i = 0; i < arreglo.Length; i++)
            {
                Console.Write(arreglo[i]);
                if (i < arreglo.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(" ]");
        }
    }
}
