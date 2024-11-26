-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 30/04/21
-- Description:	Agrega los productos comprados por el cliente
-- =============================================
CREATE PROCEDURE [dbo].[VentasProductos_Agregar] 
	-- Add the parameters for the stored procedure here
	@idventa INT, 
	@idproducto INT,
	@precio DECIMAL(18,2),
	@cantidad INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Valida que el producto que se va a agregar no exista (evita que se duplique)
	IF NOT EXISTS(SELECT 1 FROM ventasproductos WHERE idproducto=@idproducto AND idventa=@idventa)
	BEGIN
		INSERT INTO ventasproductos (idventa,idproducto,cantidad,precio)
		VALUES(@idventa,@idproducto,@cantidad,@precio)
	END
END
