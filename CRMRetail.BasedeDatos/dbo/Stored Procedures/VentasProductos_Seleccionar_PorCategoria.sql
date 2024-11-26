-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 19/05/21
-- Description:	Obtiene las ventas por categoria
-- =============================================
CREATE PROCEDURE [dbo].[VentasProductos_Seleccionar_PorCategoria] 
	-- Add the parameters for the stored procedure here
	@idcategoria INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT vp.idventa, pd.id AS idproducto, pd.nombre, pd.sku, pd.preciopublico, vp.precio, pc.nombre AS categoria, vp.fecha
	FROM ventasproductos vp
	INNER JOIN ventas vt ON vt.id=vp.idventa
	INNER JOIN productos  pd ON pd.id=vp.idproducto
	INNER JOIN productoscategoria pc ON pc.id=pd.categoria
	WHERE pc.id=@idcategoria
	AND vt.estado=0
	ORDER BY pc.id
END