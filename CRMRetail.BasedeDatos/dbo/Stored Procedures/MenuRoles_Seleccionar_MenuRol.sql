-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 23/04/21
-- Description:	Selecciona las opciones de menu por rol
-- =============================================
CREATE PROCEDURE MenuRoles_Seleccionar_MenuRol
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT mr.id, mn.nombre AS OpcionMenu, rl.nombre AS Rol, mr.activo 
    FROM menuroles mr 
    INNER JOIN menu mn ON mn.id = mr.idmenu 
    INNER JOIN roles rl ON rl.id = mr.idrol
END
