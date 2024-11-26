-- =============================================
-- Author:		José Luis Villarreal Ruiz
-- Create date: 23/04/21
-- Description:	Obtiene todas las opciones del menu
-- =============================================
CREATE PROCEDURE [dbo].[Menu_Seleccionar] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, idjquery, ruta, icono, nombre, activo FROM menu
END
