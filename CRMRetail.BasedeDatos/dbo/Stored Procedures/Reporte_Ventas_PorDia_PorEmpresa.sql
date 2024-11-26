-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 20/05/21
-- Description:	Obtiene cuántos productos se han vendido en el día por empresa
-- =============================================
CREATE PROCEDURE [dbo].[Reporte_Ventas_PorDia_PorEmpresa]
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
	WHERE DAY(vt.fecha) = DAY(GETDATE()) 
	AND vt.estado=0
	AND us.Empresa=@idempresa
END