CREATE TABLE [dbo].[TbCliente] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Nome]         VARCHAR (300) NOT NULL,
    [CPF/CNPJ]     VARCHAR (50)  NOT NULL,
    [CNH]          VARCHAR (50)  NOT NULL,
    [Validade_CNH] DATETIME      NOT NULL,
    [Tipo_cliente] VARCHAR (50)  NOT NULL,
    [Email]        VARCHAR (200) NOT NULL,
    [Telefone]     VARCHAR (20)  NOT NULL,
    CONSTRAINT [PK_TbCliente] PRIMARY KEY CLUSTERED ([Id] ASC)
);

