using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.WindApp.ModuloFuncionario
{
    public class ConfiguracaoTollboxFuncionario : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Funcionario";

        public override string TooltipInserir => "Inserir novo Funcionario";

        public override string TooltipEditar => "Editar um Funcionario existente";

        public override string TooltipExcluir => "Excluir um Funcionario existente";

        public override bool DevolverHabilitado => false;
    }
}
