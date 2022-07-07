using Locadora_De_Veiculos.Dominio.ModuloCondutor;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Banco.ModuloCondutor
{
    public class RepositorioCondutorEmBancoDados :
        RepositorioBase<Condutor, MapeadorCondutor>,
        IRepositorioCondutor
    {
        protected override string sqlInserir =>
        @"INSERT INTO [TBCONDUTOR]
        (
           [NOME],
           [CPF],
           [CNH],
           [VALIDADE],
           [EMAIL],
           [TELEFONE],
           [ENDERECO],
           [CLIENTE_ID]
        )
        VALUES
        (
           @NOME,
           @CPF,
           @CNH,
           @VALIDADE_CNH,
           @EMAIL,
           @TELEFONE,
           @ENDERECO,
           @CLIENTE_ID
		);SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
        @"UPDATE [TBCONDUTOR]
        SET
            [NOME] = @NOME,
            [CPF] = @CPF,
            [CNH] = @CNH,
            [VALIDADE] = @VALIDADE_CNH,
            [EMAIL] =  @EMAIL,
            [TELEFONE] = @TELEFONE,
            [ENDERECO] = @ENDERECO,
            [CLIENTE_ID] = @CLIENTE_ID
	    WHERE
	        ID = @ID;";

        protected override string sqlExcluir =>
        @"DELETE FROM [TBCONDUTOR]
        WHERE
	            ID = @ID;";

        protected override string sqlSelecionarPorId =>
        @"SELECT 
		   TBCO.[ID],
           TBCO.[NOME],
           TBCO.[CPF],
           TBCO.[CNH],
           TBCO.[VALIDADE],
           TBCO.[EMAIL],
           TBCO.[TELEFONE],
           TBCO.[ENDERECO],

           TBCO.[CLIENTE_ID],
           TBCL.[NOME] AS CLIENTE_NOME
        FROM
            TBCONDUTOR TBCO INNER JOIN TBCLIENTE TBCL
        ON
            TBCO.CLIENTE_ID = TBCL.ID
        WHERE
                TBCO.ID = @ID";

        protected override string sqlSelecionarTodos =>
        @"SELECT 
		   TBCO.[ID],
           TBCO.[NOME],
           TBCO.[CPF],
           TBCO.[CNH],
           TBCO.[VALIDADE],
           TBCO.[EMAIL],
           TBCO.[TELEFONE],
           TBCO.[ENDERECO],

           TBCO.[CLIENTE_ID],
           TBCL.[NOME] AS CLIENTE_NOME
        FROM
            TBCONDUTOR TBCO INNER JOIN TBCLIENTE TBCL
        ON
            TBCO.CLIENTE_ID = TBCL.ID";

        protected string sqlSelecionarPorCPF =>
        @"SELECT 
		   TBCO.[ID],
           TBCO.[NOME],
           TBCO.[CPF],
           TBCO.[CNH],
           TBCO.[VALIDADE],
           TBCO.[EMAIL],
           TBCO.[TELEFONE],
           TBCO.[ENDERECO],

           TBCO.[CLIENTE_ID],
           TBCL.[NOME] AS CLIENTE_NOME
        FROM
            TBCONDUTOR TBCO INNER JOIN TBCLIENTE TBCL
        ON
            TBCO.CLIENTE_ID = TBCL.ID
        WHERE
                TBCO.CPF = @CPF";

        protected string sqlSelecionarPorCNH =>
        @"SELECT 
		   TBCO.[ID],
           TBCO.[NOME],
           TBCO.[CPF],
           TBCO.[CNH],
           TBCO.[VALIDADE],
           TBCO.[EMAIL],
           TBCO.[TELEFONE],
           TBCO.[ENDERECO],

           TBCO.[CLIENTE_ID],
           TBCL.[NOME] AS CLIENTE_NOME
        FROM
            TBCONDUTOR TBCO INNER JOIN TBCLIENTE TBCL
        ON
            TBCO.CLIENTE_ID = TBCL.ID
        WHERE
                TBCO.CNH = @CNH";

        public Condutor SelecionarCondutorPorCNH(string cnh)
        {
            return SelecionarPorParametro(sqlSelecionarPorCNH, new SqlParameter("CNH", cnh));
        }

        public Condutor SelecionarCondutorPorCPF(string cpf)
        {
            return SelecionarPorParametro(sqlSelecionarPorCPF, new SqlParameter("CPF", cpf));
        }
    }
}
