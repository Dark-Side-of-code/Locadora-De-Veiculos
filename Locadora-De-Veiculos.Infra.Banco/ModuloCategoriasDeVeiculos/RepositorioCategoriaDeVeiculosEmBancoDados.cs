using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloCategoriaDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Banco.ModuloCategoriasDeVeiculos
{
    public class RepositorioCategoriaDeVeiculosEmBancoDados : RepositorioBase<CategoriaDeVeiculos, MapeadorCategoriaVeiculo>,
        IRepositorioCategoriaDeVeiculos
    {
        protected override string sqlInserir =>
        @"INSERT INTO [TBCATEGORIAVEICULO]
           (
           [ID],
		   [Nome]
		   )
        VALUES
           (
            @ID,
            @NOME
		   );";

        protected override string sqlEditar =>
        @"UPDATE [TBCATEGORIAVEICULO]
            SET 
                [NOME] = @NOME
            WHERE [ID] = @ID";

        protected override string sqlExcluir =>
        @"DELETE FROM [TBCATEGORIAVEICULO]
            WHERE [ID] = @ID";
            
        protected override string sqlSelecionarPorId =>
        @"SELECT 
            [ID],       
            [NOME] 
        FROM
            [TBCATEGORIAVEICULO]
        WHERE 
            [ID] = @ID";

        protected override string sqlSelecionarTodos =>
        @"SELECT 
            [ID],       
            [NOME]  
        FROM
            [TBCATEGORIAVEICULO]";

        protected string sqlSelecionarPorNome =>
        @"SELECT 
            [ID],       
            [NOME]  
        FROM
            [TBCATEGORIAVEICULO]
        WHERE
            [NOME] = @NOME";

        public CategoriaDeVeiculos SelecionarClientePorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }
    }
}
