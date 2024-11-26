-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 26/04/21
-- Description:	Modifica un registro
-- =============================================
CREATE PROCEDURE [dbo].[Menu_Modificar]
	-- Add the parameters for the stored procedure here
	@id INT,
	@idjquery NVARCHAR(50),
	@ruta NVARCHAR(50),
	@icono NVARCHAR(50),
	@nombre NVARCHAR(50),
	@activo BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE menu SET idjquery=@idjquery,ruta=@ruta,icono=@icono,nombre=@nombre,activo=@activo WHERE id=@id
END
