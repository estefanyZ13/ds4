<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Laboratorio203.aspx.cs" Inherits="Laboratorio203.Laboratorio203" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>CRUD Laptops - Productos</title>
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }
        
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            padding: 20px;
            min-height: 100vh;
        }
        
        .container {
            max-width: 600px;
            margin: 0 auto;
            background: white;
            border-radius: 15px;
            box-shadow: 0 10px 40px rgba(0,0,0,0.2);
            overflow: hidden;
        }
        
        .header {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
            padding: 25px;
            text-align: center;
        }
        
        .header h2 {
            margin: 0;
            font-size: 28px;
            font-weight: 600;
        }
        
        .toolbar {
            background: #f8f9fa;
            padding: 15px;
            border-bottom: 2px solid #e9ecef;
            display: flex;
            gap: 10px;
            align-items: center;
            flex-wrap: wrap;
        }
        
        .search-section {
            display: flex;
            gap: 10px;
            align-items: center;
            flex: 1;
        }
        
        .search-section label {
            font-weight: 600;
            color: #495057;
        }
        
        .txt-search {
            padding: 8px 12px;
            border: 2px solid #ced4da;
            border-radius: 5px;
            font-size: 14px;
            width: 100px;
        }
        
        .btn {
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 14px;
            font-weight: 600;
            transition: all 0.3s;
            display: inline-flex;
            align-items: center;
            gap: 5px;
        }
        
        .btn:hover {
            transform: translateY(-2px);
            box-shadow: 0 5px 15px rgba(0,0,0,0.2);
        }
        
        .btn-nuevo {
            background: #28a745;
            color: white;
        }
        
        .btn-nuevo:hover {
            background: #218838;
        }
        
        .btn-guardar {
            background: #007bff;
            color: white;
        }
        
        .btn-guardar:hover {
            background: #0056b3;
        }
        
        .btn-cancelar {
            background: #6c757d;
            color: white;
        }
        
        .btn-cancelar:hover {
            background: #545b62;
        }
        
        .btn-eliminar {
            background: #dc3545;
            color: white;
        }
        
        .btn-eliminar:hover {
            background: #c82333;
        }
        
        .btn-buscar {
            background: #17a2b8;
            color: white;
        }
        
        .btn-buscar:hover {
            background: #117a8b;
        }
        
        .btn-salir {
            background: #343a40;
            color: white;
        }
        
        .btn-salir:hover {
            background: #23272b;
        }
        
        .form-content {
            padding: 30px;
        }
        
        .form-group {
            margin-bottom: 20px;
        }
        
        .form-group label {
            display: block;
            margin-bottom: 8px;
            font-weight: 600;
            color: #495057;
            font-size: 14px;
        }
        
        .form-control {
            width: 100%;
            padding: 12px;
            border: 2px solid #ced4da;
            border-radius: 5px;
            font-size: 16px;
            transition: border-color 0.3s;
        }
        
        .form-control:focus {
            outline: none;
            border-color: #667eea;
        }
        
        .form-control:disabled {
            background-color: #e9ecef;
            cursor: not-allowed;
        }
        
        .message {
            padding: 15px;
            margin: 20px 30px;
            border-radius: 5px;
            font-weight: 600;
            text-align: center;
        }
        
        .message-success {
            background: #d4edda;
            color: #155724;
            border: 1px solid #c3e6cb;
        }
        
        .message-error {
            background: #f8d7da;
            color: #721c24;
            border: 1px solid #f5c6cb;
        }
        
        .message-info {
            background: #d1ecf1;
            color: #0c5460;
            border: 1px solid #bee5eb;
        }
        
        .footer {
            background: #f8f9fa;
            padding: 20px;
            text-align: center;
            border-top: 2px solid #e9ecef;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="header">
                <h2>🖥️ Gestión de Laptops</h2>
            </div>
            
            <div class="toolbar">
                <div class="search-section">
                    <label>Buscar ID:</label>
                    <asp:TextBox ID="txtBuscarId" runat="server" CssClass="txt-search" placeholder="ID"></asp:TextBox>
                    <asp:Button ID="btnBuscar" runat="server" Text="🔍 Buscar" CssClass="btn btn-buscar" OnClick="btnBuscar_Click" />
                </div>
                
                <asp:Button ID="btnNuevo" runat="server" Text="➕ Nuevo" CssClass="btn btn-nuevo" OnClick="btnNuevo_Click" />
                <asp:Button ID="btnGuardar" runat="server" Text="💾 Guardar" CssClass="btn btn-guardar" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="❌ Cancelar" CssClass="btn btn-cancelar" OnClick="btnCancelar_Click" />
                <asp:Button ID="btnEliminar" runat="server" Text="🗑️ Eliminar" CssClass="btn btn-eliminar" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Está seguro de eliminar este registro?');" />
            </div>
            
            <asp:Label ID="lblMensaje" runat="server" CssClass="message"></asp:Label>
            
            <div class="form-content">
                <div class="form-group">
                    <label>ID:</label>
                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
                
                <div class="form-group">
                    <label>Nombre de la Laptop:</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ej: Dell Inspiron 15"></asp:TextBox>
                </div>
                
                <div class="form-group">
                    <label>Precio:</label>
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" placeholder="Ej: 899.99"></asp:TextBox>
                </div>
                
                <div class="form-group">
                    <label>Stock:</label>
                    <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" placeholder="Ej: 50"></asp:TextBox>
                </div>
            </div>
            
            <div class="footer">
                <asp:Button ID="btnSalir" runat="server" Text="🚪 Salir" CssClass="btn btn-salir" OnClick="btnSalir_Click" />
            </div>
        </div>
    </form>
</body>
</html>