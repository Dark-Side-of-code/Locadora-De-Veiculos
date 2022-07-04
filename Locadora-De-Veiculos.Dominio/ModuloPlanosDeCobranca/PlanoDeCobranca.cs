using Locadora_De_Veiculos.Dominio.Compartilhado;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.ModuloPlanosDeCobranca
{
    public class PlanoDeCobranca : EntidadeBase<PlanoDeCobranca>
    {
        public PlanoDeCobranca()
        {

        }

        public PlanoDeCobranca(double planoDiario_ValorDiario, double planoDiario_ValorPorKM, double planoKM_Livre_ValorDiario, double planoKM_Controlado_LimiteDeQuilometragem,
           double planoKM_Controlado_ValorDiario, double planoKM_Controlado_Valor_Por_Km, CategoriaDeVeiculos categoriaDeVeiculos): this()
        {
            PlanoDiario_ValorDiario = planoDiario_ValorDiario;
            PlanoDiario_ValorPorKM = planoDiario_ValorPorKM;

            PlanoKM_Livre_ValorDiario = planoKM_Livre_ValorDiario;

            PlanoKM_controlado_LimiteDeQuilometragem = planoKM_Controlado_LimiteDeQuilometragem;
            PlanoKM_controlado_ValorDiario = planoKM_Controlado_ValorDiario;
            PlanoKM_controlado_ValorPorKM = planoKM_Controlado_Valor_Por_Km;

            CategoriaDeVeiculos = categoriaDeVeiculos;
        }


        public double PlanoDiario_ValorDiario { get; set; }

        public double PlanoDiario_ValorPorKM { get; set; }

        public double PlanoKM_Livre_ValorDiario { get; set; }

        public double PlanoKM_controlado_LimiteDeQuilometragem { get; set; }

        public double PlanoKM_controlado_ValorDiario { get; set; }

        public double PlanoKM_controlado_ValorPorKM { get; set; }
       
        public CategoriaDeVeiculos CategoriaDeVeiculos{ get; set; }


        public override bool Equals(object obj)
        {
            return obj is PlanoDeCobranca cobranca &&
                   Id == cobranca.Id &&
                   PlanoDiario_ValorDiario == cobranca.PlanoDiario_ValorDiario &&
                   PlanoDiario_ValorPorKM == cobranca.PlanoDiario_ValorPorKM &&
                   PlanoKM_Livre_ValorDiario == cobranca.PlanoKM_Livre_ValorDiario &&
                   PlanoKM_controlado_LimiteDeQuilometragem == cobranca.PlanoKM_controlado_LimiteDeQuilometragem &&
                   PlanoKM_controlado_ValorDiario == cobranca.PlanoKM_controlado_ValorDiario &&
                   PlanoKM_controlado_ValorPorKM == cobranca.PlanoKM_controlado_ValorPorKM &&
                   EqualityComparer<CategoriaDeVeiculos>.Default.Equals(CategoriaDeVeiculos, cobranca.CategoriaDeVeiculos);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, PlanoDiario_ValorDiario, PlanoDiario_ValorPorKM, PlanoKM_Livre_ValorDiario, PlanoKM_controlado_LimiteDeQuilometragem, PlanoKM_controlado_ValorDiario, PlanoKM_controlado_ValorPorKM, CategoriaDeVeiculos);
        }

        public void ConfigurarCategoria(CategoriaDeVeiculos categoria)
        {
            if (categoria == null)
                return;

            CategoriaDeVeiculos = categoria;
        }
    }
}
