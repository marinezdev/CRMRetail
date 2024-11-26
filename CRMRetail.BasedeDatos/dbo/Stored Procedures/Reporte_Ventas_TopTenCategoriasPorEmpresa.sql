-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 11/05/21
-- Description:	Obtiene las categorías más vendidas por empresa
-- =============================================
CREATE PROCEDURE [dbo].[Reporte_Ventas_TopTenCategoriasPorEmpresa] 
	-- Add the parameters for the stored procedure here
	@idempresa INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 10 pc.nombre AS categoria , COUNT(pd.id) AS id
	FROM productos pd
	INNER JOIN productoscategoria pc ON pc.id=pd.categoria
	INNER JOIN ventasproductos vp ON vp.idproducto=pd.id
	INNER JOIN ventas vt ON vt.id=vp.idventa
	INNER JOIN usuarios us ON us.id=vt.vendedor
	WHERE us.Empresa=@idempresa
	AND MONTH(vt.fecha) = MONTH(getdate())	
	AND vt.estado=0
	GROUP BY pc.nombre
	HAVING COUNT(pd.id) >= 1
	ORDER BY id DESC
END
