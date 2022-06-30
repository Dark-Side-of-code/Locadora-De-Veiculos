using Locadora_De_Veiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.ModuloCondutor
{
    internal interface IRepositorioCondutor : IRepositorio<Condutor>
    {
        Condutor SelecionarClientePorCPF_CNPJ(string cpf_cnpj);

        Condutor SelecionarClientePorCNH(string cnh);
    }
}
