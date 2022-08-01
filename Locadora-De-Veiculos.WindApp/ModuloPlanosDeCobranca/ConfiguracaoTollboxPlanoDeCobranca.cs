using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.WindApp.ModuloPlanosDeCobranca
{
    public class ConfiguracaoTollboxPlanoDeCobranca : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Planos de Cobrança";

        public override string TooltipInserir => "Inserir novo Plano de Cobrança";

        public override string TooltipEditar => "Editar um Plano de Cobrança";

        public override string TooltipExcluir => "Excluir um Plano de Cobrança";

        public override bool DevolverHabilitado => false;
    }
}
