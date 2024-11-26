-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 22/04/21
-- Description:	Modifica un registro por su id
-- =============================================
CREATE PROCEDURE [dbo].[Usuarios_Modificar] 
	-- Add the parameters for the stored procedure here
	@nombre NVARCHAR(150),
	@clave NVARCHAR(50),	
	--@contraseña NVARCHAR(50),
	@correo NVARCHAR(150),
	@activo BIT,
	@id INT,
	@idrol INT,
	@empresa INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	UPDATE usuarios SET nombre=@nombre, clave=@clave, correo=@correo, activo=@activo, empresa=@empresa WHERE id=@id;
	--Actualiza tambien el rol, por si se cambia
	UPDATE usuariosroles SET idrol=@idrol WHERE idusuario=@id
	SELECT 1
END
