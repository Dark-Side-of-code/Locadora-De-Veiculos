CREATE TABLE [dbo].[TbFuncionario] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [Nome]            VARCHAR (200)   NOT NULL,
    [Login]           VARCHAR (50)    NOT NULL,
    [Senha]           VARCHAR (50)    NOT NULL,
    [Salario]         DECIMAL (18, 2) NOT NULL,
    [Data_admissao]   DATETIME        NOT NULL,
    [TipoFuncionario] BIT             NOT NULL,
    CONSTRAINT [PK_TbFuncionario] PRIMARY KEY CLUSTERED ([Id] ASC)
);

