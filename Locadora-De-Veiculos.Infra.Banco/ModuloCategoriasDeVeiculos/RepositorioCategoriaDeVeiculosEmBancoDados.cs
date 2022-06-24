using Locadora_De_Veiculos.Dominio.ModuloCategoriaDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Banco.ModuloCategoriasDeVeiculos
{
    public class RepositorioCategoriaDeVeiculosEmBancoDados : RepositorioBase<CategoriaDeVeiculos, ValidadorDeVeiculos, MapeadorCategoriaVeiculo>
    {
        protected override string sqlInserir =>
        @"INSERT INTO [TBCATEGORIAVEICULO]
           (
		   [Nome]
		   )
        VALUES
           (
            @NOME
		   );SELECT SCOPE_IDENTITY();";

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

    }
}
