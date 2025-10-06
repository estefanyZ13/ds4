using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_9_4
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

        
        public void MostrarArreglo(int[] arreglo)
        {
            Console.Write("[] ");
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
