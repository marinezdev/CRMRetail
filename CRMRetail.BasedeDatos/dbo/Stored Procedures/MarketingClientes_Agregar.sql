-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 14/05/21
-- Description:	Agrega un registro pero verifica que no exista en la tabla
-- =============================================
CREATE PROCEDURE [dbo].[MarketingClientes_Agregar] 
	-- Add the parameters for the stored procedure here
	@idcliente INT, 
	@idcampaña INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF NOT EXISTS(SELECT 1 FROM marketingclientes WHERE idcliente=@idcliente AND idcampaña=@idcampaña)
		BEGIN
			INSERT INTO marketingclientes (idcliente, idcampaña) VALUES(@idcliente, @idcampaña)
		END
END
