CREATE TABLE [dbo].[Marketing] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Clave]        NVARCHAR (50)  NULL,
    [Nombre]       NVARCHAR (150) NULL,
    [Inicio]       DATETIME       NULL,
    [Fin]          DATETIME       NULL,
    [Registro]     DATETIME       CONSTRAINT [DF_Marketing_Registro] DEFAULT (getdate()) NULL,
    [Objetivo]     VARCHAR (MAX)  NULL,
    [Estado]       INT            NULL,
    [Usuario]      INT            NULL,
    [Correo]       INT            NULL,
    [Facebook]     INT            NULL,
    [Linkedin]     INT            NULL,
    [Llamada]      INT            NULL,
    [PaginaASAE]   INT            NULL,
    [Envios]       DATETIME       NULL,
    [InicioEvento] DATETIME       NULL,
    [FinEvento]    DATETIME       NULL,
    [HoraInicio]   NVARCHAR (8)   NULL,
    [HoraFin]      NVARCHAR (8)   NULL,
    [Ubicacion]    NVARCHAR (50)  NULL,
    [Descripcion]  NVARCHAR (150) NULL
);

