using Locadora_De_Veiculos.WindApp.Compartilhado;

namespace Locadora_De_Veiculos.WindApp.ModuloLocacao
{
    internal class ConfiguracaoTollboxLocacao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Funcionario";

        public override string TooltipInserir => "Inserir novo Funcionario";

        public override string TooltipEditar => "Editar um Funcionario existente";

        public override string TooltipExcluir => "Excluir um Funcionario existente";

        public override bool EditarHabilitado => false;
    }
}
