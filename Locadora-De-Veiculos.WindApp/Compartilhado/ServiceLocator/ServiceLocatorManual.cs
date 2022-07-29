using Locadora_De_Veiculos.Aplicacao.ModuloCategoriasDeVeiculos;
using Locadora_De_Veiculos.Aplicacao.ModuloCliente;
using Locadora_De_Veiculos.Aplicacao.ModuloCondutor;
using Locadora_De_Veiculos.Aplicacao.ModuloFuncionario;
using Locadora_De_Veiculos.Aplicacao.ModuloLocacao;
using Locadora_De_Veiculos.Aplicacao.ModuloPlanoDeCobranca;
using Locadora_De_Veiculos.Aplicacao.ModuloTaxas;
using Locadora_De_Veiculos.Aplicacao.ModuloVeiculo;
using Locadora_De_Veiculos.Infra.Orm.Compartilhado;
using Locadora_De_Veiculos.Infra.Orm.ModuloCategoriasDeVeiculos;
using Locadora_De_Veiculos.Infra.Orm.ModuloCliente;
using Locadora_De_Veiculos.Infra.Orm.ModuloCondutor;
using Locadora_De_Veiculos.Infra.Orm.ModuloFuncionario;
using Locadora_De_Veiculos.Infra.Orm.ModuloLocacao;
using Locadora_De_Veiculos.Infra.Orm.ModuloPlanosDeCobrança;
using Locadora_De_Veiculos.Infra.Orm.ModuloTaxas;
using Locadora_De_Veiculos.Infra.Orm.ModuloVeiculo;
using Locadora_De_Veiculos.WindApp.ModuloCategoriaDeVeiculos;
using Locadora_De_Veiculos.WindApp.ModuloCliente;
using Locadora_De_Veiculos.WindApp.ModuloFuncionario;
using Locadora_De_Veiculos.WindApp.ModuloLocacao;
using Locadora_De_Veiculos.WindApp.ModuloMotorista;
using Locadora_De_Veiculos.WindApp.ModuloPlanosDeCobranca;
using Locadora_De_Veiculos.WindApp.ModuloTaxa;
using Locadora_De_Veiculos.WindApp.ModuloVeiculo;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.WindApp.Compartilhado
{
    public class ServiceLocatorManual : IServiceLocator

    {
        private Dictionary<string, ControladorBase> controladores;
        public ServiceLocatorManual()
        {
            controladores = new Dictionary<string, ControladorBase>();
            InicializarControladores();
        }
        private void InicializarControladores()
        {
            IConfiguration configuracao = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("ConfiguracaoAplicacao.json")
                 .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var contextoDadosOrm = new LocaDoraDeVeiculosDbContext(connectionString);

            var repositorioCliente = new RepositorioClienteOrm(contextoDadosOrm);
            var servicoCliente = new ServicoCliente(repositorioCliente, contextoDadosOrm);
            controladores.Add("ControladorCliente", new ControladorCliente(servicoCliente));

            var repositorioGrupoVeiculos = new RepositorioCategoriaDeVeiculosOrm(contextoDadosOrm);
            var servicoCategoriaDeVeiculos = new ServicoCategoriasDeVeiculos(repositorioGrupoVeiculos, contextoDadosOrm);
            controladores.Add("ControladorDeCategoriaDeVeiculo", new ControladorDeCategoriaDeVeiculo(servicoCategoriaDeVeiculos));

            var repositorioTaxa = new RepositorioTaxaOrm(contextoDadosOrm);
            var servicoTaxa = new ServicoTaxa(repositorioTaxa, contextoDadosOrm);
            controladores.Add("ControladorTaxa", new ControladorTaxa(servicoTaxa));

            var repositorioFuncionario = new RepositorioFuncionarioOrm(contextoDadosOrm);
            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario, contextoDadosOrm);
            controladores.Add("ControladorDeFuncionario", new ControladorDeFuncionario(servicoFuncionario));

            var repositorioCondutor = new RepositorioCondutorOrm(contextoDadosOrm);
            var servicoCondutor = new ServicoCondutor(repositorioCondutor, contextoDadosOrm);
            controladores.Add("ControladorCondutor", new ControladorCondutor(servicoCliente, servicoCondutor));

            var repositorioVeiculo = new RepositorioVeiculoOrm(contextoDadosOrm);
            var servicoVeiculo = new ServicoVeiculo(repositorioVeiculo, contextoDadosOrm);
            controladores.Add("ControladorVeiculo", new ControladorVeiculo(servicoCategoriaDeVeiculos, servicoVeiculo));

            var repositorioPlanoDeCobranca = new RepositorioPlanosDeCobrancaOrm(contextoDadosOrm);
            var servicoPlanoDeCobranca = new ServicoPlanoDeCobranca(repositorioPlanoDeCobranca, contextoDadosOrm);
            controladores.Add("ControladorPlanoDeCobranca", new ControladorPlanoDeCobranca(servicoCategoriaDeVeiculos, servicoPlanoDeCobranca));

            var repositorioLocacao = new RepositorioLocacaoOrm(contextoDadosOrm);
            var servicoLocacao = new ServicoLocacao(repositorioLocacao, contextoDadosOrm);
            controladores.Add("ControladorDeLocacao", new ControladorDeLocacao(servicoLocacao, servicoFuncionario, servicoCliente, servicoCondutor, servicoCategoriaDeVeiculos, servicoVeiculo, servicoPlanoDeCobranca));
        }

        public T Get<T>() where T : ControladorBase
        {
            var tipo = typeof(T);

            var nomeControlador = tipo.Name;

            return (T)controladores[nomeControlador];
        }
    }
}
