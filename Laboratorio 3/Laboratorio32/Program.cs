internal class Program
{
    private static void Main(string[] args)
    {
        double areaCirculo;

        CalculosMatematicos cal = new CalculosMatematicos();
        Console.Write("Introduce el radio de la circunferencia :");
        areaCirculo = Convert.ToInt32(Console.ReadLine());



        Console.WriteLine("el  Area del Circulo   {0} es {1}:", areaCirculo, cal.calculoArea(areaCirculo));

    }
}



public class CalculosMatematicos
{
    public double calculoArea(double a)
    {
        return 3.1416 * Math.Pow( a , 2);


    }
}
