-- =============================================
-- Author:		JOse Luis Villarreal Ruiz
-- Create date: 14/05/21
-- Description:	Selecciona todos los registros
-- =============================================
CREATE PROCEDURE [dbo].[Marketing_Seleccionar] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, clave,nombre,inicio,fin,registro,objetivo,estado,usuario,correo,facebook,linkedin,llamada,paginaasae,
	envios,inicioevento,finevento,horainicio,horafin,ubicacion,descripcion
	FROM marketing
END
