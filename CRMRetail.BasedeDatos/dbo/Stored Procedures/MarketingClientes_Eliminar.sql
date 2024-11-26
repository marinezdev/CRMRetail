-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 14/05/21
-- Description:	Elimina un cliente de una campaña
-- =============================================
CREATE PROCEDURE MarketingClientes_Eliminar 
	-- Add the parameters for the stored procedure here
	@idcliente INT, 
	@idcampaña INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM marketingclientes WHERE idcliente=@idcliente AND idcampaña=@idcampaña
END
