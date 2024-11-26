-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 14/05/21
-- Description:	Agrega una nueva campaña, devuelve el id creado
-- =============================================
CREATE PROCEDURE [dbo].[Marketing_Agregar] 
	-- Add the parameters for the stored procedure here
	@clave NVARCHAR(50),
	@nombre NVARCHAR(150),
	@inicio DATETIME,
	@fin DATETIME,
	@objetivo VARCHAR(MAX),
	@estado INT,
	@usuario INT,
	@correo INT,
	@facebook INT,
	@linkedin INT,
	@llamada INT,
	@paginaASAE INT,
	@envios DATETIME,
	@inicioevento DATETIME,
	@finevento DATETIME,
	@horainicio NVARCHAR(8),
	@horafin NVARCHAR(8),
	@ubicacion NVARCHAR(50),
	@descripcion NVARCHAR(150),
	@respuesta INT OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO marketing (clave,nombre,inicio,fin,objetivo,estado,usuario,correo,facebook,linkedin,
	llamada,paginaasae,envios,inicioevento,finevento,horainicio,horafin,ubicacion,descripcion) 	
	VALUES(@clave,@nombre,@inicio,@fin,@objetivo,@estado,@usuario,@correo,@facebook,@linkedin,
	@llamada,@paginaASAE,@envios,@inicioevento,@finevento,@horainicio,@horafin,@ubicacion,@descripcion);
	SET @respuesta = @@IDENTITY;
END
