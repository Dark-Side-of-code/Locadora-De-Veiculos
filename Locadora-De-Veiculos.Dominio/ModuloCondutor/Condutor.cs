using Locadora_De_Veiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.ModuloCondutor
{
    internal class Condutor : EntidadeBase<Condutor>
    {
        public Condutor()
        {

        }
        public Condutor(string nome, string cpf, string cnh, DateTime validade_CNH, string email, string telefone, string edereco) : this()
        {
            Nome = nome;
            CPF = cpf;
            CNH = cnh;
            Validade_CNH = validade_CNH;
            Email = email;
            Telefone = telefone;
            Edereco = edereco;
        }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public string CNH { get; set; }
        public DateTime Validade_CNH { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Edereco { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Condutor Condutor &&
                   Id == Condutor.Id &&
                   Nome == Condutor.Nome &&
                   CPF == Condutor.CPF &&
                   CNH == Condutor.CNH &&
                   Validade_CNH == Condutor.Validade_CNH &&
                   Email == Condutor.Email &&
                   Telefone == Condutor.Telefone &&
                   Edereco == Condutor.Edereco;
        }

        public Condutor Clone()
        {
            return MemberwiseClone() as Condutor;
        }
    }
}
