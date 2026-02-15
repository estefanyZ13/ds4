-- Crear base de datos
CREATE DATABASE CafeteriaFanny;
GO

USE CafeteriaFanny;
GO

-- Tabla Productos
CREATE TABLE Productos (
    ProductoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL
);
GO

-- Tabla Pedidos  
CREATE TABLE Pedidos (
    PedidoID INT PRIMARY KEY IDENTITY(1,1),
    NombreCliente NVARCHAR(100) NOT NULL,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    Total DECIMAL(10,2) NOT NULL,
    FechaPedido DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);
GO

-- Insertar productos de ejemplo
INSERT INTO Productos (Nombre, Precio) VALUES
('Café Americano', 2.50),
('Café Latte', 3.50),
('Cappuccino', 3.75),
('Croissant', 2.00),
('Sandwich', 4.50);
GO