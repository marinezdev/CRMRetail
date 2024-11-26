CREATE TABLE [dbo].[VentasProductos] (
    [IdVenta]    INT             NULL,
    [IdProducto] INT             NULL,
    [Cantidad]   INT             NULL,
    [Precio]     DECIMAL (18, 2) NULL,
    [Fecha]      DATETIME        CONSTRAINT [DF_VentasProductos_Fecha] DEFAULT (getdate()) NULL
);

