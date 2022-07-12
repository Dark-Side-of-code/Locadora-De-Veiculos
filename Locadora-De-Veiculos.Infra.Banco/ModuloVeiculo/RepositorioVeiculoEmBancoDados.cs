using Locadora_De_Veiculos.Dominio.ModuloVeiculo;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Banco.ModuloVeiculo
{
    public class RepositorioVeiculoEmBancoDados : RepositorioBase<Veiculo, MapeadorVeiculo>,
        IRepositorioVeiculo
    {
        protected override string sqlInserir =>
        @"INSERT INTO [TBVEICULO]
           (
            [ID],
		    [MODELO],
            [PLACA],
            [MARCA],
            [COR],
		    [TIPO_COMBUSTIVEL],
            [CAPACIDADE_TANQUE],
            [ANO],
            [KM_TOTAL],
            [CATEGORIA_ID]
		   )
     VALUES
           (
            @ID,
            @MODELO,
            @PLACA,
            @MARCA,
            @COR,
			@TIPO_COMBUSTIVEL,
            @CAPACIDADE_TANQUE,
            @ANO,
			@KM_TOTAL,
            @CATEGORIA_ID
		   );";

        protected override string sqlEditar =>
        @"UPDATE [TBVEICULO]
            SET 
                [MODELO] = @MODELO,
                [PLACA] = @PLACA,
                [MARCA] = @MARCA,
                [COR] = @COR,
		        [TIPO_COMBUSTIVEL] = @TIPO_COMBUSTIVEL,
                [CAPACIDADE_TANQUE] = @CAPACIDADE_TANQUE,
                [ANO] = @ANO,
                [KM_TOTAL] = @KM_TOTAL,
                [CATEGORIA_ID] = @CATEGORIA_ID
            WHERE [ID] = @ID";

        protected override string sqlExcluir =>
        @"DELETE FROM [TBVEICULO]
            WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
        @"SELECT
             VEICULO.ID
            ,VEICULO.MODELO
			,VEICULO.PLACA
			,VEICULO.MARCA
			,VEICULO.COR
			,VEICULO.TIPO_COMBUSTIVEL
			,VEICULO.CAPACIDADE_TANQUE
			,VEICULO.ANO
			,VEICULO.KM_TOTAL

			,CATEGORIAVEICULO.ID CATEGORIA_ID
			,CATEGORIAVEICULO.NOME CATEGORIA_NOME
        FROM
            TBVEICULO VEICULO INNER JOIN TBCATEGORIAVEICULO CATEGORIAVEICULO
        ON
            VEICULO.CATEGORIA_ID = CATEGORIAVEICULO.ID
        WHERE 
            VEICULO.ID = @ID";

        protected override string sqlSelecionarTodos =>
        @"SELECT
             VEICULO.ID
            ,VEICULO.MODELO
			,VEICULO.PLACA
			,VEICULO.MARCA
			,VEICULO.COR
			,VEICULO.TIPO_COMBUSTIVEL
			,VEICULO.CAPACIDADE_TANQUE
			,VEICULO.ANO
			,VEICULO.KM_TOTAL

			,CATEGORIAVEICULO.ID CATEGORIA_ID
			,CATEGORIAVEICULO.NOME CATEGORIA_NOME
        FROM
            TBVEICULO VEICULO INNER JOIN TBCATEGORIAVEICULO CATEGORIAVEICULO
        ON
            VEICULO.CATEGORIA_ID = CATEGORIAVEICULO.ID";

        protected string sqlSelecionarPorPlaca =>
        @"SELECT
             VEICULO.ID
            ,VEICULO.MODELO
			,VEICULO.PLACA
			,VEICULO.MARCA
			,VEICULO.COR
			,VEICULO.TIPO_COMBUSTIVEL
			,VEICULO.CAPACIDADE_TANQUE
			,VEICULO.ANO
			,VEICULO.KM_TOTAL

			,CATEGORIAVEICULO.ID CATEGORIA_ID
			,CATEGORIAVEICULO.NOME CATEGORIA_NOME
        FROM
            TBVEICULO VEICULO INNER JOIN TBCATEGORIAVEICULO CATEGORIAVEICULO
        ON
            VEICULO.CATEGORIA_ID = CATEGORIAVEICULO.ID
        WHERE
            VEICULO.PLACA = @PLACA";
        public Veiculo SelecionarVeiculoPorPlaca(string placa)
        {
            return SelecionarPorParametro(sqlSelecionarPorPlaca, new SqlParameter("PLACA", placa));
        }
    }
}
