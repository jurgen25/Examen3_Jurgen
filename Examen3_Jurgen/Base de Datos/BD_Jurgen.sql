USE master
GO

CREATE DATABASE BD_Jurgen
GO

USE BD_Jurgen
GO

-- Tabla de Partidos Políticos
CREATE TABLE PartidosPoliticos (
    Codigo INT PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL
)

-- Insertar Partidos Políticos
INSERT INTO PartidosPoliticos (Codigo, Nombre) VALUES (1, 'PLN'), (2, 'PUSC'), (3, 'PAC')

-- Tabla de Encuestas
CREATE TABLE Encuestas (
    NumeroEncuesta INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    CorreoElectronico NVARCHAR(100) NOT NULL,
    PartidoPoliticoCodigo INT NOT NULL,
    FOREIGN KEY (PartidoPoliticoCodigo) REFERENCES PartidosPoliticos(Codigo)
)

-- Procedimiento almacenado para agregar encuestas
CREATE PROCEDURE spAgregarEncuesta
    @Nombre NVARCHAR(100),
    @FechaNacimiento DATE,
    @CorreoElectronico NVARCHAR(100),
    @PartidoPoliticoCodigo INT
AS
BEGIN
    INSERT INTO Encuestas (Nombre, FechaNacimiento, CorreoElectronico, PartidoPoliticoCodigo)
    VALUES (@Nombre, @FechaNacimiento, @CorreoElectronico, @PartidoPoliticoCodigo)
END

-- Procedimiento almacenado para obtener el reporte de encuestas
CREATE PROCEDURE spObtenerReporteEncuestas
AS
BEGIN
    SELECT e.NumeroEncuesta, e.Nombre, e.FechaNacimiento, e.CorreoElectronico, p.Nombre AS PartidoPolitico
    FROM Encuestas e
    JOIN PartidosPoliticos p ON e.PartidoPoliticoCodigo = p.Codigo
END
