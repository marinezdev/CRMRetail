-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 20/05/21
-- Description:	Actualiza el estado del campo backorder (1 hay pendientes)
-- =============================================
CREATE PROCEDURE Ventas_Modificar_BackOrder
	-- Add the parameters for the stored procedure here
	@idventa INT,
	@backorder INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE ventas SET backorder=@backorder WHERE id=@idventa
END