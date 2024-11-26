-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 14/05/21
-- Description:	Obtiene los clientes que han comprado un producto seleccionado
-- =============================================
CREATE PROCEDURE Clientes_Seleccionar_PorIdProducto 
	-- Add the parameters for the stored procedure here
	@idproducto INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT vt.idcliente, cl.Nombre + ' ' + cl.apellidopaterno + ' ' + cl.apellidomaterno AS cliente 
	FROM ventas vt
	INNER JOIN ventasproductos vp ON vp.idventa=vt.id
	INNER JOIN clientes cl ON cl.id=vt.idcliente
	WHERE vp.idproducto=@idproducto
END
