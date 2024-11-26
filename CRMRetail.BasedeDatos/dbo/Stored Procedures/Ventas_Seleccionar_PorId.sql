-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 29/04/21
-- Description:	Obtiene el detalle de un registro
-- =============================================
CREATE PROCEDURE [dbo].[Ventas_Seleccionar_PorId]
	-- Add the parameters for the stored procedure here
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT vt.id, vt.idcliente, vt.fecha, vt.tipo, tv.nombre AS TipoVenta, vt.entrega, vt.tarjetacredito, vt.fechaentrega, vt.horaentrega, vt.backorder,
	cl.nombre, cl.apellidopaterno, cl.apellidomaterno, cl.rfc, cl.direccionfiscal, cl.direccionentrega,
	us.id AS vendedor
	FROM ventas vt
	INNER JOIN clientes cl ON cl.id=vt.idcliente
	INNER JOIN TipoVenta tv ON  tv.id=vt.tipo
	INNER JOIN usuarios us ON us.id=vt.vendedor
	WHERE vt.id=@id
END
