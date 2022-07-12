CREATE TABLE [dbo].[TbCliente] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Nome]         VARCHAR (300)    NOT NULL,
    [CPF_CNPJ]     VARCHAR (50)     NOT NULL,
    [Tipo_cliente] VARCHAR (50)     NOT NULL,
    [Email]        VARCHAR (200)    NOT NULL,
    [Telefone]     VARCHAR (20)     NOT NULL,
    CONSTRAINT [PK_TbCliente_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

