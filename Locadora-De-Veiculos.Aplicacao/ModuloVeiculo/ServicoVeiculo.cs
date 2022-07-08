using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloVeiculo;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Aplicacao.ModuloVeiculo
{
    public class ServicoVeiculo
    {
        private IRepositorioVeiculo repositorioVeiculo;
        private ILogger logger = Log.Logger;

        public ServicoVeiculo(IRepositorioVeiculo repositorioVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
        }

        public ValidationResult Inserir(Veiculo veiculo)
        {
            logger.Information("Tentando inserir Veiculo... {@veiculo}", veiculo);

            ValidationResult resultadoValidacao = ValidarVeiculo(veiculo);

            if (resultadoValidacao.IsValid)
            {
                repositorioVeiculo.Inserir(veiculo);
                logger.Information("Veiculo {@veiculo} inserido com sucesso.", veiculo.Id);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    logger.Warning("Falha ao tentar inserir Veiculo {VeiculoNome} com a placa {Placa} -> Motivo: {erro}", veiculo.Modelo, veiculo.Placa, erro.ErrorMessage);
            return resultadoValidacao;
        }

        public ValidationResult Editar(Veiculo veiculo)
        {
            logger.Information("Tentando editar Veiculo... {@veiculo}", veiculo);
            ValidationResult resultadoValidacao = ValidarVeiculo(veiculo);

            if (resultadoValidacao.IsValid)
            {
                repositorioVeiculo.Editar(veiculo);
                logger.Information("Veiculo {@veiculo} editado com sucesso.", veiculo.Id);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    logger.Warning("Falha ao tentar editar Veiculo {VeiculoNome} com a placa {Placa} -> Motivo: {erro}", veiculo.Modelo, veiculo.Placa, erro.ErrorMessage);
            return resultadoValidacao;
        }

        private ValidationResult ValidarVeiculo(Veiculo veiculo)
        {
            var validador = new ValidadorVeiculo();

            var resultadoValidacao = validador.Validate(veiculo);

            if (PlacaDuplicado(veiculo))
                resultadoValidacao.Errors.Add(new ValidationFailure("Placa", "Placa duplicado"));

            return resultadoValidacao;
        }

        private bool PlacaDuplicado(Veiculo veiculo)
        {
            var veiculoEncontrado = repositorioVeiculo.SelecionarVeiculoPorPlaca(veiculo.Placa);

            return veiculoEncontrado != null &&
                   veiculoEncontrado.Placa == veiculo.Placa &&
                   veiculoEncontrado.Id != veiculo.Id;
        }
    }
}
