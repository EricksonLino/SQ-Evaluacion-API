DROP PROCEDURE IF EXISTS SP_Listar_Formularios
GO

CREATE PROCEDURE SP_Listar_Formularios
AS
BEGIN
	SELECT * FROM Formulario
END
GO

DROP PROCEDURE IF EXISTS SP_Agregar_Formulario
GO

CREATE PROCEDURE SP_Agregar_Formulario
	@Nombres VARCHAR(100),
	@Apellidos VARCHAR(100),
	@Correo VARCHAR(100),
	@Telefono VARCHAR(100),
	@RazonSocial VARCHAR(100),
	@Ruc VARCHAR(10),
	@Mensaje VARCHAR(MAX) = ''
AS
BEGIN
	IF EXISTS(SELECT * FROM Formulario WHERE Ruc = @Ruc)
	BEGIN
		SELECT 'El RUC ya existe' AS 'Mensaje';
	END
	ELSE
	BEGIN
		INSERT INTO Formulario (Nombres, Apellidos, Correo, Telefono, RazonSocial, Ruc, Mensaje)
			VALUES (@Nombres, @Apellidos, @Correo, @Telefono, @RazonSocial, @Ruc, @Mensaje)

		SELECT 'Formulario registrado' AS 'Mensaje';
	END
END
GO