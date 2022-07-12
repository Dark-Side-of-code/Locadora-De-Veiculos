CREATE TABLE [dbo].[TbPlanoCobranca] (
    [Id]                                       UNIQUEIDENTIFIER NOT NULL,
    [PlanoDiario_ValorDiario]                  DECIMAL (18, 2)  NOT NULL,
    [PlanoDiario_ValorPorKM]                   DECIMAL (18, 2)  NOT NULL,
    [PlanoKM_Livre_ValorDiario]                DECIMAL (18, 2)  NOT NULL,
    [PlanoKM_controlado_LimiteDeQuilometragem] DECIMAL (18, 2)  NOT NULL,
    [PlanoKM_controlado_ValorDiario]           DECIMAL (18, 2)  NOT NULL,
    [PlanoKM_controlado_ValorPorKM]            DECIMAL (18, 2)  NOT NULL,
    [Categoria_id]                             UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_TbPlanoCobranca_1] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TbPlanoCobranca_TbCategoriaDeVeiculo] FOREIGN KEY ([Categoria_id]) REFERENCES [dbo].[TbCategoriaVeiculo] ([Id])
);



