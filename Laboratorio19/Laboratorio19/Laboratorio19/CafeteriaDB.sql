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
    Categoria NVARCHAR(50) NOT NULL
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

-- Insertar algunos datos de ejemplo en el menú con categorías
INSERT INTO Menu (Nombre, Precio, Categoria) VALUES
('Café Americano', 2.50, 'Bebidas Calientes'),
('Café Latte', 3.50, 'Bebidas Calientes'),
('Cappuccino', 3.75, 'Bebidas Calientes'),
('Té Verde', 2.00, 'Bebidas Calientes'),
('Jugo Natural', 3.00, 'Bebidas Frías'),
('Limonada', 2.50, 'Bebidas Frías'),
('Croissant', 2.25, 'Panadería'),
('Donut', 1.75, 'Panadería'),
('Sandwich de Jamón', 4.50, 'Alimentos'),
('Sandwich Vegetariano', 4.00, 'Alimentos'),
('Ensalada César', 5.00, 'Alimentos'),
('Pastel de Chocolate', 3.00, 'Postres'),
('Cheesecake', 3.50, 'Postres');
GO

-- Vista para consultar pedidos con detalles del menú
CREATE VIEW VistaPedidos AS
SELECT 
    p.PedidoID,
    p.NombreCliente,
    m.Nombre AS NombreProducto,
    m.Categoria,
    m.Precio AS PrecioUnitario,
    p.Cantidad,
    p.Total,
    p.FechaPedido
FROM Pedidos p
INNER JOIN Menu m ON p.MenuID = m.MenuID;
GO


SELECT * FROM Pedidos ORDER BY FechaPedido DESC;

use CafeteriaDB;

SELECT name 
FROM sys.tables;
SELECT * FROM Pedidos;
