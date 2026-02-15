using Laboratorio_9_5;

internal class Program
{
    private static void Main(string[] args)
    {
        Aleatorios generador = new Aleatorios();

        
        Console.WriteLine("NÚMEROS ALEATORIOS");
       

        Console.WriteLine("1. Generar un número entre 1 y 100:");
        int numero = generador.GenerarNumero(1, 100);
        Console.WriteLine($"   Número generado: {numero}\n");

        

        Console.WriteLine("\n6. Generar arreglo SIN REPETIR de 5 números entre 1 y 100:");
        int[] arreglo4 = generador.GenerarArregloSinRepetir(1, 100, 5);
        Console.Write("   ");
        generador.MostrarArreglo(arreglo4);

        Console.WriteLine("\n7. Intentar generar 15 números únicos entre 1 y 10:");
        int[] arreglo5 = generador.GenerarArregloSinRepetir(1, 10, 15);
        if (arreglo5.Length > 0)
        {
            Console.Write("   ");
            generador.MostrarArreglo(arreglo5);
        };

       
        Console.ReadKey();
    }
}