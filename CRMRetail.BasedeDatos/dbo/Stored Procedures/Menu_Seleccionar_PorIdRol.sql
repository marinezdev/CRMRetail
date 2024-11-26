-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 23/04/21
-- Description:	Selecciona un menu por un rol
-- =============================================
CREATE PROCEDURE [dbo].[Menu_Seleccionar_PorIdRol]
	-- Add the parameters for the stored procedure here
	@idrol INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT mn.idjquery, mn.ruta, mn.icono, mn.nombre 
    FROM menuroles mr 
    INNER JOIN menu mn ON mn.id = mr.idmenu 
    WHERE mr.idrol = @idrol 
    AND mn.activo=1 
    AND mr.activo=1
END
