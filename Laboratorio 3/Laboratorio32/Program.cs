internal class Program
{
    private static void Main(string[] args)
    {
        double radioCirculo, calculoArea;
    

        Console.Write("Introduce el radio de la circunferencia :");
        radioCirculo = Convert.ToInt32(Console.ReadLine());



        calculoArea = (3.1416 * (radioCirculo * radioCirculo));

        Console.WriteLine("el  Area del Circulo   {0} es {1}:", radioCirculo, calculoArea);

    }
}