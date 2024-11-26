-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 29/04/21
-- Description:	Cambia la imagen de un producto
-- =============================================
CREATE PROCEDURE Productos_Modificar_Imagen
	-- Add the parameters for the stored procedure here
	@imagen NVARCHAR(150), 
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE productos SET imagen=@imagen WHERE id=@id
END
