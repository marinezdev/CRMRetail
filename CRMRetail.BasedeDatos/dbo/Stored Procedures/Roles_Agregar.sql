-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 22/04/21
-- Description:	Agrega un nuevo registro
-- =============================================
CREATE PROCEDURE [dbo].[Roles_Agregar]
	-- Add the parameters for the stored procedure here
	@nombre NVARCHAR(50),
	@pagina NVARCHAR(50),
	@controlador NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO roles (nombre,pagina,controlador,activo) VALUES(@nombre,@pagina,@controlador,1)
END
