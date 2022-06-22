CREATE TABLE [dbo].[TbCategoriaVeiculo] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Nome] VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_TbCategoriaVeiculo] PRIMARY KEY CLUSTERED ([Id] ASC)
);

