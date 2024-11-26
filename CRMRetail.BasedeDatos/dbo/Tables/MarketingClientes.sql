CREATE TABLE [dbo].[MarketingClientes] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [IdCliente]    INT            NULL,
    [IdCampaña]    INT            NULL,
    [Seguimiento]  NVARCHAR (500) NULL,
    [Ingreso]      INT            NULL,
    [Asistencia]   BIT            NULL,
    [Confirmacion] BIT            NULL
);

