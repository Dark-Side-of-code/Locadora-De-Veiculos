CREATE TABLE [dbo].[TbFuncionario] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [Nome]            VARCHAR (200)    NOT NULL,
    [Login]           VARCHAR (50)     NOT NULL,
    [Senha]           VARCHAR (50)     NOT NULL,
    [Salario]         DECIMAL (18, 2)  NOT NULL,
    [Data_admissao]   DATETIME         NOT NULL,
    [TipoFuncionario] VARCHAR (60)     NOT NULL,
    CONSTRAINT [PK_TbFuncionario_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

