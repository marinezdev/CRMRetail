-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 24/04/21
-- Description:	Agrega un nuevo registro
-- =============================================
CREATE PROCEDURE [dbo].[Menu_Agregar] 
	-- Add the parameters for the stored procedure here
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
	INSERT INTO menu (idjquery,ruta,icono,nombre,activo) VALUES(@idjquery,@ruta,@icono,@nombre,@activo)
END
