-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 17/05/2021
-- Description:	Modifica la cantidad y el precio si ambos o alguno ha cambiado
-- =============================================
CREATE PROCEDURE VentasProductos_Modificar_Precio
	-- Add the parameters for the stored procedure here
	@idventa INT, 
	@idproducto INT,
	@precio DECIMAL(18,2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE ventasproductos SET precio=@precio WHERE idventa=@idventa AND idproducto=@idproducto
END
