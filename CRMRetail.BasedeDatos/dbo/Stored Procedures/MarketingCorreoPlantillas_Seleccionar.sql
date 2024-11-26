-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 14/05/21
-- Description:	Selecciona los registros de la tabla
-- =============================================
CREATE PROCEDURE MarketingCorreoPlantillas_Seleccionar 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, nombre, codigo FROM marketingcorreoplantillas
END
