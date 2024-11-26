-- =============================================
-- Author:		José Luis Villarreal Ruiz
-- Create date: 20/05/21
-- Description:	Slecciona cuántas ordenes está con backorder pendiente
-- =============================================
CREATE PROCEDURE [dbo].[Ventas_Seleccionar_BackOrderActivo] 
	-- Add the parameters for the stored procedure here	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(id) AS cuantos 
	FROM ventas 
	WHERE backorder=1 
	AND estado=0
END