-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 11/05/21
-- Description:	Obtiene los productos comprados por cliente
-- =============================================
CREATE PROCEDURE [dbo].[Reporte_Ventas_Clientes_PorProducto]
	-- Add the parameters for the stored procedure here
	@idproducto INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--Seleccionar clientes por producto
	SELECT pr.id,pr.sku,pr.nombre,
	vp.idventa, 
	vn.fecha AS fechaventa,
	cl.nombre + ' ' + cl.apellidopaterno + ' ' + cl.apellidomaterno AS cliente
	FROM productos pr
	INNER JOIN ventasproductos vp ON vp.idproducto=pr.id
	INNER JOIN ventas vn ON vn.id=vp.idventa
	INNER JOIN clientes cl ON cl.id=vn.idcliente
	WHERE vn.estado=0  --pr.id=@idproducto
	ORDER BY pr.id
END
