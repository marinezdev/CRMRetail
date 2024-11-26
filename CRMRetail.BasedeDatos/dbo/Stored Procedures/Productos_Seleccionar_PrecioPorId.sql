-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 19/05/21
-- Description:	Obtiene el precio de un producto
-- =============================================
CREATE PROCEDURE Productos_Seleccionar_PrecioPorId
	-- Add the parameters for the stored procedure here
	@idproducto INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT preciopublico FROM productos WHERE id=@idproducto
END