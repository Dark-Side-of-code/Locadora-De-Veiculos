using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.WindApp.ModuloTaxas
{
    public class ConfiguracaoTollboxTaxa : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Taxas";

        public override string TooltipInserir => "Inserir nova Taxa";

        public override string TooltipEditar => "Editar uma Taxa existente";

        public override string TooltipExcluir => "Excluir uma Taxa existente";

        public override bool DevolverHabilitado => false;
    }
}
