using Locadora_De_Veiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>
    {
        public Cliente()
        {

        }
        public Cliente(string nome, string cpf_cnpj, string tipo_Cliente, string email, string telefone) : this()
        {
            Nome = nome;
            CPF_CNPJ = cpf_cnpj;
            Tipo_Cliente = tipo_Cliente;
            Email = email;
            Telefone = telefone;
        }

        public string Nome { get; set; }
        public string CPF_CNPJ { get; set; }
        public string Tipo_Cliente { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Cliente cliente &&
                   Id == cliente.Id &&
                   Nome == cliente.Nome &&
                   CPF_CNPJ == cliente.CPF_CNPJ &&
                   Tipo_Cliente == cliente.Tipo_Cliente &&
                   Email == cliente.Email &&
                   Telefone == cliente.Telefone;
        }

        public Cliente Clone()
        {
            return MemberwiseClone() as Cliente;
        }

        public override string ToString()
        {
            return this.CPF_CNPJ;
        }
    }
}
