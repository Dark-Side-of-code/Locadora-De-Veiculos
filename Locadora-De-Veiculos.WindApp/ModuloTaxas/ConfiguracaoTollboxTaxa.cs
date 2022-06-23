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
        public override string TipoCadastro => "Cadastro de Disciplinas";

        public override string TooltipInserir => "Inserir nova Disciplina";

        public override string TooltipEditar => "Editar uma Disciplina existente";

        public override string TooltipExcluir => "Excluir uma Disciplina existente";
    }
}
