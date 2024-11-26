CREATE TABLE [dbo].[Ventas] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [IdCliente]      INT           NULL,
    [Fecha]          DATETIME      NULL,
    [Tipo]           INT           NULL,
    [Vendedor]       INT           NULL,
    [Entrega]        INT           NULL,
    [TarjetaCredito] INT           NULL,
    [FechaEntrega]   DATE          NULL,
    [HoraEntrega]    NVARCHAR (50) NULL,
    [BackOrder]      INT           CONSTRAINT [DF_Ventas_BackOrder] DEFAULT ((0)) NULL,
    [Estado]         INT           CONSTRAINT [DF_Ventas_Estado] DEFAULT ((0)) NULL
);





