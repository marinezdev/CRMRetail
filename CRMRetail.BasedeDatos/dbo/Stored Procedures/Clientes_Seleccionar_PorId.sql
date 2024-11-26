-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 27/04/21
-- Description:	Obtiene el detalle del registro
-- =============================================
CREATE PROCEDURE [dbo].[Clientes_Seleccionar_PorId]
	-- Add the parameters for the stored procedure here
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id,nombre,apellidopaterno,apellidomaterno,rfc,direccionfiscal,direccionentrega,telefonofijo,telefonocelular,sexo,
	fechanacimiento,tipo,origen,correo,fisicamoral  
	FROM clientes WHERE id=@id
END
