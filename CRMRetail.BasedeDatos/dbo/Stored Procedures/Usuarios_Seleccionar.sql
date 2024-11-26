-- =============================================
-- Author:		José Luis Villarreal Ruiz
-- Create date: 22/04/21
-- Description:	Selecciona todos los usuarios del sistema
-- =============================================
CREATE PROCEDURE [dbo].[Usuarios_Seleccionar] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT us.id,us.nombre,us.clave,us.contraseña,us.correo,us.activo,us.alta,us.empresa,
	rl.nombre AS rol
	FROM usuarios us
	INNER JOIN usuariosroles ur ON ur.IdUsuario=us.id
	INNER JOIN roles rl ON rl.id=ur.idrol
END
