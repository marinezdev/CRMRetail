CREATE TABLE [dbo].[Roles] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]      NVARCHAR (50) NULL,
    [Pagina]      NVARCHAR (50) NULL,
    [Controlador] NVARCHAR (50) NULL,
    [Activo]      BIT           NULL
);

