-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 15/05/21
-- Description:	Modifica un registro
-- =============================================
CREATE PROCEDURE [dbo].[MarketingRecordatorios_Modificar] 
	-- Add the parameters for the stored procedure here
	@asunto NVARCHAR(150), 
	@cuerpo NVARCHAR(4000), 
	@fechaenvio DATETIME, 
	@enviara INT,
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE marketingrecordatorios SET 
	asunto=@asunto, 
	cuerpo=@cuerpo, 
	fechaenvio=@fechaenvio, 
	enviara=@enviara 
	WHERE id=@id
END
