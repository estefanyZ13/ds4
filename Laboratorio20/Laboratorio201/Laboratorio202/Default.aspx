<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Laboratorio202.aspx.cs" Inherits="Laboratorio202.Laboratorio202" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Matriz N x N - Diagonal Inversa</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            padding: 20px;
            background-color: #f5f5f5;
        }
        .container {
            background-color: white;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.1);
            max-width: 800px;
            margin: 0 auto;
        }
        h2 {
            color: #333;
            text-align: center;
        }
        .input-group {
            margin: 20px 0;
            text-align: center;
        }
        table {
            margin: 20px auto;
            border-collapse: collapse;
            box-shadow: 0 2px 5px rgba(0,0,0,0.1);
        }
        td {
            border: 2px solid #333;
            padding: 15px 20px;
            text-align: center;
            font-size: 18px;
            font-weight: bold;
            background-color: #fff;
        }
        td.diagonal {
            background-color: #4CAF50;
            color: white;
        }
        td.zero {
            background-color: #f0f0f0;
            color: #666;
        }
        .btn-generar {
            background-color: #2196F3;
            color: white;
            padding: 10px 30px;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            margin-top: 10px;
        }
        .btn-generar:hover {
            background-color: #0b7dda;
        }
        .txt-numero {
            padding: 8px;
            font-size: 16px;
            border: 2px solid #ddd;
            border-radius: 5px;
            width: 100px;
            text-align: center;
        }
        .error {
            color: red;
            font-weight: bold;
            text-align: center;
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Generador de Matriz N x N con Diagonal Inversa</h2>
            
            <div class="input-group">
                <asp:Label ID="lblTitulo" runat="server" Text="Ingrese la dimensión N de la matriz:"></asp:Label>
                <br /><br />
                <asp:TextBox ID="txtDimension" runat="server" CssClass="txt-numero" placeholder="Ej: 5"></asp:TextBox>
                <br />
                <asp:Button ID="btnGenerar" runat="server" Text="Generar Matriz" CssClass="btn-generar" OnClick="btnGenerar_Click" />
            </div>
            
            <asp:Label ID="lblError" runat="server" CssClass="error"></asp:Label>
            
            <div>
                <asp:Literal ID="litMatriz" runat="server"></asp:Literal>
            </div>
        </div>
    </form>
</body>
</html>