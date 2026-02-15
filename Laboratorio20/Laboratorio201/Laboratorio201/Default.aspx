<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio201.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Tabla de Multiplicar</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Generador de Tabla de Multiplicar</h2>
            
            <asp:Label ID="lblNumero" runat="server" Text="Ingrese un número:"></asp:Label>
            <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
            <br /><br />
            
            <asp:Button ID="btnGenerar" runat="server" Text="Generar Tabla" OnClick="btnGenerar_Click" />
            <br /><br />
            
            <asp:Label ID="lblResultado" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>