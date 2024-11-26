-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 03/05/21
-- Description:	Obtiene los usuarios que son vendedores
-- =============================================
CREATE PROCEDURE Usuarios_Seleccionar_Vendedores
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT us.id, us.nombre 
	FROM usuarios us
	INNER JOIN usuariosroles ur ON ur.idusuario=us.id
	WHERE ur.idrol=5
END
