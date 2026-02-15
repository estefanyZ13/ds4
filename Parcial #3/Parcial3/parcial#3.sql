-- =============================================
-- Eliminar base de datos si existe (OPCIONAL)
-- =============================================
USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'Estefany_Zambrano')
BEGIN
    ALTER DATABASE Estefany_Zambrano SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE Estefany_Zambrano;
END
GO

-- =============================================
-- Crear la base de datos
-- =============================================
CREATE DATABASE Estefany_Zambrano;
GO

USE Estefany_Zambrano;
GO

-- =============================================
-- TABLAS PRINCIPALES
-- =============================================

CREATE TABLE EZ_Revistas (
    RevistaID INT PRIMARY KEY IDENTITY(1,1),
    NombreRevista NVARCHAR(200) NOT NULL,
    ISSN NVARCHAR(20),
    Editorial NVARCHAR(150),
    FactorImpacto DECIMAL(5,3),
    FechaRegistro DATETIME DEFAULT GETDATE()
);

CREATE TABLE EZ_LineasInvestigacion (
    LineaID INT PRIMARY KEY IDENTITY(1,1),
    NombreLinea NVARCHAR(150) NOT NULL,
    Descripcion NVARCHAR(500),
    FechaCreacion DATETIME DEFAULT GETDATE()
);

CREATE TABLE EZ_Autores (
    AutorID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150),
    Institucion NVARCHAR(200),
    FechaRegistro DATETIME DEFAULT GETDATE()
);

CREATE TABLE EZ_Articulos (
    ArticuloID INT PRIMARY KEY IDENTITY(1,1),
    Titulo NVARCHAR(300) NOT NULL,
    Resumen NVARCHAR(MAX),
    FechaPublicacion DATE,
    DOI NVARCHAR(100) UNIQUE,
    PalabrasClave NVARCHAR(500),
    URLDocumento NVARCHAR(500),
    RevistaID INT,
    TipoDocumento NVARCHAR(50),
    Estado NVARCHAR(30) DEFAULT 'Activo',
    FechaRegistro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (RevistaID) REFERENCES EZ_Revistas(RevistaID)
);

-- =============================================
-- TABLAS DE RELACIÓN
-- =============================================

CREATE TABLE EZ_ArticulosAutores (
    ArticuloAutorID INT PRIMARY KEY IDENTITY(1,1),
    ArticuloID INT NOT NULL,
    AutorID INT NOT NULL,
    OrdenAutoria INT,
    FOREIGN KEY (ArticuloID) REFERENCES EZ_Articulos(ArticuloID) ON DELETE CASCADE,
    FOREIGN KEY (AutorID) REFERENCES EZ_Autores(AutorID) ON DELETE CASCADE
);

CREATE TABLE EZ_ArticulosLineas (
    ArticuloLineaID INT PRIMARY KEY IDENTITY(1,1),
    ArticuloID INT NOT NULL,
    LineaID INT NOT NULL,
    FOREIGN KEY (ArticuloID) REFERENCES EZ_Articulos(ArticuloID) ON DELETE CASCADE,
    FOREIGN KEY (LineaID) REFERENCES EZ_LineasInvestigacion(LineaID) ON DELETE CASCADE
);

-- =============================================
-- ÍNDICES
-- =============================================

CREATE INDEX IX_Articulos_Titulo ON EZ_Articulos(Titulo);
CREATE INDEX IX_Articulos_FechaPublicacion ON EZ_Articulos(FechaPublicacion);
CREATE INDEX IX_Autores_Apellido ON EZ_Autores(Apellido);

-- =============================================
-- DATOS DE PRUEBA
-- =============================================

INSERT INTO EZ_Revistas (NombreRevista, ISSN, Editorial, FactorImpacto) VALUES
('Nature', '0028-0836', 'Nature Publishing Group', 42.778),
('Science', '0036-8075', 'AAAS', 41.845);

INSERT INTO EZ_Autores (Nombre, Apellido, Email, Institucion) VALUES
('Estefany', 'Zambrano', 'estefany.zambrano@universidad.edu', 'Universidad Nacional'),
('María', 'González', 'maria.gonzalez@universidad.edu', 'Universidad Nacional');

INSERT INTO EZ_Articulos (Titulo, Resumen, FechaPublicacion, DOI, PalabrasClave, RevistaID, TipoDocumento) VALUES
('Redes Neuronales en Medicina', 'Aplicación de IA en diagnóstico médico', '2024-03-15', '10.1000/ejemplo.001', 'inteligencia artificial, medicina', 1, 'Artículo'),
('Seguridad en Cloud Computing', 'Análisis de vulnerabilidades en la nube', '2023-11-20', '10.1000/ejemplo.002', 'cloud, seguridad', 2, 'Artículo');

-- =============================================
-- VERIFICACIÓN
-- =============================================

PRINT 'Base de datos creada exitosamente';
SELECT 'EZ_Articulos' AS Tabla, COUNT(*) AS Registros FROM EZ_Articulos;

USE Estefany_Zambrano;
SELECT * FROM EZ_Articulos;