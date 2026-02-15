<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Parcial3.Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sistema de Gestión de Artículos Científicos</title>
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }
        
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            min-height: 100vh;
            padding: 20px;
        }
        
        .container {
            max-width: 1200px;
            margin: 0 auto;
            background: white;
            border-radius: 15px;
            box-shadow: 0 20px 60px rgba(0,0,0,0.3);
            overflow: hidden;
        }
        
        .header {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
            padding: 30px;
            text-align: center;
        }
        
        .header h1 {
            font-size: 2.5em;
            margin-bottom: 10px;
        }
        
        .content {
            padding: 30px;
        }
        
        .form-section {
            background: #f8f9fa;
            padding: 25px;
            border-radius: 10px;
            margin-bottom: 30px;
            border-left: 4px solid #667eea;
        }
        
        .form-section h2 {
            color: #333;
            margin-bottom: 20px;
            font-size: 1.5em;
        }
        
        .form-group {
            margin-bottom: 20px;
        }
        
        .form-group label {
            display: block;
            margin-bottom: 8px;
            color: #555;
            font-weight: 600;
        }
        
        .form-group input[type="text"],
        .form-group textarea {
            width: 100%;
            padding: 12px;
            border: 2px solid #ddd;
            border-radius: 8px;
            font-size: 14px;
            transition: border-color 0.3s;
        }
        
        .form-group input[type="text"]:focus,
        .form-group textarea:focus {
            outline: none;
            border-color: #667eea;
        }
        
        .form-group textarea {
            min-height: 100px;
            resize: vertical;
        }
        
        .btn {
            padding: 12px 30px;
            border: none;
            border-radius: 8px;
            font-size: 16px;
            cursor: pointer;
            transition: all 0.3s;
            font-weight: 600;
            margin-right: 10px;
        }
        
        .btn-primary {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
        }
        
        .btn-primary:hover {
            transform: translateY(-2px);
            box-shadow: 0 5px 15px rgba(102, 126, 234, 0.4);
        }
        
        .btn-secondary {
            background: #6c757d;
            color: white;
        }
        
        .btn-secondary:hover {
            background: #5a6268;
        }
        
        .btn-danger {
            background: #dc3545;
            color: white;
        }
        
        .btn-danger:hover {
            background: #c82333;
        }
        
        .grid-container {
            background: white;
            border-radius: 10px;
            overflow: hidden;
            box-shadow: 0 2px 10px rgba(0,0,0,0.1);
        }
        
        .alert {
            padding: 15px;
            border-radius: 8px;
            margin-bottom: 20px;
            font-weight: 500;
        }
        
        .alert-success {
            background: #d4edda;
            color: #155724;
            border-left: 4px solid #28a745;
        }
        
        .alert-danger {
            background: #f8d7da;
            color: #721c24;
            border-left: 4px solid #dc3545;
        }
        
        .stats {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
            gap: 20px;
            margin-bottom: 30px;
        }
        
        .stat-card {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
            padding: 20px;
            border-radius: 10px;
            text-align: center;
        }
        
        .stat-card h3 {
            font-size: 2em;
            margin-bottom: 5px;
        }
        
        .stat-card p {
            opacity: 0.9;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="header">
                <h1>📚 Sistema de Gestión de Artículos Científicos</h1>
                <p>Universidad - Grupo de Investigación</p>
            </div>
            
            <div class="content">
                <asp:Label ID="lblMensaje" runat="server" CssClass="alert" Visible="false"></asp:Label>
                
                <div class="stats">
                    <div class="stat-card">
                        <h3><asp:Label ID="lblTotalArticulos" runat="server" Text="0"></asp:Label></h3>
                        <p>Total de Artículos</p>
                    </div>
                </div>
                
                <div class="form-section">
                    <h2>📝 Registrar Nuevo Artículo</h2>
                    
                    <asp:HiddenField ID="hfArticuloId" runat="server" Value="0" />
                    
                    <div class="form-group">
                        <label>Título del Artículo:</label>
                        <asp:TextBox ID="txtTitulo" runat="server" placeholder="Ingrese el título del artículo"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTitulo" runat="server" 
                            ControlToValidate="txtTitulo" 
                            ErrorMessage="El título es obligatorio" 
                            ForeColor="Red" 
                            Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form-group">
                        <label>Autor(es):</label>
                        <asp:TextBox ID="txtAutor" runat="server" placeholder="Nombre completo del autor o autores"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAutor" runat="server" 
                            ControlToValidate="txtAutor" 
                            ErrorMessage="El autor es obligatorio" 
                            ForeColor="Red" 
                            Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form-group">
                        <label>Año de Publicación:</label>
                        <asp:TextBox ID="txtAnio" runat="server" placeholder="YYYY" MaxLength="4"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAnio" runat="server" 
                            ControlToValidate="txtAnio" 
                            ErrorMessage="El año es obligatorio" 
                            ForeColor="Red" 
                            Display="Dynamic">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revAnio" runat="server" 
                            ControlToValidate="txtAnio" 
                            ErrorMessage="Ingrese un año válido (YYYY)" 
                            ValidationExpression="^\d{4}$" 
                            ForeColor="Red" 
                            Display="Dynamic">
                        </asp:RegularExpressionValidator>
                    </div>
                    
                    <div class="form-group">
                        <label>Revista Científica:</label>
                        <asp:TextBox ID="txtRevista" runat="server" placeholder="Nombre de la revista que publica el artículo"></asp:TextBox>
                    </div>
                    
                    <div class="form-group">
                        <label>DOI (Digital Object Identifier):</label>
                        <asp:TextBox ID="txtDOI" runat="server" placeholder="Ej: 10.1234/ejemplo.2024"></asp:TextBox>
                    </div>
                    
                    <div class="form-group">
                        <label>Resumen del Artículo:</label>
                        <asp:TextBox ID="txtResumen" runat="server" TextMode="MultiLine" placeholder="Descripción breve del contenido del artículo"></asp:TextBox>
                    </div>
                    
                    <div class="form-group">
                        <label>Palabras Clave:</label>
                        <asp:TextBox ID="txtPalabrasClave" runat="server" placeholder="Separadas por comas: investigación, ciencia, tecnología"></asp:TextBox>
                    </div>
                    
                    <div class="form-group">
                        <label>Ubicación Física:</label>
                        <asp:TextBox ID="txtUbicacion" runat="server" placeholder="Estante, caja o archivo donde se encuentra la copia física"></asp:TextBox>
                    </div>
                    
                    <div>
                        <asp:Button ID="btnGuardar" runat="server" Text="💾 Guardar Artículo" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnNuevo" runat="server" Text="🆕 Nuevo" CssClass="btn btn-secondary" OnClick="btnNuevo_Click" CausesValidation="false" />
                    </div>
                </div>
                
                <div class="form-section">
                    <h2>🔍 Listado de Artículos Científicos</h2>
                    <div class="grid-container">
                        <asp:GridView ID="gvArticulos" runat="server" 
                            AutoGenerateColumns="False" 
                            Width="100%" 
                            CellPadding="10"
                            GridLines="None"
                            OnRowCommand="gvArticulos_RowCommand"
                            DataKeyNames="Id">
                            <HeaderStyle BackColor="#667eea" ForeColor="White" Font-Bold="True" />
                            <AlternatingRowStyle BackColor="#f8f9fa" />
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="ID" Visible="false" />
                                <asp:BoundField DataField="Titulo" HeaderText="Título" />
                                <asp:BoundField DataField="Autor" HeaderText="Autor(es)" />
                                <asp:BoundField DataField="AnioPublicacion" HeaderText="Año" />
                                <asp:BoundField DataField="RevistaCientifica" HeaderText="Revista" />
                                <asp:BoundField DataField="DOI" HeaderText="DOI" />
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEditar" runat="server" 
                                            Text="✏️ Editar" 
                                            CommandName="Editar" 
                                            CommandArgument='<%# Eval("Id") %>' 
                                            CssClass="btn btn-primary" 
                                            CausesValidation="false" />
                                        <asp:Button ID="btnEliminar" runat="server" 
                                            Text="🗑️ Eliminar" 
                                            CommandName="Eliminar" 
                                            CommandArgument='<%# Eval("Id") %>' 
                                            CssClass="btn btn-danger" 
                                            OnClientClick="return confirm('¿Está seguro de eliminar este artículo?');" 
                                            CausesValidation="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div style="padding: 20px; text-align: center; color: #999;">
                                    No hay artículos registrados. ¡Comienza agregando el primero!
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>