using Locadora_De_Veiculos.Dominio.ModuloPlanosDeCobranca;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Banco.ModuloPlanosDeCobranca
{
    public class RepositorioPlanosDeCobrancaEmBancoDados :
        RepositorioBase<PlanoDeCobranca, MapeadorPlanoDeCobranca>,
        IRepositorioPlanoDeCobranca
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TbPlanoCobranca]
            (
                [PLANODIARIO_VALORDIARIO],
                [PLANODIARIO_VALORPORKM],
                [PLANOKM_LIVRE_VALORDIARIO],
                [PLANOKM_CONTROLADO_LIMITEDEQUILOMETRAGEM],
                [PLANOKM_CONTROLADO_VALORDIARIO],
                [PLANOKM_CONTROLADO_VALORPORKM],
                [CATEGORIA_ID]
            )
            VALUES
            (
		        @PLANODIARIO_VALORDIARIO,
			    @PLANODIARIO_VALORPORKM,
			    @PLANOKM_LIVRE_VALORDIARIO,
			    @PLANOKM_CONTROLADO_LIMITEDEQUILOMETRAGEM,
			    @PLANOKM_CONTROLADO_VALORDIARIO,
			    @PLANOKM_CONTROLADO_VALORPORKM,
			    @CATEGORIA_ID  
		   );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBPLANOCOBRANCA]
            SET
                [PLANODIARIO_VALORDIARIO] = @PLANODIARIO_VALORDIARIO,
                [PLANODIARIO_VALORPORKM] = @PLANODIARIO_VALORPORKM,
                [PLANOKM_LIVRE_VALORDIARIO] = @PLANOKM_LIVRE_VALORDIARIO,
                [PLANOKM_CONTROLADO_LIMITEDEQUILOMETRAGEM] = @PLANOKM_CONTROLADO_LIMITEDEQUILOMETRAGEM,
                [PLANOKM_CONTROLADO_VALORDIARIO] = @PLANOKM_CONTROLADO_VALORDIARIO,
                [PLANOKM_CONTROLADO_VALORPORKM] = @PLANOKM_CONTROLADO_VALORPORKM,
                [CATEGORIA_ID] = @CATEGORIA_ID
            WHERE
                ID = @ID;";

        protected override string sqlExcluir =>
            @"DELETE FROM[TBPLANOCOBRANCA]
             WHERE
	              ID = ID;";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                PLANO.ID,
                PLANO.PLANODIARIO_VALORDIARIO,
                PLANO.PLANODIARIO_VALORPORKM,
                PLANO.PLANOKM_LIVRE_VALORDIARIO,
                PLANO.PLANOKM_CONTROLADO_LIMITEDEQUILOMETRAGEM,
                PLANO.PLANOKM_CONTROLADO_VALORDIARIO,
                PLANO.PLANOKM_CONTROLADO_VALORPORKM,

                CATEGORIA.ID AS ID_CATEGORIA,
		        CATEGORIA.NOME AS NOME_CATEGORIA
            FROM
                 TBPLANOCOBRANCA AS PLANO INNER JOIN TBCATEGORIAVEICULO AS CATEGORIA 
            ON 
                 PLANO.CATEGORIA_ID = CATEGORIA.ID
            WHERE
	                    PLANO.ID = PLANO.ID;";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                 PLANO.ID,
                 PLANO.PLANODIARIO_VALORDIARIO,
                 PLANO.PLANODIARIO_VALORPORKM,
                 PLANO.PLANOKM_LIVRE_VALORDIARIO,
                 PLANO.PLANOKM_CONTROLADO_LIMITEDEQUILOMETRAGEM,
                 PLANO.PLANOKM_CONTROLADO_VALORDIARIO,
                 PLANO.PLANOKM_CONTROLADO_VALORPORKM,

                 CATEGORIA.ID AS ID_CATEGORIA,
		         CATEGORIA.NOME AS NOME_CATEGORIA
            FROM
                 TBPLANOCOBRANCA AS PLANO INNER JOIN TBCATEGORIAVEICULO AS CATEGORIA 
            ON 
                 PLANO.CATEGORIA_ID = CATEGORIA.ID";

        protected  string sqlSelecionarPorIdCategoria =>
            @"SELECT 
                PLANO.ID,
                PLANO.PLANODIARIO_VALORDIARIO,
                PLANO.PLANODIARIO_VALORPORKM,
                PLANO.PLANOKM_LIVRE_VALORDIARIO,
                PLANO.PLANOKM_CONTROLADO_LIMITEDEQUILOMETRAGEM,
                PLANO.PLANOKM_CONTROLADO_VALORDIARIO,
                PLANO.PLANOKM_CONTROLADO_VALORPORKM,

                CATEGORIA.ID AS ID_CATEGORIA,
		        CATEGORIA.NOME AS NOME_CATEGORIA
            FROM
                 TBPLANOCOBRANCA AS PLANO INNER JOIN TBCATEGORIAVEICULO AS CATEGORIA 
            ON 
                 PLANO.CATEGORIA_ID = CATEGORIA.ID
            WHERE
	                   CATEGORIA.ID = CATEGORIA.ID;";


        public PlanoDeCobranca SelecionarIdCategoria(int idCategoria)
        {
            return SelecionarPorParametro(sqlSelecionarPorIdCategoria, new SqlParameter("ID_CATEGORIA", idCategoria));
        }
    }
}
