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
    public class RepositorioFuncionarioEmBancoDados :
        RepositorioBase<Funcionario, MapeadorFuncionario>,
        IRepositorioFuncionario
    {
        protected override string sqlInserir =>
        @"INSERT INTO [TBFUNCIONARIO]
        (
            [ID],
		    [NOME],
            [LOGIN],
            [SENHA],
            [SALARIO],
            [DATA_ADMISSAO],
            [TIPOFUNCIONARIO]
		)

        VALUES
        (
            @ID,
		    @NOME,
			@LOGIN,
			@SENHA,
			@SALARIO,
			@DATA_ADMISSAO,
			@TIPOFUNCIONARIO
		);";

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

        private string sqlSelecionarPorNome =>
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
                [NOME] = @NOME";

        private string sqlSelecionarPorUsuario =>
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
            [TIPOFUNCIONARIO] = @TIPOFUNCIONARIO";

        public Funcionario SelecionarFuncionarioPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }

        public Funcionario SelecionarFuncionarioPorUsuario(string usuario)
        {
            return SelecionarPorParametro(sqlSelecionarPorUsuario, new SqlParameter("TIPOFUNCIONARIO", usuario));
        }
    }

}
