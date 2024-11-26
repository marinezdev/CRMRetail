CREATE TABLE [dbo].[MarketingRecordatorios] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [IdCampaña]     INT             NULL,
    [Asunto]        NVARCHAR (150)  NULL,
    [Cuerpo]        NVARCHAR (4000) NULL,
    [FechaEnvio]    DATETIME        NULL,
    [FechaRegistro] DATETIME        CONSTRAINT [DF_MarketingRecordatorio_FechaRegistro] DEFAULT (getdate()) NULL,
    [EnviarA]       INT             NULL
);

