-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 15/05/21
-- Description:	Selecciona el detalle de un registro por su id
-- =============================================
CREATE PROCEDURE MarketingRecordatorios_Seleccionar_PorId
	-- Add the parameters for the stored procedure here
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, idcampaña, asunto, cuerpo, fechaenvio, fecharegistro, enviara 
	FROM marketingrecordatorios
	WHERE id=@id
END
