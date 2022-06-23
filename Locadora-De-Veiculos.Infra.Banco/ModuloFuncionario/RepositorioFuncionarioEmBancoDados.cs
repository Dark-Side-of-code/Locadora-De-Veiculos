using Locadora_De_Veiculos.Dominio.ModuloFuncionario;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using System;
using System.Collections.Generic;
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
    }
}
