using Locadora_De_Veiculos.Dominio.ModuloCondutor;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using System;
using System.Collections.Generic;
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
           [ENDEREÇO],
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
           @ENDEREÇO,
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
            [ENDEREÇO] = @ENDEREÇO,
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
           TBCO.[ENDEREÇO],

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
           TBCO.[ENDEREÇO],

           TBCO.[CLIENTE_ID],
           TBCL.[NOME] AS CLIENTE_NOME
        FROM
            TBCONDUTOR TBCO INNER JOIN TBCLIENTE TBCL
        ON
            TBCO.CLIENTE_ID = TBCL.ID";

        public Condutor SelecionarClientePorCNH(string cnh)
        {
            throw new NotImplementedException();
        }

        public Condutor SelecionarClientePorCPF_CNPJ(string cpf_cnpj)
        {
            throw new NotImplementedException();
        }
    }
}
