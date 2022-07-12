CREATE TABLE [dbo].[TbCondutor] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [Nome]       VARCHAR (300)    NOT NULL,
    [CPF]        VARCHAR (50)     NOT NULL,
    [CNH]        VARCHAR (50)     NOT NULL,
    [Validade]   DATETIME         NOT NULL,
    [Email]      VARCHAR (200)    NOT NULL,
    [Telefone]   VARCHAR (20)     NOT NULL,
    [Endereco]   VARCHAR (300)    NOT NULL,
    [Cliente_Id] INT              NOT NULL,
    CONSTRAINT [PK_TbCondutor_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

