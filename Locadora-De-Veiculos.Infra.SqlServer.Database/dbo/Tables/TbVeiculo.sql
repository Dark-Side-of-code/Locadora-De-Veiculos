﻿CREATE TABLE [dbo].[TbVeiculo] (
    [Id]                UNIQUEIDENTIFIER NOT NULL,
    [Modelo]            VARCHAR (300)    NOT NULL,
    [Placa]             VARCHAR (7)      NOT NULL,
    [Marca]             VARCHAR (50)     NOT NULL,
    [Cor]               VARCHAR (100)    NOT NULL,
    [Tipo_combustivel]  VARCHAR (100)    NOT NULL,
    [Capacidade_tanque] DECIMAL (18, 2)  NOT NULL,
    [Ano]               DATETIME         NOT NULL,
    [Km_total]          DECIMAL (18, 2)  NOT NULL,
    [Foto]              VARBINARY (MAX)  NULL,
    [Categoria_Id]      INT              NOT NULL,
    CONSTRAINT [PK_TbVeiculo_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

