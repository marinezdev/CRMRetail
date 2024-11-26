CREATE TABLE [dbo].[MarketingCorreo] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [IdCampaña] INT             NULL,
    [Asunto]    NVARCHAR (200)  NULL,
    [Cuerpo]    NVARCHAR (2000) NULL
);

