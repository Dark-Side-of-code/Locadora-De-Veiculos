using Locadora_De_Veiculos.WindApp.Compartilhado;

namespace Locadora_De_Veiculos.WindApp.ModuloLocacao
{
    internal class ConfiguracaoTollboxLocacao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Locacao";

        public override string TooltipInserir => "Inserir novo Locacao";

        public override string TooltipEditar => "";

        public override string TooltipExcluir => "Excluir uma Locacao existente";

        public override bool EditarHabilitado => false;
    }
}
