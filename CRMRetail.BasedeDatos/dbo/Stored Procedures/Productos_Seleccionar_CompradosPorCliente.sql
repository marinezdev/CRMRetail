-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 17/05/21
-- Description:	Obtiene todos los productos que ha comprado un cliente
-- =============================================
CREATE PROCEDURE [dbo].[Productos_Seleccionar_CompradosPorCliente] 
	-- Add the parameters for the stored procedure here
	@idcliente INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT pr.id,pr.nombre, pr.sku, pr.preciopublico, vt.fecha, vt.tipo, vp.idventa AS idventa, vt.entrega 
	FROM productos pr
	INNER JOIN ventasproductos vp ON vp.idproducto=pr.id
	INNER JOIN ventas vt ON vt.id=vp.idventa
	INNER JOIN clientes cl ON cl.id=vt.idcliente
	WHERE vt.idcliente=@idcliente
END
