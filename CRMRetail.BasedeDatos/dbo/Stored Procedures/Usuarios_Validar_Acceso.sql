-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 22/04/21
-- Description:	Valida si un usuario tiene acceso al sistema proporcionando su clave y contraseña
-- =============================================
CREATE PROCEDURE [dbo].[Usuarios_Validar_Acceso] 
	-- Add the parameters for the stored procedure here
	@clave VARCHAR(50), 
	@contraseña VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @idusuario INT;
	SELECT @idusuario=id FROM usuarios WHERE clave=@clave AND contraseña=@contraseña AND activo=1;
	IF (@idusuario > 0)
		BEGIN
			SELECT @idusuario;
		END
	ELSE
		SELECT 0;

END
