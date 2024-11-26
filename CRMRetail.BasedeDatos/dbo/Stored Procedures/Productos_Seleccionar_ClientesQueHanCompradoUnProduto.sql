-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 17/05/21
-- Description:	Lista los clientes que han comprado un producto
-- =============================================
CREATE PROCEDURE [dbo].[Productos_Seleccionar_ClientesQueHanCompradoUnProduto] 
	-- Add the parameters for the stored procedure here
	@idproducto INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT cl.id, cl.nombre + ' ' + cl.apellidopaterno + ' ' + cl.apellidomaterno as cliente, vt.id as idventa
	FROM productos pr
	INNER JOIN ventasproductos vp ON vp.idproducto=pr.id
	INNER JOIN ventas vt ON vt.id=vp.idventa
	INNER JOIN clientes cl ON cl.id=vt.idcliente
	WHERE pr.id = @idproducto
END
