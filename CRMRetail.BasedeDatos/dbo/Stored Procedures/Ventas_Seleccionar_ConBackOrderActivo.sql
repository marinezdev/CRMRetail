-- =============================================
-- Author:		José Luis Villarreal Ruiz
-- Create date: 20/05/21
-- Description:	Obtiene el detalle de las órdenes con backup activo
-- =============================================
CREATE PROCEDURE [dbo].[Ventas_Seleccionar_ConBackOrderActivo] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT vt.id, vt.idcliente, vt.fecha, vt.tipo, tv.nombre AS TipoVenta, vt.entrega, vt.backorder,
	cl.nombre, cl.apellidopaterno, cl.apellidomaterno, cl.rfc,
	us.id AS vendedor,
	--SUM(pd.preciopublico) AS monto
	SUM(vp.precio) AS monto
	FROM ventas vt
	INNER JOIN clientes cl ON cl.id=vt.idcliente
	INNER JOIN TipoVenta tv ON  tv.id=vt.tipo
	INNER JOIN usuarios us ON us.id=vt.vendedor
	INNER JOIN ventasproductos vp ON vp.idventa=vt.id
	INNER JOIN productos pd ON pd.id=vp.idproducto
	WHERE vt.backorder=1
	AND vt.estado=0
	GROUP BY vt.id, vt.idcliente, vt.tipo, vt.fecha, tv.nombre, vt.entrega, vt.backorder, cl.nombre, cl.apellidopaterno, cl.apellidomaterno, cl.rfc, us.id
	ORDER BY vt.fecha DESC
END