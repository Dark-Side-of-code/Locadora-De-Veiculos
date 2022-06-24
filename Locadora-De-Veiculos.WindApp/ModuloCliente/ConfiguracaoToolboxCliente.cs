using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.WindApp.ModuloCliente
{
    public class ConfiguracaoToolboxCliente : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Clientes";

        public override string TooltipInserir => "Inserir novo Cliente";

        public override string TooltipEditar => "Editar um Cliente existente";

        public override string TooltipExcluir => "Excluir um Cliente existente";
    }
}
