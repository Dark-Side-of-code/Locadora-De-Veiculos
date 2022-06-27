using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloFuncionario;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Banco.ModuloFuncionario
{
    public class RepositorioFuncionarioEmBancoDados : RepositorioBase<Funcionario, ValidadorFuncionario, MapeadorFuncionario>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBFUNCIONARIO]
            (
		        [NOME],
                [LOGIN],
                [SENHA],
                [SALARIO],
                [DATA_ADMISSAO],
                [TIPOFUNCIONARIO]
		    )

            VALUES
            (
		        @NOME,
			    @LOGIN,
			    @SENHA,
			    @SALARIO,
			    @DATA_ADMISSAO,
			    @TIPOFUNCIONARIO
		    );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBFUNCIONARIO]
            SET
	            [NOME] = @NOME,
                [LOGIN] = @LOGIN,
                [SENHA] = @SENHA,
                [SALARIO] = @SALARIO,
                [DATA_ADMISSAO] = @DATA_ADMISSAO,
                [TIPOFUNCIONARIO] = @TIPOFUNCIONARIO
	        WHERE
	            ID = @ID;";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBFUNCIONARIO]
            WHERE
	             ID = @ID;";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID],
                [NOME],
                [LOGIN],
                [SENHA],
                [SALARIO],
                [DATA_ADMISSAO],
                [TIPOFUNCIONARIO]
            FROM
                [TBFUNCIONARIO]
            WHERE
                 ID = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID],
                [NOME],
                [LOGIN],
                [SENHA],
                [SALARIO],
                [DATA_ADMISSAO],
                [TIPOFUNCIONARIO]
            FROM
                [TBFUNCIONARIO]";

        public override ValidationResult Inserir(Funcionario registro)
        {
            var validador = new ValidadorFuncionario();

            var resultadoValidacao = validador.Validate(registro);

            if (ExisteFuncionarioComEsteNome(registro.Nome))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome Duplicado"));

            if (ExisteFuncionarioComEsteLogin(registro.Login))
                resultadoValidacao.Errors.Add(new ValidationFailure("Login", "Login Duplicado"));

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            var mapeador = new MapeadorFuncionario();

            mapeador.ConfigurarParametros(registro, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            registro.Id = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public override ValidationResult Editar(Funcionario registro)
        {
            var validador = new ValidadorFuncionario();

            var resultadoValidacao = validador.Validate(registro);

            if (ExisteFuncionarioComEsteNome(registro.Nome))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome Duplicado"));
           
            if (ExisteFuncionarioComEsteLogin(registro.Login))
                resultadoValidacao.Errors.Add(new ValidationFailure("Login", "Login Duplicado"));


            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            var mapeador = new MapeadorFuncionario();

            mapeador.ConfigurarParametros(registro, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }
        public bool ExisteFuncionarioComEsteNome(string nome)
        {
            List<Funcionario> funcionarios = SelecionarTodos();

            foreach(Funcionario f  in funcionarios)
            {
                if (f.Nome == nome)
                    return true;
            }

            return false;
        }

        public bool ExisteFuncionarioComEsteLogin(string login)
        {
            List<Funcionario> funcionarios = SelecionarTodos();

            foreach (Funcionario f in funcionarios)
            {
                if (f.Login == login)
                    return true;
            }

            return false;
        }
    }

}
