-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 14/05/21
-- Description:	Agrega un nuevo registro
-- =============================================
CREATE PROCEDURE MarketingCorreo_Agregar
	-- Add the parameters for the stored procedure here
	@idcampaña INT, 
	@asunto NVARCHAR(200),
	@cuerpo NVARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO marketingcorreo (idcampaña, asunto, cuerpo) VALUES(@idcampaña, @asunto, @cuerpo)
END
