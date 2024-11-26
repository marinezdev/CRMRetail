-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 26/04/21
-- Description:	Obtiene el detalle de un registro
-- =============================================
CREATE PROCEDURE Configuracion_Seleccionar_PorId
	-- Add the parameters for the stored procedure here
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, nombre FROM configuracion WHERE id=@id
END
