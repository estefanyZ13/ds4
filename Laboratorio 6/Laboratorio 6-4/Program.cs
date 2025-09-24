internal class Program
{
    static void checkAgeB(int age)
    {
        if (age < 18)
        {
            throw new ArithmeticException();
        }
        else
        {
            Console.WriteLine("Hello, World!");
        }
    }
    static void Main(string[] args)
    {
        checkAgeB(15);
    }
}