CREATE TABLE [dbo].[Clientes] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]           NVARCHAR (50)  NULL,
    [ApellidoPaterno]  NVARCHAR (50)  NULL,
    [ApellidoMaterno]  NVARCHAR (50)  NULL,
    [RFC]              NVARCHAR (13)  NULL,
    [DireccionFiscal]  NVARCHAR (150) NULL,
    [DireccionEntrega] NVARCHAR (150) NULL,
    [TelefonoFijo]     NCHAR (10)     NULL,
    [TelefonoCelular]  NCHAR (10)     NULL,
    [Sexo]             NCHAR (1)      NULL,
    [FechaNacimiento]  DATE           NULL,
    [Tipo]             INT            NULL,
    [Origen]           INT            NULL,
    [Alta]             DATETIME       CONSTRAINT [DF_Clientes_Alta] DEFAULT (getdate()) NULL,
    [Correo]           NVARCHAR (150) NULL,
    [FisicaMoral]      INT            NULL
);

