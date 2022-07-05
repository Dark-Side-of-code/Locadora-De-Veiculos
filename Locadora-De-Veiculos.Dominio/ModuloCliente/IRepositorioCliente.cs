using Locadora_De_Veiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.ModuloCliente
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        Cliente SelecionarClientePorCPF_CNPJ(string cpf_cnpj);

        Cliente SelecionarClientePorNome(string nome);
    }
}
