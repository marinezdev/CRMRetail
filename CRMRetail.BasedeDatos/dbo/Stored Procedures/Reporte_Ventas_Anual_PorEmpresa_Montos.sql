-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 05/05/21
-- Description:	Obtiene los montos por empresa anual
-- =============================================
CREATE PROCEDURE [dbo].[Reporte_Ventas_Anual_PorEmpresa_Montos]
	-- Add the parameters for the stored procedure here
	@idempresa INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ISNULL(SUM(vp.precio*vp.cantidad),0) AS Monto 
	FROM ventasproductos vp
	INNER JOIN productos pr ON pr.id=vp.idproducto
	INNER JOIN ventas vt ON vt.id=vp.idventa
	INNER JOIN usuarios us ON us.id=vt.vendedor
	WHERE YEAR(vp.fecha) = YEAR(GETDATE())
	AND us.empresa = @idempresa
	AND vt.estado=0
END
