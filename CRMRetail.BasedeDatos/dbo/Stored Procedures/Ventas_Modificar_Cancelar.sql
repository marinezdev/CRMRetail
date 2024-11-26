-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 21/05/21
-- Description:	Cancela una venta
-- =============================================
CREATE PROCEDURE Ventas_Modificar_Cancelar
	-- Add the parameters for the stored procedure here
	@idventa INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE ventas SET estado = 1 WHERE id=@idventa
END