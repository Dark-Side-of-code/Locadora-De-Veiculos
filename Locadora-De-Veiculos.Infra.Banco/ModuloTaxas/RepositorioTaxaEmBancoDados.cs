using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloTaxas;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Banco.ModuloTaxas
{
    public class RepositorioTaxaEmBancoDados : RepositorioBase<Taxa, MapeadorTaxa>
    {
        protected override string sqlInserir =>
        @"INSERT INTO [TbTaxas]
           (
		   [Nome]
           ,[Descricao]
           ,[Valor]
           ,[Diario_Fixo]
		   )
     VALUES
           (
            @NOME,
            @DESCRICAO,
            @VALOR,
            @DIARIO_FIXO
		   );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
        @"UPDATE [TBTAXAS]
            SET 
                [NOME] = @NOME, 
                [DESCRICAO] = @DESCRICAO, 
                [VALOR] = @VALOR, 
                [DIARIO_FIXO] = @DIARIO_FIXO
            WHERE [ID] = @ID";

        protected override string sqlExcluir =>
        @"DELETE FROM [TBTAXAS]
            WHERE [ID] = @ID";

        protected override string sqlSelecionarTodos =>
        @"SELECT 
            [ID],       
            [NOME],       
            [DESCRICAO], 
            [VALOR],
            [DIARIO_FIXO]  
        FROM
            [TBTAXAS]";

        protected override string sqlSelecionarPorId =>
        @"SELECT 
            [ID],       
            [NOME],       
            [DESCRICAO], 
            [VALOR],
            [DIARIO_FIXO] 
        FROM
            [TBTAXAS]
        WHERE 
            [ID] = @ID";

        public bool ExisteCategoriaComEsteNome(string nome)
        {
            List<Taxa> categorias = SelecionarTodos();

            foreach (Taxa c in categorias)
            {
                if (c.Nome == nome)
                    return true;
            }

            return false;
        }
    }
}
