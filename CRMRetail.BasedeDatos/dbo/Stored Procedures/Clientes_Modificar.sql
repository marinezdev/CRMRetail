-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 27/04/21
-- Description:	Modifica el registro
-- =============================================
CREATE PROCEDURE [dbo].[Clientes_Modificar] 
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
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE clientes 
	SET	
	nombre=UPPER(@nombre),
	apellidopaterno=UPPER(@apellidopaterno),
	apellidomaterno=UPPER(@apellidomaterno),
	rfc=@rfc,
	direccionfiscal=@direccionfiscal,
	direccionentrega=@direccionentrega,
	telefonofijo=@telefonofijo,
	telefonocelular=@telefonocelular,
	sexo=@sexo,
	fechanacimiento=@fechanacimiento,
	tipo=@tipo,
	origen=@origen, 
	correo=@correo,
	fisicamoral=@fisicamoral
	WHERE id=@id
END
