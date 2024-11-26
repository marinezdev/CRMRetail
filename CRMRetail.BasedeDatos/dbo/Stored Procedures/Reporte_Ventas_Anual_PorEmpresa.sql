-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 05/05/21
-- Description:	Obtiene las ventas anuales por empresa
-- =============================================
CREATE PROCEDURE [dbo].[Reporte_Ventas_Anual_PorEmpresa] 
	-- Add the parameters for the stored procedure here
	@idempresa INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(vt.id) AS Conteo
	FROM ventas vt
	INNER JOIN usuarios us ON us.id=vt.vendedor
	WHERE YEAR(vt.fecha) = YEAR(GETDATE()) 
	AND us.Empresa=@idempresa
	AND vt.estado=0
END
