-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 22/04/21
-- Description:	Selecciona todos los registros
-- =============================================
CREATE PROCEDURE [dbo].[Roles_Seleccionar] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, nombre, pagina, controlador, activo FROM roles
END
