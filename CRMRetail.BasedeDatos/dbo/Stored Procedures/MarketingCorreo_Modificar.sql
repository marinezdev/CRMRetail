-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 14/05/21
-- Description:	Modifica el registro
-- =============================================
CREATE PROCEDURE [dbo].[MarketingCorreo_Modificar] 
	-- Add the parameters for the stored procedure here
	@asunto NVARCHAR(200),
	@cuerpo NVARCHAR(2000),
	@idcampaña INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE marketingcorreo SET asunto=@asunto, cuerpo=@cuerpo WHERE idcampaña=@idcampaña
END
