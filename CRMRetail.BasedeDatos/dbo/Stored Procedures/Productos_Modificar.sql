-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 28/04/21
-- Description:	Modifica un registro
-- =============================================
CREATE PROCEDURE [dbo].[Productos_Modificar] 
	-- Add the parameters for the stored procedure here
	@nombre NVARCHAR(150),
	@sku NVARCHAR(50),
	@descripcion NVARCHAR(150),
	@categoria INT,
	@preciopublico DECIMAL(10,2),
	@preciodistribuidor DECIMAL(10,2),
	@activo BIT,
	@otroprecio1 DECIMAL(10,2),
	@otroprecio2 DECIMAL(10,2),
	@otroprecio3 DECIMAL(10,2),
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE productos 
	SET
	nombre=@nombre,
	sku=@sku,
	descripcion=@descripcion,
	categoria=@categoria,
	preciopublico=@preciopublico,
	preciodistribuidor=@preciodistribuidor,
	otroprecio1=@otroprecio1,
	otroprecio2=@otroprecio2,
	otroprecio3=@otroprecio3,
	activo=@activo
	WHERE id=@id
END
