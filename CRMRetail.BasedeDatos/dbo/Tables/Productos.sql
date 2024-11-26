CREATE TABLE [dbo].[Productos] (
    [Id]                 INT             IDENTITY (1, 1) NOT NULL,
    [Nombre]             NVARCHAR (150)  NULL,
    [SKU]                NVARCHAR (50)   NULL,
    [Descripcion]        NVARCHAR (150)  NULL,
    [Categoria]          INT             NULL,
    [PrecioPublico]      DECIMAL (10, 2) NULL,
    [PrecioDistribuidor] DECIMAL (10, 2) NULL,
    [Imagen]             NVARCHAR (150)  NULL,
    [Fecha]              DATETIME        CONSTRAINT [DF_Productos_Fecha] DEFAULT (getdate()) NULL,
    [Activo]             BIT             NULL,
    [OtroPrecio1]        DECIMAL (18, 2) NULL,
    [OtroPrecio2]        DECIMAL (18, 2) NULL,
    [OtroPrecio3]        DECIMAL (18, 2) NULL
);





