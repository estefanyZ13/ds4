internal class Program
{
    private static void Main(string[] args)
    {
        int  alturaRectangulo, baseRectangulo;

        CalculosMatematicos cal = new CalculosMatematicos();

        Console.Write("Introduce la altura del restangulo:");
        alturaRectangulo = Convert.ToInt32(Console.ReadLine());

        Console.Write("Introduce la base del restangulo:");
        baseRectangulo = Convert.ToInt32(Console.ReadLine());


        

        Console.WriteLine("La suma de {0} y {1} es {2}:", alturaRectangulo, baseRectangulo, cal.Calculo(alturaRectangulo,baseRectangulo));

    }
}

public class CalculosMatematicos
{
    public int Calculo(int a, int b)
    {
        return 2 * (a + b);

    }

}




