﻿using Autofac;
using Locadora_De_Veiculos.Aplicacao.ModuloCategoriasDeVeiculos;
using Locadora_De_Veiculos.Aplicacao.ModuloCliente;
using Locadora_De_Veiculos.Aplicacao.ModuloCondutor;
using Locadora_De_Veiculos.Aplicacao.ModuloFuncionario;
using Locadora_De_Veiculos.Aplicacao.ModuloPlanoDeCobranca;
using Locadora_De_Veiculos.Aplicacao.ModuloTaxas;
using Locadora_De_Veiculos.Aplicacao.ModuloVeiculo;
using Locadora_De_Veiculos.Dominio.ModuloCategoriaDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloCliente;
using Locadora_De_Veiculos.Dominio.ModuloCondutor;
using Locadora_De_Veiculos.Dominio.ModuloFuncionario;
using Locadora_De_Veiculos.Dominio.ModuloPlanosDeCobranca;
using Locadora_De_Veiculos.Dominio.ModuloTaxas;
using Locadora_De_Veiculos.Dominio.ModuloVeiculo;
using Locadora_De_Veiculos.Infra.Banco.ModuloVeiculo;
using Locadora_De_Veiculos.Infra.Orm.ModuloCliente;
using Locadora_De_Veiculos.Infra.Orm.ModuloCondutor;
using Locadora_De_Veiculos.Infra.Orm.ModuloFuncionario;
using Locadora_De_Veiculos.Infra.Orm.ModuloPlanosDeCobrança;
using Locadora_De_Veiculos.Infra.Orm.ModuloTaxas;
using Locadora_De_Veiculos.Infra.Orm.ModuloCategoriasDeVeiculos;
using Locadora_De_Veiculos.WindApp.ModuloCategoriaDeVeiculos;
using Locadora_De_Veiculos.WindApp.ModuloCliente;
using Locadora_De_Veiculos.WindApp.ModuloFuncionario;
using Locadora_De_Veiculos.WindApp.ModuloMotorista;
using Locadora_De_Veiculos.WindApp.ModuloPlanosDeCobranca;
using Locadora_De_Veiculos.WindApp.ModuloTaxa;
using Locadora_De_Veiculos.WindApp.ModuloVeiculo;
using Locadora_De_Veiculos.Infra.Banco.ModuloPlanosDeCobranca;
using Locadora_De_Veiculos.Infra.Banco.ModuloCliente;
using Locadora_De_Veiculos.Infra.Banco.ModuloCategoriasDeVeiculos;
using Locadora_De_Veiculos.Infra.Banco.ModuloTaxas;
using Locadora_De_Veiculos.Infra.Banco.ModuloFuncionario;
using Locadora_De_Veiculos.Infra.Banco.ModuloCondutor;
using Locadora_De_Veiculos.Infra.Orm.ModuloLocacao;
using Locadora_De_Veiculos.Aplicacao.ModuloLocacao;
using Locadora_De_Veiculos.WindApp.ModuloLocacao;

namespace Locadora_De_Veiculos.WindApp.Compartilhado
{
    public class ServiceLocatorComAutofac : IServiceLocator
    {
        private readonly IContainer container;
        public ServiceLocatorComAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<RepositorioClienteOrm>().As<IRepositorioCliente>();
            builder.RegisterType<ServicoCliente>().AsSelf();
            builder.RegisterType<ControladorCliente>().AsSelf();

            builder.RegisterType<RepositorioCategoriaDeVeiculosOrm>().As<IRepositorioCategoriaDeVeiculos>();
            builder.RegisterType<ServicoCategoriasDeVeiculos>().AsSelf();
            builder.RegisterType<ControladorDeCategoriaDeVeiculo>().AsSelf();

            builder.RegisterType<RepositorioTaxaOrm>().As<IRepositorioTaxa>();
            builder.RegisterType<ServicoTaxa>().AsSelf();
            builder.RegisterType<ControladorTaxa>().AsSelf();

            builder.RegisterType<RepositorioFuncionarioOrm>().As<IRepositorioFuncionario>();
            builder.RegisterType<ServicoFuncionario>().AsSelf();
            builder.RegisterType<ControladorDeFuncionario>().AsSelf();

            builder.RegisterType<RepositorioCondutorOrm>().As<IRepositorioCondutor>();
            builder.RegisterType<ServicoCondutor>().AsSelf();
            builder.RegisterType<ControladorCondutor>().AsSelf();

            builder.RegisterType<RepositorioVeiculoEmBancoDados>().As<IRepositorioVeiculo>();
            builder.RegisterType<ServicoVeiculo>().AsSelf();
            builder.RegisterType<ControladorVeiculo>().AsSelf();

            builder.RegisterType<RepositorioPlanosDeCobrancaOrm>().As<IRepositorioPlanoDeCobranca>();
            builder.RegisterType<ServicoPlanoDeCobranca>().AsSelf();
            builder.RegisterType<ControladorPlanoDeCobranca>().AsSelf();

            builder.RegisterType<RepositorioLocacaoOrm>().As<IRepositorioPlanoDeCobranca>();
            builder.RegisterType<ServicoLocacao>().AsSelf();
            builder.RegisterType<ControladorDeLocacao>().AsSelf();

            container = builder.Build();
        }
        public T Get<T>() where T : ControladorBase
        {
            return container.Resolve<T>();
        }
    }
}
