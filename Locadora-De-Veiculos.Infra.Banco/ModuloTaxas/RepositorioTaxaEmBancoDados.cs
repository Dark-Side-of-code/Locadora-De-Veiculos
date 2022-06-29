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
    public class RepositorioTaxaEmBancoDados : RepositorioBase<Taxa, ValidadorTaxa, MapeadorTaxa>
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

        public override ValidationResult Inserir(Taxa registro)
        {
            var validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(registro);

            if (ExisteCategoriaComEsteNome(registro.Nome))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome Duplicado"));

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            var mapeador = new MapeadorTaxa();

            mapeador.ConfigurarParametros(registro, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            registro.Id = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

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
