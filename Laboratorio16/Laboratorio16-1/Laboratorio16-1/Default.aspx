<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio16_1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="row">
            <div class="col-md-12">
                <h2>Mi primera página</h2>
                <p>
                    <asp:Label ID="lblMensaje" runat="server" Text="Hola Mundo" ForeColor="Red" Font-Size="35px"></asp:Label>
                </p>
                <p>
                    <asp:Button ID="btnMensaje" runat="server" Text="Mostrar Mensaje" CssClass="btn btn-primary" OnClick="btnMensaje_Click" />
                </p>
            </div>
        </div>
    </main>
</asp:Content>
