-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 27/04/21
-- Description:	Agrega un nuevo registro
-- =============================================
CREATE PROCEDURE [dbo].[Clientes_Agregar] 
	-- Add the parameters for the stored procedure here
	@nombre NVARCHAR(50), 
	@apellidopaterno NVARCHAR(50),
	@apellidomaterno NVARCHAR(50),
	@rfc NVARCHAR(13),
	@direccionfiscal NVARCHAR(150),
	@direccionentrega NVARCHAR(150),
	@telefonofijo  NCHAR(10),
	@telefonocelular  NCHAR(10),
	@sexo NCHAR(1),
	@fechanacimiento DATE,
	@tipo INT,
	@origen INT,
	@correo NVARCHAR(150),
	@fisicamoral INT,
	@respuesta INT OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS(SELECT rfc FROM clientes WHERE rfc=@rfc)
		SET @respuesta=0;
	ELSE
		BEGIN
			INSERT INTO clientes (nombre,apellidopaterno,apellidomaterno,rfc,direccionfiscal,direccionentrega,telefonofijo,telefonocelular,
			sexo,fechanacimiento,tipo,origen,correo,fisicamoral) 
			VALUES (UPPER(@nombre),UPPER(@apellidopaterno),UPPER(@apellidomaterno),UPPER(@rfc),@direccionfiscal,@direccionentrega,@telefonofijo,@telefonocelular,@sexo,
			@fechanacimiento,@tipo,@origen,@correo,@fisicamoral) 
			SET @respuesta=@@IDENTITY
		END
END
