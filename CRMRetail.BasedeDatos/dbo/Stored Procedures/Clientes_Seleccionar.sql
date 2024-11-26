-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 27/04/21
-- Description:	Selecciona todos los registros
-- =============================================
CREATE PROCEDURE [dbo].[Clientes_Seleccionar] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id,nombre,apellidopaterno,apellidomaterno,rfc,direccionfiscal,direccionentrega,telefonofijo,telefonocelular,sexo,
	fechanacimiento,tipo,origen,alta,correo,fisicamoral 
	FROM clientes
END
