using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.WindApp.ModuloCategoriaDeVeiculos
{
    internal class ConfiguracaoTollboxCategoria : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Categorias de Veículos";

        public override string TooltipInserir => "Inserir nova Categoria de Veículo";

        public override string TooltipEditar => "Editar uma Categoria de Veículo existente";

        public override string TooltipExcluir => "Excluir uma Categoria de Veículo existente";
    }
}
