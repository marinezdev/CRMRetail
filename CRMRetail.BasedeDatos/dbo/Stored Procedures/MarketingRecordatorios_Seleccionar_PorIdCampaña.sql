-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 15/05/21
-- Description:	Selecciona un registro
-- =============================================
CREATE PROCEDURE MarketingRecordatorios_Seleccionar_PorIdCampaña
	-- Add the parameters for the stored procedure here
	@idcampaña INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, idcampaña, asunto, cuerpo, fechaenvio, fecharegistro, enviara 
	FROM marketingrecordatorios 
	WHERE idcampaña=@idcampaña
END
