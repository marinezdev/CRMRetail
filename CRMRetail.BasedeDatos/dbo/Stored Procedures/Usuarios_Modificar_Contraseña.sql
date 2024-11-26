-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 27/04/21
-- Description:	Modifica la contraseña de un usuario
-- =============================================
CREATE PROCEDURE Usuarios_Modificar_Contraseña
	-- Add the parameters for the stored procedure here
	@claveanterior NVARCHAR(50),
	@clavenueva NVARCHAR(50), 
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS(SELECT 1 FROM usuarios WHERE contraseña=@claveanterior AND Id=@id)
            BEGIN 
				UPDATE usuarios SET contraseña=@clavenueva WHERE id=@id 
			END 
            ELSE 
				BEGIN 
					SELECT 0 
				END
END
