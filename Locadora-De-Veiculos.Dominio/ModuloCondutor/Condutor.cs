using Locadora_De_Veiculos.Dominio.Compartilhado;
using Locadora_De_Veiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase<Condutor>
    {
        public Condutor()
        {

        }
        public Condutor(string nome, string cpf, string cnh, DateTime validade_CNH, string email, string telefone, string edereco, Cliente cliente) : this()
        {
            Nome = nome;
            CPF = cpf;
            CNH = cnh;
            Validade_CNH = validade_CNH;
            Email = email;
            Telefone = telefone;
            Edereco = edereco;
            Cliente = cliente;
        }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public string CNH { get; set; }
        public DateTime Validade_CNH { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Edereco { get; set; }
        public Cliente Cliente { get; set; }
        public Guid ClienteId { get; set; }

        public Condutor Clone()
        {
            return MemberwiseClone() as Condutor;
        }

        public override bool Equals(object obj)
        {
            return obj is Condutor condutor &&
                   Id == condutor.Id &&
                   Nome == condutor.Nome &&
                   CPF == condutor.CPF &&
                   CNH == condutor.CNH &&
                   Validade_CNH == condutor.Validade_CNH &&
                   Email == condutor.Email &&
                   Telefone == condutor.Telefone &&
                   Edereco == condutor.Edereco &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, condutor.Cliente);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Nome);
            hash.Add(CPF);
            hash.Add(CNH);
            hash.Add(Validade_CNH);
            hash.Add(Email);
            hash.Add(Telefone);
            hash.Add(Edereco);
            hash.Add(Cliente);
            return hash.ToHashCode();
        }

        public void ConfigurarCondutor(Cliente cliente)
        {
            if (cliente == null)
                return;

            Cliente = cliente;
            ClienteId = cliente.Id;
        }
    }
}
