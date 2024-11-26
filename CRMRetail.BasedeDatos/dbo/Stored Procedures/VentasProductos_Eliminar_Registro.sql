-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 03/05/21
-- Description:	Elimina un registro de la tabla
-- =============================================
CREATE PROCEDURE VentasProductos_Eliminar_Registro
	-- Add the parameters for the stored procedure here
	@idventa INT, 
	@idproducto INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM ventasproductos WHERE idventa=@idventa AND idproducto=@idproducto
END
