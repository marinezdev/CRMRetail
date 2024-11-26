-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE VentasProductos_Modificar_Cantidad 
	-- Add the parameters for the stored procedure here
	@idventa INT, 
	@idproducto INT,
	@cantidad INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE ventasproductos SET cantidad=@cantidad WHERE idventa=@idventa AND idproducto=@idproducto
END
