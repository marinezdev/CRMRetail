-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 22/04/21
-- Description:	Agrega un nuevo registro
-- =============================================
CREATE PROCEDURE [dbo].[Usuarios_Agregar] 
	-- Add the parameters for the stored procedure here
	@nombre NVARCHAR(150),
	@clave NVARCHAR(50),
	@contraseña NVARCHAR(50),
	@correo NVARCHAR(150),
	@idrol INT,
	@empresa INT,
	@respuesta INT OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS(SELECT correo FROM usuarios WHERE correo=@correo)
		SET @respuesta = 1
	ELSE
	BEGIN
		DECLARE @idusuario INT;
		INSERT INTO usuarios (nombre,clave,contraseña,correo,activo,empresa) VALUES (@nombre,@clave,@contraseña,@correo,1,@empresa)
		SET @idusuario=@@IDENTITY;
		--Insertar en UsuariosRoles
		INSERT INTO usuariosroles (idusuario, idrol) VALUES (@idusuario,@idrol);
		SET @respuesta = 2
		SELECT @@IDENTITY 

	END
END
