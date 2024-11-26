-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 14/05/21
-- Description:	Selecciona el detalle del registro
-- =============================================
CREATE PROCEDURE [dbo].[Marketing_Seleccionar_PorId] 
	-- Add the parameters for the stored procedure here
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id,clave,nombre,inicio,fin,registro,objetivo,estado,usuario,correo,facebook,linkedin,llamada,paginaasae,
	envios,inicioevento,finevento,horainicio,horafin,ubicacion,descripcion
	FROM marketing
	WHERE id=@id
END
