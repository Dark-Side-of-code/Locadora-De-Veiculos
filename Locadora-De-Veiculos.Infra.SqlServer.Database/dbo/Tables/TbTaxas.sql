CREATE TABLE [dbo].[TbTaxas] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Nome]        VARCHAR (200)    NOT NULL,
    [Descricao]   VARCHAR (500)    NOT NULL,
    [Valor]       DECIMAL (18, 2)  NOT NULL,
    [Diario_Fixo] VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_TbTaxas_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

