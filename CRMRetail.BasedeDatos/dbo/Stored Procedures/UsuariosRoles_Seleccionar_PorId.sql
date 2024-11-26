-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 22/04/21
-- Description:	Selecciona todos los usuarios activos y por rol activo
-- =============================================
CREATE PROCEDURE [dbo].[UsuariosRoles_Seleccionar_PorId] 
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT us.id AS idusuario, us.nombre AS usuario, us.clave, us.correo,us.empresa, 
	rl.id AS idrol, rl.nombre AS rol, rl.pagina, rl.controlador
	FROM usuariosroles ur
	INNER JOIN usuarios us ON us.id=ur.idusuario
	INNER JOIN roles rl ON rl.id=ur.idrol
	WHERE us.id=@id
	AND us.activo = 1
	AND rl.activo=1
END
