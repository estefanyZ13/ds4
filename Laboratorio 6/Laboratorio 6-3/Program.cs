internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            int[] myNumbers = { 1, 2, 3 };
            Console.WriteLine("Hello, World!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Algo salio mal, valideel indice del arreglo ");
        }
        finally
        {
           Console.WriteLine("Continucaion de la aplicacion, luego del bloque try/catch ");
        }
    }
}