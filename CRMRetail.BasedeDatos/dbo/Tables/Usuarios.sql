CREATE TABLE [dbo].[Usuarios] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]     NVARCHAR (150) NULL,
    [Clave]      NVARCHAR (50)  NULL,
    [Contraseña] NVARCHAR (50)  NULL,
    [Correo]     NVARCHAR (150) NULL,
    [Activo]     BIT            NULL,
    [Alta]       DATETIME       CONSTRAINT [DF_Usuarios_Alta] DEFAULT (getdate()) NULL,
    [Empresa]    INT            NULL
);

