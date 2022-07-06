using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.WindApp.ModuloVeiculo
{
    public class ConfiguracaoTolBoxVeiculo : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Veiculo";

        public override string TooltipInserir => "Inserir novo Veiculo";

        public override string TooltipEditar => "Editar um Veiculo existente";

        public override string TooltipExcluir => "Excluir um Veiculo existente";
    }
}
