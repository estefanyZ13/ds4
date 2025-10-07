Public Class Perro
    Public nombre As String
    Public raza As String
    Public altura As String


    Public Function comer(carne As String) As String
        Return nombre + "mide" + altura + "y comera" + carne
    End Function

    Public Sub dormir()

    End Sub

    Public Sub ladrar()

    End Sub

    Public Function calcularCostos(costo As Double, impueto As Double) As Double
        Dim preciototal As Double
        preciototal = costo + (costo * impueto)
        Return preciototal
    End Function

    Public Sub New()

    End Sub

    Public Sub New(nobre As String, raza As String, altura As String)
        Me.nombre = nombre
        Me.raza = raza
        Me.altura = altura
    End Sub


End Class
