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
    public class RepositorioCategoriaDeVeiculosEmBancoDados : RepositorioBase<CategoriaDeVeiculos, ValidadorCategoriaDeVeiculos, MapeadorCategoriaVeiculo>
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

        public override ValidationResult Inserir(CategoriaDeVeiculos registro)
        {
            var validador = new ValidadorCategoriaDeVeiculos();

            var resultadoValidacao = validador.Validate(registro);

            if (ExisteCategoriaComEsteNome(registro.Nome))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome Duplicado"));

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            var mapeador = new MapeadorCategoriaVeiculo();

            mapeador.ConfigurarParametros(registro, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            registro.Id = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public bool ExisteCategoriaComEsteNome(string nome)
        {
            List<CategoriaDeVeiculos> categorias = SelecionarTodos();

            foreach(CategoriaDeVeiculos c in categorias){
                if (c.Nome == nome)
                    return true;
            }

            return false;
        }
    }
}
