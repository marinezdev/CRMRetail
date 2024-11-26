-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 24/04/21
-- Description:	Seleccionar un registro por su id
-- =============================================
CREATE PROCEDURE [dbo].[Usuarios_Seleccionar_PorId]
	-- Add the parameters for the stored procedure here
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT us.id,us.nombre,us.clave,us.contraseña,us.correo,us.activo,us.alta,us.empresa, 
	rl.id AS idrol
	FROM usuarios us
	INNER JOIN usuariosroles ur ON ur.idusuario=us.id
	INNER JOIN roles rl ON rl.id=ur.idrol
	WHERE us.id=@id
END
