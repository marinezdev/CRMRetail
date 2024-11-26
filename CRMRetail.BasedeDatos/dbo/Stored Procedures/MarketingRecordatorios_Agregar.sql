-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 15/05/21
-- Description:	Agrega un registro, devuelve el id del registro agregado
-- =============================================
CREATE PROCEDURE MarketingRecordatorios_Agregar
	-- Add the parameters for the stored procedure here
	@idcampaña INT, 
	@asunto NVARCHAR(150), 
	@cuerpo NVARCHAR(4000), 
	@fechaenvio DATETIME, 
	@enviara INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO marketingrecordatorios (idcampaña, asunto, cuerpo, fechaenvio, enviara) 
    VALUES(@idcampaña, @asunto, @cuerpo, @fechaenvio, @enviara); 
    SELECT @@IDENTITY;
END
