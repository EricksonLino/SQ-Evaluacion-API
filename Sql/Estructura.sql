IF NOT EXISTS (SELECT * FROM master.dbo.sysdatabases WHERE name = 'SQ_Evaluacion')
CREATE DATABASE SQ_Evaluacion
GO

USE SQ_Evaluacion
GO

IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE name = 'Formulario' AND xtype = 'U')
CREATE TABLE Formulario
(
	Id INT IDENTITY(1, 1) NOT NULL,
	Nombres VARCHAR(100) NOT NULL,
	Apellidos VARCHAR(100) NOT NULL,
	Correo VARCHAR(100) NOT NULL,
	Telefono VARCHAR(100) NOT NULL,
	RazonSocial VARCHAR(100) NOT NULL,
	Ruc VARCHAR(10) NOT NULL,
	Mensaje VARCHAR(MAX) NOT NULL,
	CONSTRAINT PK_Formulario PRIMARY KEY (Id)
)
GO