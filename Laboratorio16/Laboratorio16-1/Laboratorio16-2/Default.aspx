<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio16_1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Calculadora</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: lightblue;
        }
        .calc {
            width: 481px;
            margin: 50px auto;
            padding: 20px;
            background-color: white;
            border-radius: 10px;
            box-shadow: 0px 0px 10px rgba(0,0,0,0.5);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="calc">
            <h2 style="text-align:center;">CALCULADORA BÁSICA</h2>
            <asp:TextBox ID="txtDisplay" runat="server" ReadOnly="true" Style="text-align:right; font-size:24px; margin-bottom:10px;" Width="100%"></asp:TextBox>
            <br />
            <asp:Button ID="btn10" runat="server" Text="1" OnClick="b1_Click" Style="margin:2px;" Width="15%" Height="50px" />
            <asp:Button ID="btn11" runat="server" Text="2" OnClick="b2_Click" Style="margin:2px;" Width="13%" Height="50px" />
            <asp:Button ID="btn12" runat="server" Text="3" OnClick="b3_Click" Style="margin:2px;" Width="14%" Height="50px" />
            <asp:Button ID="btn13" runat="server" Text="4" OnClick="b4_Click" Style="margin:2px;" Width="13%" Height="50px" />
            <asp:Button ID="btn14" runat="server" Text="5" OnClick="b5_Click" Style="margin:2px;" Width="14%" Height="50px" />
            <br />
            <asp:Button ID="btn15" runat="server" Text="6" OnClick="b6_Click" Style="margin:2px;" Width="14%" Height="50px" />
            <asp:Button ID="btn7" runat="server" Text="7" OnClick="b7_Click" Style="margin:2px;" Width="13%" Height="50px" />
            <asp:Button ID="btn8" runat="server" Text="8" OnClick="b8_Click" Style="margin:2px;" Width="14%" Height="50px" />
            <asp:Button ID="btn9" runat="server" Text="9" Style="margin:2px;" Width="13%" Height="50px" />
            <asp:Button ID="btn0" runat="server" Text="0" OnClick="b0_Click" Style="margin:2px;" Width="14%" Height="50px" />
            <br />
            <asp:Button ID="btnSub" runat="server" Text="-" OnClick="sub_Click" Style="margin:2px;" Width="17%" Height="50px" />
            <asp:Button ID="btnDiv" runat="server" Text="/" OnClick="div_Click" Style="margin:2px;" Width="18%" Height="50px" />
            <asp:Button ID="btnAdd0" runat="server" Text="+" OnClick="add_Click" Style="margin:2px;" Width="19%" Height="50px" />
            <br />
            <asp:Button ID="btnDot" runat="server" Text="." Style="margin:2px;" Width="17%" Height="50px" />
            <asp:Button ID="btnMul" runat="server" Text="*" OnClick="mul_Click" Style="margin:2px;" Width="17%" Height="50px" />
            <asp:Button ID="btnEqual0" runat="server" Text="=" OnClick="eql_Click" Style="margin:2px;" Width="20%" Height="50px" />
            <br />
            <asp:Button ID="btnClear" runat="server" Text="C" OnClick="clr_Click" Style="margin:2px; background-color:red; color:white;" Width="100%" Height="50px" />
        </div>
    </form>
</body>
</html>