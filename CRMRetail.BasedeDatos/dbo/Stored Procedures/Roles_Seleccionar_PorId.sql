-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 22/04/21
-- Description:	Obtiene el detalle de un registro por su id
-- =============================================
CREATE PROCEDURE [dbo].[Roles_Seleccionar_PorId]
	-- Add the parameters for the stored procedure here
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, nombre,pagina,controlador,activo FROM roles WHERE id=@id
END
