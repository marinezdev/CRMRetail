-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 30/04/21
-- Description:	Obtiene los productos a mostrar en una lista
-- =============================================
CREATE PROCEDURE [dbo].[Productos_Seleccionar_PorNombre_Compuesto]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, SUBSTRING(nombre, 1, 60) + '... (' + sku + ')' AS Nombre
	FROM productos
	ORDER BY nombre
END
