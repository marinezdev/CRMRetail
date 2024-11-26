-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 14/05/21
-- Description:	Modifica un registro
-- =============================================
CREATE PROCEDURE MarketingClientes_Modificar
	-- Add the parameters for the stored procedure here
	@idcliente INT,
	@idcampaña INT,
	@seguimiento NVARCHAR(500),
	@ingreso INT,
	@asistencia BIT,
	@confirmacion BIT,
	@id INT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE marketingclientes SET 
	seguimiento=@seguimiento,
	ingreso=@ingreso,
	asistencia=@asistencia,
	confirmacion=@confirmacion
	WHERE id=@id

END
