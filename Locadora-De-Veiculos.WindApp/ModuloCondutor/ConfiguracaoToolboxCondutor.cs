using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.WindApp.ModuloMotorista
{
    public class ConfiguracaoToolboxCondutor : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Condutor";

        public override string TooltipInserir => "Inserir novo Condutor";

        public override string TooltipEditar => "Editar um Condutor existente";

        public override string TooltipExcluir => "Excluir um Condutor existente";

        public override bool DevolverHabilitado => false;
    }
}
