-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 29/04/21
-- Description:	Selecciona todos los registros
-- =============================================
CREATE PROCEDURE [dbo].[Ventas_Seleccionar_PorIdUsuario]
	@idusuario INT 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @idrol INT;
	SELECT @idrol=idrol FROM usuariosroles WHERE idusuario=@idusuario;
	IF (@idrol = 2)
		BEGIN
			SELECT vt.id, vt.idcliente, vt.fecha, vt.tipo, tv.nombre AS TipoVenta, vt.entrega,
			cl.nombre, cl.apellidopaterno, cl.apellidomaterno, cl.rfc,
			us.id AS vendedor,
			--SUM(pd.preciopublico) AS monto
			SUM(vp.precio*vp.cantidad) AS monto
			FROM ventas vt
			INNER JOIN clientes cl ON cl.id=vt.idcliente
			INNER JOIN TipoVenta tv ON  tv.id=vt.tipo
			INNER JOIN usuarios us ON us.id=vt.vendedor
			INNER JOIN ventasproductos vp ON vp.idventa=vt.id
			INNER JOIN productos pd ON pd.id=vp.idproducto
			WHERE vt.Estado=0
			GROUP BY vt.id, vt.idcliente, vt.tipo, vt.fecha, tv.nombre, vt.entrega, cl.nombre, cl.apellidopaterno, cl.apellidomaterno, cl.rfc, us.id
			ORDER BY vt.fecha DESC
		END
	ELSE IF (@idrol > 2)
		BEGIN
			SELECT vt.id, vt.idcliente, vt.fecha, vt.tipo, tv.nombre AS TipoVenta, vt.entrega,
			cl.nombre, cl.apellidopaterno, cl.apellidomaterno, cl.rfc,
			us.id AS vendedor,
			--SUM(pd.preciopublico) AS monto
			SUM(vp.precio*vp.cantidad) AS monto
			FROM ventas vt
			INNER JOIN clientes cl ON cl.id=vt.idcliente
			INNER JOIN TipoVenta tv ON  tv.id=vt.tipo
			INNER JOIN usuarios us ON us.id=vt.vendedor
			INNER JOIN ventasproductos vp ON vp.idventa=vt.id
			INNER JOIN productos pd ON pd.id=vp.idproducto
			WHERE vt.vendedor=@idusuario
			AND vt.Estado=0
			GROUP BY vt.id, vt.idcliente, vt.tipo, vt.fecha, tv.nombre, vt.entrega, cl.nombre, cl.apellidopaterno, cl.apellidomaterno, cl.rfc, us.id
			ORDER BY vt.fecha DESC
		END
END
