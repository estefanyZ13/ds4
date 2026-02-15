<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="CafeteriaWebForms.Menu" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menú - Cafetería</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
            margin: 0;
            padding: 20px;
        }
        .container {
            max-width: 1200px;
            margin: 0 auto;
            background-color: white;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.1);
        }
        h1 {
            color: #6f4e37;
            text-align: center;
            border-bottom: 3px solid #6f4e37;
            padding-bottom: 10px;
        }
        .menu-section {
            margin-top: 30px;
        }
        .gridview {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        .gridview th {
            background-color: #6f4e37;
            color: white;
            padding: 12px;
            text-align: left;
        }
        .gridview td {
            padding: 10px;
            border-bottom: 1px solid #ddd;
        }
        .gridview tr:hover {
            background-color: #f9f9f9;
        }
        .pedido-section {
            margin-top: 40px;
            padding: 20px;
            background-color: #fff8dc;
            border-radius: 8px;
        }
        .form-group {
            margin-bottom: 15px;
        }
        .form-group label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
            color: #333;
        }
        .form-group input, .form-group select {
            width: 100%;
            padding: 8px;
            border: 1px solid #ddd;
            border-radius: 4px;
            box-sizing: border-box;
        }
        .btn-realizar-pedido {
            background-color: #6f4e37;
            color: white;
            padding: 12px 30px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            margin-top: 10px;
        }
        .btn-realizar-pedido:hover {
            background-color: #8b6d4f;
        }
        .mensaje {
            padding: 15px;
            margin-top: 20px;
            border-radius: 5px;
            text-align: center;
            font-weight: bold;
        }
        .mensaje.exito {
            background-color: #d4edda;
            color: #155724;
            border: 1px solid #c3e6cb;
        }
        .mensaje.error {
            background-color: #f8d7da;
            color: #721c24;
            border: 1px solid #f5c6cb;
        }
        .carrito-item {
            background-color: white;
            padding: 10px;
            margin: 10px 0;
            border-radius: 5px;
            border: 1px solid #ddd;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }
        .btn-eliminar {
            background-color: #dc3545;
            color: white;
            padding: 5px 15px;
            border: none;
            border-radius: 3px;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>☕ Menú de Cafetería</h1>
            
            <!-- Sección: Productos Disponibles -->
            <div class="menu-section">
                <h2>Productos Disponibles</h2>
                <asp:GridView ID="GridViewProductos" runat="server" 
                              AutoGenerateColumns="False" 
                              CssClass="gridview"
                              OnRowCommand="GridViewProductos_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="ProductoID" HeaderText="ID" Visible="false" />
                        <asp:BoundField DataField="Nombre" HeaderText="Producto" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="${0:F2}" />
                        <asp:TemplateField HeaderText="Acción">
                            <ItemTemplate>
                                <asp:Button ID="btnAgregar" runat="server" 
                                           Text="Agregar al Pedido" 
                                           CommandName="Agregar" 
                                           CommandArgument='<%# Eval("ProductoID") + ";" + Eval("Nombre") + ";" + Eval("Precio") %>'
                                           CssClass="btn-realizar-pedido" 
                                           style="padding: 5px 15px; font-size: 14px;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

            <!-- Sección: Realizar Pedido -->
            <div class="pedido-section">
                <h2>🛒 Tu Pedido</h2>
                
                <div class="form-group">
                    <label for="txtNombreCliente">Nombre del Cliente:</label>
                    <asp:TextBox ID="txtNombreCliente" runat="server" placeholder="Ingresa tu nombre"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" 
                                               ControlToValidate="txtNombreCliente"
                                               ErrorMessage="El nombre es requerido" 
                                               ForeColor="Red"
                                               Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>

                <!-- Carrito de productos -->
                <div style="margin: 20px 0;">
                    <h3>Productos en tu pedido:</h3>
                    <asp:Panel ID="pnlCarrito" runat="server">
                        <asp:Label ID="lblCarritoVacio" runat="server" 
                                  Text="No hay productos en el pedido" 
                                  ForeColor="Gray"></asp:Label>
                    </asp:Panel>
                </div>

                <div style="text-align: right; font-size: 18px; font-weight: bold; margin: 10px 0;">
                    Total: <asp:Label ID="lblTotal" runat="server" Text="$0.00"></asp:Label>
                </div>

                <asp:Button ID="btnRealizarPedido" runat="server" 
                           Text="Realizar Pedido" 
                           CssClass="btn-realizar-pedido"
                           OnClick="btnRealizarPedido_Click" />

                <!-- Mensaje de resultado -->
                <asp:Panel ID="pnlMensaje" runat="server" Visible="false">
                    <div class="mensaje" id="divMensaje" runat="server">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </form>
</body>
</html>