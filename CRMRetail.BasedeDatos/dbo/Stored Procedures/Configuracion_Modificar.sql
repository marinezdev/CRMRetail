-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 26/04/21
-- Description:	Modifica un registro
-- =============================================
CREATE PROCEDURE Configuracion_Modificar
	-- Add the parameters for the stored procedure here
	@nombre NVARCHAR(50), 
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE configuracion SET nombre=@nombre WHERE id=@id
END
