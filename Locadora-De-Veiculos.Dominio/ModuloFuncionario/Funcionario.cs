using Locadora_De_Veiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public Funcionario()
        {

        }

        public Funcionario(string nome, string login, string senha, double salario, DateTime dataAdmissao, string tipoFuncionario) : this()
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Salario = salario;
            DataAdmissao = dataAdmissao;
            TipoFuncionario = tipoFuncionario;
        }
       public string Nome { get; set; }
       public string Login { get; set; }
       public string Senha { get; set; }
       public double Salario { get; set; }
       public DateTime DataAdmissao { get; set; }
        public string TipoFuncionario { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Funcionario funcionario &&
                   Id == funcionario.Id &&
                   Nome == funcionario.Nome &&
                   Login == funcionario.Login &&
                   Senha == funcionario.Senha &&
                   Salario == funcionario.Salario &&
                   DataAdmissao == funcionario.DataAdmissao &&
                   TipoFuncionario == funcionario.TipoFuncionario;
        }

        public Funcionario Clone()
        {
            return MemberwiseClone() as Funcionario;
        }
    }
}
