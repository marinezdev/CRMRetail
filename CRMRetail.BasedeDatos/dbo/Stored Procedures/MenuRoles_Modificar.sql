-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 26/04/21
-- Description:	Modifica un rol de un menu
-- =============================================
CREATE PROCEDURE MenuRoles_Modificar
	-- Add the parameters for the stored procedure here
	@id INT,
	@idmenu INT, 
	@idrol INT,
	@activo BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE menuroles SET idmenu=@idmenu, idrol=@idrol, activo=@activo WHERE id=@id
END
