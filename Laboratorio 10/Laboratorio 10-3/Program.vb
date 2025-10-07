Imports System

Module peso
    Sub Main(args As String())
        'declaracion de variables
        Dim M As Double
        Dim G As Double
        Dim P As Double

        ' INGRESE VALORES PARA LAS VARIABLES 
        G = 9.8
        Console.WriteLine("iNGRESE LA MASA DEL OBJETO:")
        M = Console.ReadLine
        'Realzar los procesos
        P = M * G
        'Mostrar rasultados
        Console.WriteLine("Peso del objeto:{0}:", P)
        Console.ReadKey()
    End Sub
End Module
