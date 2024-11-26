-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 28/04/21
-- Description:	Agrega un nuevo registro
-- =============================================
CREATE PROCEDURE [dbo].[Productos_Agregar] 
	-- Add the parameters for the stored procedure here
	@nombre NVARCHAR(150),
	@sku NVARCHAR(50),
	@descripcion NVARCHAR(150),
	@categoria INT,
	@imagen NVARCHAR(150),
	@preciopublico DECIMAL(10,2),
	@preciodistribuidor DECIMAL(10,2),
	@otroprecio1 DECIMAL(10,2),
	@otroprecio2 DECIMAL(10,2),
	@otroprecio3 DECIMAL(10,2),
	@activo BIT,
	@respuesta INT OUTPUT 	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF NOT EXISTS(SELECT 1 FROM productos WHERE sku=@sku)
	BEGIN
		INSERT INTO productos (nombre,sku,descripcion,categoria,imagen,preciopublico,preciodistribuidor,activo,otroprecio1,otroprecio2,otroprecio3) 
		VALUES (@nombre,@sku,@descripcion,@categoria,@imagen,@preciopublico,@preciodistribuidor,@activo,@otroprecio1,@otroprecio2,@otroprecio3)
		SET @respuesta = @@IDENTITY
	END
	ELSE 
		SET @respuesta = 2
END
