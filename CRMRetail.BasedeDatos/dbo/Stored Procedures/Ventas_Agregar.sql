-- =============================================
-- Author:		Jose Luis Villarreal Ruiz
-- Create date: 29/04/21
-- Description:	Agrega un registro
-- =============================================
CREATE PROCEDURE [dbo].[Ventas_Agregar]
	-- Add the parameters for the stored procedure here
	@idcliente INT,
	@fecha DATETIME,
	@tipo INT,
	@vendedor INT,
	@entrega INT,
	@tarjetacredito INT,
	@fechaentrega DATETIME,
	@horaentrega NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO ventas (idcliente,fecha,tipo,vendedor,entrega,tarjetacredito,fechaentrega,horaentrega)
	VALUES (@idcliente,@fecha,@tipo,@vendedor,@entrega,@tarjetacredito,@fechaentrega,@horaentrega);
	SELECT @@IDENTITY
END
