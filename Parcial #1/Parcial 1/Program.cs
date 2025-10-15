using System;
using Parcial_1;

namespace Parcial_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program programa = new Program();
            programa.Ejecutar();
        }

        public void Ejecutar()
        {
            try
            {
                int filas = SolicitarNumero("Ingrese el número de FILAS: ");
                int columnas = SolicitarNumero("Ingrese el número de COLUMNAS: ");
                int min = SolicitarNumero("Ingrese el número MÍNIMO: ");
                int max = SolicitarNumero("Ingrese el número MÁXIMO: ");

                Aleatorios obj = new Aleatorios(filas, columnas, min, max);

                // Usar el método de diagonal y esquinas
                obj.MatrizDiagonalYEsquinas();

                // Mostrar la matriz con formato especial
                obj.MostrarDiagonalYEsquinas();

                int patron = obj.EncontrarPatronRepetido();

                Console.WriteLine("\nBuscando el patrón en la matriz:");
                obj.IdentificarPatron(patron);

                Console.WriteLine("\nSumando el patrón:");
                obj.SumarPatron(patron);

                int total = obj.TotalSuma();

                Console.WriteLine($"\n  Suma total de TODA la matriz: {total}");
                Console.WriteLine("\n✓ Proceso completado. Presione cualquier tecla para salir...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Error: {ex.Message}");
                Console.WriteLine("\nPresione cualquier tecla para salir...");
                Console.ReadKey();
            }
        }

        private int SolicitarNumero(string mensaje)
        {
            Console.Write(mensaje);
            return int.Parse(Console.ReadLine());
        }
    }
}