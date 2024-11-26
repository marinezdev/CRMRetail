-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 14/05/21
-- Description:	Obtiene todos los clientes de una campaña
-- =============================================
CREATE PROCEDURE [dbo].[MarketingClientes_Seleccionar_PorIdCampaña]
	-- Add the parameters for the stored procedure here
	@idcampaña INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT cl.id, cl.nombre + ' ' + cl.ApellidoPaterno + ' ' + cl.apellidomaterno AS nombre,
	cl.correo
	FROM marketingclientes mc
	INNER JOIN clientes cl ON cl.id=mc.idcliente
	WHERE idcampaña=@idcampaña
END
