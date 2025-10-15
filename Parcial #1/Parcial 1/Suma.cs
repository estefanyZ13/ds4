using System;
using System.Collections.Generic;

namespace Parcial_1
{
    internal class Aleatorios
    {
        private Random random;
        private int[,] arreglo;
        private int filas;
        private int columnas;
        private int numeroMin;
        private int numeroMax;

        public Aleatorios(int f, int c, int min, int max)
        {
            random = new Random();
            filas = f;
            columnas = c;
            numeroMin = min;
            numeroMax = max;

            if (filas <= 0 || columnas <= 0)
            {
                Console.WriteLine("Error: Las filas y columnas deben ser mayores a 0");
                filas = 1;
                columnas = 1;
            }

            if (min > max)
            {
                Console.WriteLine("Error: El mínimo no puede ser mayor que el máximo");
                int temp = min;
                min = max;
                max = temp;
            }

            arreglo = new int[filas, columnas];
        }

        public void MatrizAleatoria()
        {
            for (int f = 0; f < filas; f++)
            {
                for (int c = 0; c < columnas; c++)
                {
                    arreglo[f, c] = random.Next(numeroMin, numeroMax + 1);
                }
            }
        }

        public void MatrizDiagonalYEsquinas()
        {
            // Inicializar toda la matriz en 0
            for (int f = 0; f < filas; f++)
            {
                for (int c = 0; c < columnas; c++)
                {
                    arreglo[f, c] = 0;
                }
            }

            // Generar números aleatorios en la diagonal principal y bloques de esquinas 2x2
            for (int f = 0; f < filas; f++)
            {
                for (int c = 0; c < columnas; c++)
                {
                    bool esDiagonalPrincipal = (f == c);

                    // Bloque superior izquierdo 2x2: (0,0), (0,1), (1,0), (1,1)
                    bool esEsquinaSuperiorIzq = (f >= 0 && f <= 1) && (c >= 0 && c <= 1);

                    // Bloque superior derecho 2x2: (0,columnas-2), (0,columnas-1), (1,columnas-2), (1,columnas-1)
                    bool esEsquinaSuperiorDer = (f >= 0 && f <= 1) && (c >= columnas - 2 && c <= columnas - 1);

                    // Bloque inferior izquierdo 2x2: (filas-2,0), (filas-2,1), (filas-1,0), (filas-1,1)
                    bool esEsquinaInferiorIzq = (f >= filas - 2 && f <= filas - 1) && (c >= 0 && c <= 1);

                    // Bloque inferior derecho 2x2: (filas-2,columnas-2), (filas-2,columnas-1), (filas-1,columnas-2), (filas-1,columnas-1)
                    bool esEsquinaInferiorDer = (f >= filas - 2 && f <= filas - 1) && (c >= columnas - 2 && c <= columnas - 1);

                    if (esDiagonalPrincipal || esEsquinaSuperiorIzq || esEsquinaSuperiorDer ||
                        esEsquinaInferiorIzq || esEsquinaInferiorDer)
                    {
                        arreglo[f, c] = random.Next(numeroMin, numeroMax + 1);
                    }
                }
            }
        }

        public void MostrarMatriz()
        {
            Console.WriteLine($"\nMatriz de números aleatorios ({filas}x{columnas}):");
            Console.WriteLine($"Rango: {numeroMin} - {numeroMax}");
            Console.WriteLine();

            for (int f = 0; f < filas; f++)
            {
                for (int c = 0; c < columnas; c++)
                {
                    Console.Write($"{arreglo[f, c],5} ");
                }
                Console.WriteLine();
            }
        }

        public void MostrarDiagonalYEsquinas()
        {
            Console.WriteLine($"\nMatriz con números en diagonal principal y esquinas ({filas}x{columnas}):");
            Console.WriteLine($"Rango: {numeroMin} - {numeroMax}");
            Console.WriteLine();

            for (int f = 0; f < filas; f++)
            {
                for (int c = 0; c < columnas; c++)
                {
                    if (arreglo[f, c] == 0)
                    {
                        Console.Write("   0 ");
                    }
                    else
                    {
                        Console.Write($"{arreglo[f, c],4} ");
                    }
                }
                Console.WriteLine();
            }
        }

        public int EncontrarPatronRepetido()
        {
            Dictionary<int, int> contadorNumeros = new Dictionary<int, int>();

            for (int f = 0; f < filas; f++)
            {
                for (int c = 0; c < columnas; c++)
                {
                    int numero = arreglo[f, c];

                    // IMPORTANTE: Ignorar los ceros al contar patrones
                    if (numero == 0)
                        continue;

                    if (contadorNumeros.ContainsKey(numero))
                    {
                        contadorNumeros[numero]++;
                    }
                    else
                    {
                        contadorNumeros[numero] = 1;
                    }
                }
            }

            // Si no hay números diferentes de 0, retornar 0
            if (contadorNumeros.Count == 0)
            {
                Console.WriteLine("\nNo hay números para buscar patrones (solo ceros).");
                return 0;
            }

            int patronMasRepetido = 0;
            int maxRepeticiones = 0;

            foreach (var par in contadorNumeros)
            {
                if (par.Value > maxRepeticiones)
                {
                    maxRepeticiones = par.Value;
                    patronMasRepetido = par.Key;
                }
            }

            Console.WriteLine($"\nPatrón más repetido: {patronMasRepetido}");
            Console.WriteLine($"Se repite: {maxRepeticiones} veces");

            return patronMasRepetido;
        }

        public int IdentificarPatron(int patron)
        {
            int contador = 0;

            for (int f = 0; f < filas; f++)
            {
                for (int c = 0; c < columnas; c++)
                {
                    if (arreglo[f, c] == patron)
                    {
                        Console.WriteLine($"  → Fila {f}, Columna {c} = {patron}");
                        contador++;
                    }
                }
            }

            if (contador == 0)
            {
                Console.WriteLine("No se encontró el patrón en la matriz.");
            }
            else
            {
                Console.WriteLine($"\n✓ Total de veces encontrado: {contador}");
            }

            return contador;
        }

        public int SumarPatron(int patron)
        {
            int suma = 0;
            int contador = 0;

            for (int f = 0; f < filas; f++)
            {
                for (int c = 0; c < columnas; c++)
                {
                    if (arreglo[f, c] == patron)
                    {
                        suma += arreglo[f, c];
                        contador++;
                    }
                }
            }

            Console.WriteLine($"Patrón buscado: {patron}");
            Console.WriteLine($"Veces encontrado: {contador}");
            Console.WriteLine($"Suma total: {suma}");

            return suma;
        }

        public int TotalSuma()
        {
            int suma = 0;

            for (int f = 0; f < filas; f++)
            {
                for (int c = 0; c < columnas; c++)
                {
                    suma += arreglo[f, c];
                }
            }

            return suma;
        }
    }
}