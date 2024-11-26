-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 14/05/21
-- Description:	Modifica una campaña
-- =============================================
CREATE PROCEDURE [dbo].[Marketing_Modificar]
	-- Add the parameters for the stored procedure here
	@clave NVARCHAR(50),
	@nombre NVARCHAR(150),
	@inicio DATETIME,
	@fin DATETIME,
	@objetivo VARCHAR(MAX),
	@correo INT,
	@facebook INT,
	@linkedin INT,
	@llamada INT,
	@paginaasae INT,
	@envios DATETIME,
	@inicioevento DATE,
	@finevento DATE,
	@horainicio NVARCHAR(8),
	@horafin NVARCHAR(8),
	@ubicacion NVARCHAR(50),
	@descripcion NVARCHAR(150),
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE marketing SET
	clave=@clave,
	nombre=@nombre,
	inicio=@inicio,
	fin=@fin,
	objetivo=@objetivo,
	correo=@correo,
	facebook=@facebook,
	linkedin=@linkedin,
	llamada=@llamada,
	paginaasae=@paginaasae,
	envios=@envios,
	inicioevento=@inicioevento,
	finevento=@finevento,
	horainicio=@horainicio,
	horafin=@horafin,
	ubicacion=@ubicacion,
	descripcion=@descripcion
	WHERE id = @id
END
