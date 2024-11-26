-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 26/04/21
-- Description:	Obtiene el detalle de un menú por su id
-- =============================================
CREATE PROCEDURE MenuRoles_Seleccionar_MenuRolPorId
	-- Add the parameters for the stored procedure here
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT mr.id, mr.idmenu, mn.nombre AS OpcionMenu, rl.id AS IdRol, rl.nombre AS Rol, mr.activo
    FROM menuroles mr 
    INNER JOIN menu mn ON mn.id = mr.idmenu 
    INNER JOIN roles rl ON rl.id = mr.idrol 
    WHERE mr.id = @id
END
