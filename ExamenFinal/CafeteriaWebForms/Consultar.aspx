<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consultar.aspx.cs" Inherits="CafeteriaWebForms.Consultar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consultar Pedido - Cafetería</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
            margin: 0;
            padding: 20px;
        }
        .container {
            max-width: 900px;
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
        .consulta-section {
            margin-top: 30px;
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
        .form-group input {
            width: 100%;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
            box-sizing: border-box;
            font-size: 16px;
        }
        .btn-consultar {
            background-color: #6f4e37;
            color: white;
            padding: 12px 30px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            margin-top: 10px;
        }
        .btn-consultar:hover {
            background-color: #8b6d4f;
        }
        .resultado-section {
            margin-top: 30px;
            padding: 20px;
            background-color: #f9f9f9;
            border-radius: 8px;
            border: 1px solid #ddd;
        }
        .info-pedido {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 15px;
            margin-bottom: 20px;
        }
        .info-item {
            padding: 10px;
            background-color: white;
            border-radius: 5px;
            border-left: 4px solid #6f4e37;
        }
        .info-item strong {
            display: block;
            color: #6f4e37;
            margin-bottom: 5px;
        }
        .estado {
            display: inline-block;
            padding: 5px 15px;
            border-radius: 20px;
            font-weight: bold;
            color: white;
        }
        .estado-pendiente {
            background-color: #ffc107;
        }
        .estado-preparacion {
            background-color: #17a2b8;
        }
        .estado-completado {
            background-color: #28a745;
        }
        .estado-cancelado {
            background-color: #dc3545;
        }
        .detalles-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        .detalles-table th {
            background-color: #6f4e37;
            color: white;
            padding: 12px;
            text-align: left;
        }
        .detalles-table td {
            padding: 10px;
            border-bottom: 1px solid #ddd;
        }
        .detalles-table tr:hover {
            background-color: #f5f5f5;
        }
        .total-row {
            font-size: 18px;
            font-weight: bold;
            background-color: #fff8dc;
        }
        .mensaje {
            padding: 15px;
            margin-top: 20px;
            border-radius: 5px;
            text-align: center;
            font-weight: bold;
        }
        .mensaje.error {
            background-color: #f8d7da;
            color: #721c24;
            border: 1px solid #f5c6cb;
        }
        .btn-volver {
            display: inline-block;
            margin-top: 20px;
            padding: 10px 20px;
            background-color: #6c757d;
            color: white;
            text-decoration: none;
            border-radius: 5px;
        }
        .btn-volver:hover {
            background-color: #5a6268;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>🔍 Consultar Estado del Pedido</h1>
            
            <!-- Sección: Consultar Pedido -->
            <div class="consulta-section">
                <h2>Ingresa el ID de tu Pedido</h2>
                
                <div class="form-group">
                    <label for="txtPedidoID">ID del Pedido:</label>
                    <asp:TextBox ID="txtPedidoID" runat="server" 
                                placeholder="Ejemplo: 1" 
                                TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPedidoID" runat="server" 
                                               ControlToValidate="txtPedidoID"
                                               ErrorMessage="El ID del pedido es requerido" 
                                               ForeColor="Red"
                                               Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvPedidoID" runat="server" 
                                       ControlToValidate="txtPedidoID"
                                       MinimumValue="1" 
                                       MaximumValue="999999"
                                       Type="Integer"
                                       ErrorMessage="Ingresa un ID válido (mayor a 0)" 
                                       ForeColor="Red"
                                       Display="Dynamic">
                    </asp:RangeValidator>
                </div>

                <asp:Button ID="btnConsultar" runat="server" 
                           Text="Consultar Pedido" 
                           CssClass="btn-consultar"
                           OnClick="btnConsultar_Click" />
            </div>

            <!-- Mensaje de error -->
            <asp:Panel ID="pnlError" runat="server" Visible="false">
                <div class="mensaje error">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </div>
            </asp:Panel>

            <!-- Sección: Resultado del Pedido -->
            <asp:Panel ID="pnlResultado" runat="server" Visible="false">
                <div class="resultado-section">
                    <h2>📋 Información del Pedido</h2>
                    
                    <div class="info-pedido">
                        <div class="info-item">
                            <strong>ID del Pedido:</strong>
                            <asp:Label ID="lblPedidoID" runat="server"></asp:Label>
                        </div>
                        <div class="info-item">
                            <strong>Cliente:</strong>
                            <asp:Label ID="lblNombreCliente" runat="server"></asp:Label>
                        </div>
                        <div class="info-item">
                            <strong>Fecha:</strong>
                            <asp:Label ID="lblFecha" runat="server"></asp:Label>
                        </div>
                        <div class="info-item">
                            <strong>Estado:</strong>
                            <asp:Label ID="lblEstado" runat="server" CssClass="estado"></asp:Label>
                        </div>
                    </div>

                    <h3>Detalle de Productos</h3>
                    <asp:GridView ID="GridViewDetalles" runat="server" 
                                 AutoGenerateColumns="False" 
                                 CssClass="detalles-table"
                                 ShowFooter="True"
                                 OnRowDataBound="GridViewDetalles_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="NombreProducto" HeaderText="Producto" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unit." DataFormatString="${0:F2}" />
                            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="${0:F2}" />
                        </Columns>
                        <FooterStyle CssClass="total-row" />
                    </asp:GridView>
                </div>
            </asp:Panel>

            <a href="Menu.aspx" class="btn-volver">← Volver al Menú</a>
        </div>
    </form>
</body>
</html>
