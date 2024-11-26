-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 22/04/21
-- Description:	Modifica un registro por su id
-- =============================================
CREATE PROCEDURE [dbo].[Roles_Modificar] 
	-- Add the parameters for the stored procedure here
	@nombre NVARCHAR(50),
	@pagina NVARCHAR(50),
	@controlador NVARCHAR(50),
	@activo BIT,
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if (@id <> 1)
	begin
    -- Insert statements for procedure here
	UPDATE roles SET nombre=@nombre, pagina=@pagina,controlador=@controlador,activo=@activo WHERE id=@id
	end
END
