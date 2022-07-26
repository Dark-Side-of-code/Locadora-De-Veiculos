using Locadora_De_Veiculos.Aplicacao.ModuloCategoriasDeVeiculos;
using Locadora_De_Veiculos.Aplicacao.ModuloCliente;
using Locadora_De_Veiculos.Aplicacao.ModuloCondutor;
using Locadora_De_Veiculos.Aplicacao.ModuloFuncionario;
using Locadora_De_Veiculos.Aplicacao.ModuloPlanoDeCobranca;
using Locadora_De_Veiculos.Aplicacao.ModuloTaxas;
using Locadora_De_Veiculos.Aplicacao.ModuloVeiculo;
using Locadora_De_Veiculos.Infra.Banco.ModuloCategoriasDeVeiculos;
using Locadora_De_Veiculos.Infra.Banco.ModuloCliente;
using Locadora_De_Veiculos.Infra.Banco.ModuloCondutor;
using Locadora_De_Veiculos.Infra.Banco.ModuloFuncionario;
using Locadora_De_Veiculos.Infra.Banco.ModuloPlanosDeCobranca;
using Locadora_De_Veiculos.Infra.Banco.ModuloTaxas;
using Locadora_De_Veiculos.Infra.Banco.ModuloVeiculo;
using Locadora_De_Veiculos.WindApp.ModuloCategoriaDeVeiculos;
using Locadora_De_Veiculos.WindApp.ModuloCliente;
using Locadora_De_Veiculos.WindApp.ModuloFuncionario;
using Locadora_De_Veiculos.WindApp.ModuloMotorista;
using Locadora_De_Veiculos.WindApp.ModuloPlanosDeCobranca;
using Locadora_De_Veiculos.WindApp.ModuloTaxa;
using Locadora_De_Veiculos.WindApp.ModuloVeiculo;
using System;
using System.Collections.Generic;
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
            InicializarControladores();
        }
        private void InicializarControladores()
        {
            var repositorioCliente = new RepositorioClienteEmBancoDados();
            var repositorioGrupoVeiculos = new RepositorioCategoriaDeVeiculosEmBancoDados();
            var repositorioTaxa = new RepositorioTaxaEmBancoDados();
            var repositorioFuncionario = new RepositorioFuncionarioEmBancoDados();
            var repositorioCondutor = new RepositorioCondutorEmBancoDados();
            var repositorioVeiculo = new RepositorioVeiculoEmBancoDados();
            var repositorioPlanoDeCobranca = new RepositorioPlanosDeCobrancaEmBancoDados();

            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario);
            var servicoCliente = new ServicoCliente(repositorioCliente);
            var servicoCategoriaDeVeiculos = new ServicoCategoriasDeVeiculos(repositorioGrupoVeiculos);
            var servicoTaxa = new ServicoTaxa(repositorioTaxa);
            var servicoCondutor = new ServicoCondutor(repositorioCondutor);
            var servicoVeiculo = new ServicoVeiculo(repositorioVeiculo);
            var servicoPlanoDeCobranca = new ServicoPlanoDeCobranca(repositorioPlanoDeCobranca);

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("ControladorTaxa", new ControladorTaxa(servicoTaxa));
            controladores.Add("ControladorCliente", new ControladorCliente(servicoCliente));
            controladores.Add("ControladorDeCategoriaDeVeiculo", new ControladorDeCategoriaDeVeiculo(servicoCategoriaDeVeiculos));
            controladores.Add("ControladorDeFuncionario", new ControladorDeFuncionario(servicoFuncionario));
            controladores.Add("ControladorCondutor", new ControladorCondutor(servicoCliente, servicoCondutor));
            controladores.Add("ControladorVeiculo", new ControladorVeiculo(servicoCategoriaDeVeiculos, servicoVeiculo));
            controladores.Add("ControladorPlanoDeCobranca", new ControladorPlanoDeCobranca(servicoCategoriaDeVeiculos, servicoPlanoDeCobranca));
        }

        public T Get<T>() where T : ControladorBase
        {
            var tipo = typeof(T);

            var nomeControlador = tipo.Name;

            return (T)controladores[nomeControlador];
        }
    }
}
