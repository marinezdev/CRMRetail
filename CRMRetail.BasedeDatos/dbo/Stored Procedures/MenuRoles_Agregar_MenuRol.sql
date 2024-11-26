-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 26/04/21
-- Description:	Agrega un nuevo rol de menu
-- =============================================
CREATE PROCEDURE [dbo].[MenuRoles_Agregar_MenuRol]
	-- Add the parameters for the stored procedure here
	@idmenu INT, 
	@idrol INT,
	@activo BIT,
	@resultado INT OUTPUT
AS
BEGIN

    -- Insert statements for procedure here
	IF NOT EXISTS(SELECT 1 FROM menuroles WHERE idmenu=@idmenu AND idrol=@idrol)
		BEGIN
			INSERT INTO menuroles (idmenu,idrol, activo) VALUES(@idmenu,@idrol,@activo)
			SET @resultado = @@IDENTITY;
		END
	ELSE
		SET @resultado = 0;

END
