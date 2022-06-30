CREATE TABLE [dbo].[TbTaxas] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Nome]        VARCHAR (200)   NOT NULL,
    [Descricao]   VARCHAR (500)   NOT NULL,
    [Valor]       DECIMAL (18, 2) NOT NULL,
    [Diario_Fixo] VARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_TbTaxas] PRIMARY KEY CLUSTERED ([Id] ASC)
);

