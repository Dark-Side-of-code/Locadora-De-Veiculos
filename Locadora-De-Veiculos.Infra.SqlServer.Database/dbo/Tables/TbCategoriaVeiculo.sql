CREATE TABLE [dbo].[TbCategoriaVeiculo] (
    [Id]   UNIQUEIDENTIFIER NOT NULL,
    [Nome] VARCHAR (200)    NOT NULL,
    CONSTRAINT [PK_TbCategoriaVeiculo_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

