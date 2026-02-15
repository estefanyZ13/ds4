using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_9_2
{
    internal class Cargar
    {
        private int[] numero;

        public void Operacion()
        {
            numero = new int[100];
            for (int f = 0; f < 100; f++)
            {
                numero[f] = f + 1;
            }

            int contador = 0;
            for (int f = 0; f < 100; f++)
            {

                if (numero[f] % 2 == 0 || numero[f] % 3 == 0)
                {
                    contador = contador + 1;
                    Console.WriteLine($"{numero[f]}");


                }
            }
            Console.WriteLine($"\n\nTotal: {contador} números");




        }
    }
}
