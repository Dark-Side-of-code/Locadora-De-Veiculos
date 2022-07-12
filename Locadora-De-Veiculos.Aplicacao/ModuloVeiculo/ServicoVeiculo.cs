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

        public ValidationResult Inserir(Veiculo arg)
        {
            logger.Information("Tentando inserir Veiculo... {@veiculo}", arg);

            ValidationResult resultadoValidacao = ValidarVeiculo(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioVeiculo.Inserir(arg);
                logger.Information("Veiculo {@veiculo} inserido com sucesso.", arg.Id);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    logger.Warning("Falha ao tentar inserir Veiculo {@Veiculo} -> Motivo: {erro}", arg.Id, erro.ErrorMessage);
            return resultadoValidacao;
        }

        public ValidationResult Editar(Veiculo arg)
        {
            logger.Information("Tentando editar Veiculo... {@veiculo}", arg);
            ValidationResult resultadoValidacao = ValidarVeiculo(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioVeiculo.Editar(arg);
                logger.Information("Veiculo {@veiculo} editado com sucesso.", arg.Id);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    logger.Warning("Falha ao tentar editar Veiculo {@Veiculo} -> Motivo: {erro}", arg.Id, erro.ErrorMessage);
            return resultadoValidacao;
        }

        private ValidationResult ValidarVeiculo(Veiculo arg)
        {
            var validador = new ValidadorVeiculo();

            var resultadoValidacao = validador.Validate(arg);

            if (PlacaDuplicado(arg))
                resultadoValidacao.Errors.Add(new ValidationFailure("Placa", "Placa duplicado"));

            return resultadoValidacao;
        }

        private bool PlacaDuplicado(Veiculo arg)
        {
            var veiculoEncontrado = repositorioVeiculo.SelecionarVeiculoPorPlaca(arg.Placa);

            return veiculoEncontrado != null &&
                   veiculoEncontrado.Placa == arg.Placa &&
                   veiculoEncontrado.Id != arg.Id;
        }
    }
}
