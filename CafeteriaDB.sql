-- Crear la base de datos
CREATE DATABASE CafeteriaDB;
GO

USE CafeteriaDB;
GO

-- Tabla para el menú de la cafetería
CREATE TABLE Menu (
    MenuID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE()
);
GO

-- Tabla para los pedidos
CREATE TABLE Pedidos (
    PedidoID INT PRIMARY KEY IDENTITY(1,1),
    MenuID INT NOT NULL,
    NombreCliente NVARCHAR(100) NOT NULL,
    Cantidad INT NOT NULL,
    Total DECIMAL(10,2) NOT NULL,
    FechaPedido DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (MenuID) REFERENCES Menu(MenuID)
);
GO

-- Insertar algunos datos de ejemplo en el menú
INSERT INTO Menu (Nombre, Precio) VALUES
('Café Americano', 2.50),
('Café Latte', 3.50),
('Cappuccino', 3.75),
('Té Verde', 2.00),
('Croissant', 2.25),
('Sandwich de Jamón', 4.50),
('Ensalada César', 5.00),
('Pastel de Chocolate', 3.00);
GO

-- Vista para consultar pedidos con detalles del menú
CREATE VIEW VistaPedidos AS
SELECT 
    p.PedidoID,
    p.NombreCliente,
    m.Nombre AS NombreProducto,
    m.Precio AS PrecioUnitario,
    p.Cantidad,
    p.Total,
    p.FechaPedido
FROM Pedidos p
INNER JOIN Menu m ON p.MenuID = m.MenuID;
GO