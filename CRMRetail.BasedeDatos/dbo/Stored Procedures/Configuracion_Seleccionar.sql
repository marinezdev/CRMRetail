-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 26/04/21
-- Description:	Obtiene todas las configuraciones de las empresas agregadas
-- =============================================
CREATE PROCEDURE Configuracion_Seleccionar 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, nombre FROM configuracion
END
