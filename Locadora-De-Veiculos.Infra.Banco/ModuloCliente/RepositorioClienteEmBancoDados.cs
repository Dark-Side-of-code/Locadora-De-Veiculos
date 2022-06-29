using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloCliente;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Banco.ModuloCliente
{
    public class RepositorioClienteEmBancoDados : RepositorioBase<Cliente, ValidadorCliente, MapeadorCliente>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBCLIENTE] 
                (
                    [NOME],
                    [CPF_CNPJ],
                    [CNH],
                    [VALIDADE_CNH],
                    [TIPO_CLIENTE],
                    [EMAIL],
                    [TELEFONE]
	            )
	            VALUES
                (
                    @NOME,
                    @CPF_CNPJ,
                    @CNH,
                    @VALIDADE_CNH,
                    @TIPO_CLIENTE,
                    @EMAIL,
                    @TELEFONE

                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBCLIENTE]	
		        SET
			        [NOME] = @NOME,
                    [CPF_CNPJ] = @CPF_CNPJ,
                    [CNH] = @CNH, 
                    [VALIDADE_CNH] = @VALIDADE_CNH,
                    [TIPO_CLIENTE] = @TIPO_CLIENTE,
                    [EMAIL] = @EMAIL,
                    [TELEFONE] = @TELEFONE

		        WHERE
			        [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBCLIENTE]			        
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT
                    [ID],
		            [NOME],
                    [CPF_CNPJ],
                    [CNH],
                    [VALIDADE_CNH],
                    [TIPO_CLIENTE],
                    [EMAIL],
                    [TELEFONE]
	            FROM 
		            [TBCLIENTE]
		        WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT
                    [ID],
		            [NOME],
                    [CPF_CNPJ],
                    [CNH],
                    [VALIDADE_CNH],
                    [TIPO_CLIENTE],
                    [EMAIL],
                    [TELEFONE]
	            FROM 
		            [TBCLIENTE]";

        public override ValidationResult Inserir(Cliente registro)
        {
            var validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(registro);

            if (ExisteClienteComEsteCPF_CNPJ(registro.CPF_CNPJ))
                resultadoValidacao.Errors.Add(new ValidationFailure("CPF_CNPJ", "CPF_CNPJ Duplicado"));

            if (ExisteClienteComEstaCNH(registro.CNH))
                resultadoValidacao.Errors.Add(new ValidationFailure("CNH", "CNH Duplicado"));

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            var mapeador = new MapeadorCliente();

            mapeador.ConfigurarParametros(registro, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            registro.Id = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public bool ExisteClienteComEsteCPF_CNPJ(string cpf_Cnpj)
        {
            List<Cliente> clientes = SelecionarTodos();

            foreach (Cliente f in clientes)
            {
                if (f.CPF_CNPJ == cpf_Cnpj)
                    return true;
            }

            return false;
        }
        public bool ExisteClienteComEstaCNH(string cnh)
        {
            List<Cliente> clientes = SelecionarTodos();

            foreach (Cliente f in clientes)
            {
                if (f.CNH == cnh)
                    return true;
            }

            return false;
        }

    }
}
