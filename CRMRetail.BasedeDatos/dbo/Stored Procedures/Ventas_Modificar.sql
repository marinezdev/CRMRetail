-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 29/04/21
-- Description:	Modifica un registro
-- =============================================
CREATE PROCEDURE [dbo].[Ventas_Modificar]
	-- Add the parameters for the stored procedure here
	@idcliente INT,
	@tipo INT,
	@vendedor INT,
	@entrega INT,
	@tarjetacredito INT,
	@fechaentrega DATETIME,
	@horaentrega NVARCHAR(50),
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE ventas SET 
	idcliente=@idcliente,
	tipo=@tipo,
	vendedor=@vendedor,
	entrega=@entrega,
	tarjetacredito=@tarjetacredito,
	fechaentrega=@fechaentrega,
	horaentrega=@horaentrega
	WHERE id=@id
END
