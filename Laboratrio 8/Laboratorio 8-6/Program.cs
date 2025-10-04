internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Corrio la aplicaion ");
    }
}
//virtual : la clase base , marca que un metodo puede ser subescrito en la clase hijas
// override : en la clase hija ,indica que esta escribiendo un metodo virtual o abtract de clase padre 
// sealed : significa sellado 
//Si lo pones en una clase → esa clase ya no puede tener herencia.
//Si lo pones en un método → ese método ya no puede volver a ser sobrescrito en clases que hereden de esa clase.