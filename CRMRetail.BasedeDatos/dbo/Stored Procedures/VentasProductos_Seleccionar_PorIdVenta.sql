-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 30/04/21
-- Description:	Obtiene el detalle de productos asociados a la venta
-- =============================================
CREATE PROCEDURE [dbo].[VentasProductos_Seleccionar_PorIdVenta] 
	-- Add the parameters for the stored procedure here
	@idventa INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT vp.idventa, vp.cantidad,
	pd.id, pd.nombre, pd.sku, pd.preciopublico, vp.precio, vp.precio 
	FROM productos pd
	INNER JOIN ventasproductos vp ON vp.idproducto=pd.id
	WHERE vp.idventa=@idventa
END
