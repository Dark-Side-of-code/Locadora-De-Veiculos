using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
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
    public class MapeadorPlanoDeCobranca : MapeadorBase<PlanoDeCobranca>
    {
        public override void ConfigurarParametros(PlanoDeCobranca registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            
            comando.Parameters.AddWithValue("PLANODIARIO_VALORDIARIO", registro.PlanoDiario_ValorDiario);
            comando.Parameters.AddWithValue("PLANODIARIO_VALORPORKM", registro.PlanoDiario_ValorPorKM);

            comando.Parameters.AddWithValue("PLANOKM_LIVRE_VALORDIARIO", registro.PlanoKM_Livre_ValorDiario);

            comando.Parameters.AddWithValue("PLANOKM_CONTROLADO_LIMITEDEQUILOMETRAGEM", registro.PlanoKM_controlado_LimiteDeQuilometragem);
            comando.Parameters.AddWithValue("PLANOKM_CONTROLADO_VALORDIARIO", registro.PlanoKM_controlado_ValorDiario);
            comando.Parameters.AddWithValue("PLANOKM_CONTROLADO_VALORPORKM", registro.PlanoKM_controlado_ValorPorKM);
            
            comando.Parameters.AddWithValue("CATEGORIA_ID", registro.CategoriaDeVeiculos.Id);
        }


        public override PlanoDeCobranca ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Convert.ToInt32(leitorRegistro["ID"]);
            var plano_Diario_ValorDiario = Convert.ToDouble(leitorRegistro["PLANODIARIO_VALORDIARIO"]);
            var plano_Diario_ValorPorKM = Convert.ToDouble(leitorRegistro["PLANODIARIO_VALORPORKM"]);

            var plano_Livre_ValorDiario = Convert.ToDouble(leitorRegistro["PLANOKM_LIVRE_VALORDIARIO"]);

            var planoKM_Controlado_LimiteDeQuilometragem = Convert.ToDouble(leitorRegistro["PLANOKM_CONTROLADO_LIMITEDEQUILOMETRAGEM"]);
            var planoKM_Controlado_ValorDiario = Convert.ToDouble(leitorRegistro["PLANOKM_CONTROLADO_VALORDIARIO"]);
            var planoKM_Controlado_ValorPorKm = Convert.ToDouble(leitorRegistro["PLANOKM_CONTROLADO_VALORPORKM"]);

            var idCategoria = Convert.ToInt32(leitorRegistro["ID_CATEGORIA"]);
            var nomeCategoria = Convert.ToString(leitorRegistro["NOME_CATEGORIA"]);

            var categoria = new CategoriaDeVeiculos
            {
                Id = idCategoria,
                Nome = nomeCategoria,
            };


            var planoDeCobranca = new PlanoDeCobranca
            {
                Id = id,

                PlanoDiario_ValorDiario = plano_Diario_ValorDiario,
                PlanoDiario_ValorPorKM = plano_Diario_ValorPorKM,

                PlanoKM_Livre_ValorDiario = plano_Livre_ValorDiario,

                PlanoKM_controlado_LimiteDeQuilometragem = planoKM_Controlado_LimiteDeQuilometragem,
                PlanoKM_controlado_ValorDiario = planoKM_Controlado_ValorDiario,
                PlanoKM_controlado_ValorPorKM = planoKM_Controlado_ValorPorKm,
            };

            planoDeCobranca.ConfigurarCategoria(categoria);
            return planoDeCobranca;

        }
    }
}
