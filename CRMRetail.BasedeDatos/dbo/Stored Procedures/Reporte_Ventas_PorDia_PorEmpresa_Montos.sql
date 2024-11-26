-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 20/05/21
-- Description:	Obtiene las ventas en montos por empresa por día
-- =============================================
CREATE PROCEDURE [dbo].[Reporte_Ventas_PorDia_PorEmpresa_Montos]
	-- Add the parameters for the stored procedure here
	@idempresa INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ISNULL(SUM(pr.preciopublico),0) AS Monto 
	FROM ventasproductos vp
	INNER JOIN productos pr ON pr.id=vp.idproducto
	INNER JOIN ventas vt ON vt.id=vp.idventa
	INNER JOIN usuarios us ON us.id=vt.vendedor
	WHERE DAY(vp.fecha) = DAY(GETDATE())
	AND us.empresa = @idempresa
	AND vt.estado=0
END