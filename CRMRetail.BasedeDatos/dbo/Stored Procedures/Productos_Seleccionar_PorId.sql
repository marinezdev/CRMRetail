-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 28/04/21
-- Description:	Selecciona un registro
-- =============================================
CREATE PROCEDURE [dbo].[Productos_Seleccionar_PorId] 
	-- Add the parameters for the stored procedure here
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, nombre, sku, descripcion, categoria, preciopublico, preciodistribuidor, imagen, fecha, activo, otroprecio1, otroprecio2, otroprecio3 
	FROM productos
	WHERE id=@id
END
