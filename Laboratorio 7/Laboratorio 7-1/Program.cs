using Laboratorio_7;

NewMethod();

static void NewMethod()
{
    Banco banco1 = new Banco();
    banco1.Operar();
    banco1.DepositosTotales();
    Console.ReadKey();

}
