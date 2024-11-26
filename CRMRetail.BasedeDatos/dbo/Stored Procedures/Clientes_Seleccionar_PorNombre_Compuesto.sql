-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 29/04/21
-- Description:	Selecciona los nombres completos de los clientes a mostrar en una lista
-- =============================================
CREATE PROCEDURE [dbo].[Clientes_Seleccionar_PorNombre_Compuesto]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, nombre + ' ' + apellidopaterno + ' ' + apellidomaterno + ' (' + rfc + ')' AS Nombre
	FROM clientes
END
