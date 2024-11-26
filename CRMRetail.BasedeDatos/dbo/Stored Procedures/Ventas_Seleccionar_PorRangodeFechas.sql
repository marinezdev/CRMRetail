-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 05/05/21
-- Description:	Busca los registros entre un rango de fechas
-- =============================================
CREATE PROCEDURE [dbo].[Ventas_Seleccionar_PorRangodeFechas]
	-- Add the parameters for the stored procedure here
	@fechainicial DATE, 
	@fechafinal DATE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT vt.id, vt.idcliente, vt.fecha, vt.tipo, tv.nombre AS TipoVenta, vt.entrega,
	cl.nombre, cl.apellidopaterno, cl.apellidomaterno, cl.rfc,
	us.id AS vendedor
	FROM ventas vt
	INNER JOIN clientes cl ON cl.id=vt.idcliente
	INNER JOIN TipoVenta tv ON  tv.id=vt.tipo
	INNER JOIN usuarios us ON us.id=vt.vendedor
	WHERE vt.fecha BETWEEN @fechainicial AND @fechafinal
	AND vt.estado=0
	ORDER BY vt.fecha DESC
END
