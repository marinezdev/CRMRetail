-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 28/04/21
-- Description:	Obtiene todos los registros
-- =============================================
CREATE PROCEDURE [dbo].[Productos_Seleccionar] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, nombre, sku, descripcion, categoria, preciopublico, preciodistribuidor, imagen, fecha, activo 
	FROM productos
END
