Imports System
Imports System.Runtime.InteropServices.JavaScript.JSType

Module Program
    Sub Main(args As String())

        Dim perrito As Perro = New Perro()
        perrito.nombre = "chizu"
        perrito.raza = "Pastor aleman"
        perrito.altura = "0.70cm"

       Console.WriteLine(perrito.comer("Carne"))

         Dim perrito2 As Perro = New Perro()
        perrito2.nombre = "Lazy"
        perrito2.altura = "060cm"

        Console.WriteLine(perrito2.comer("Pollo"))
        Dim perrito3 As Perro = New Perro("Peluchin", "Poodle", "0,50")

        Console.WriteLine(perrito3.comer("Pan"))

    End Sub
End Module
