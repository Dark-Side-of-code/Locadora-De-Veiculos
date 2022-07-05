using Locadora_De_Veiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.ModuloCondutor
{
    public interface IRepositorioCondutor : IRepositorio<Condutor>
    {
        Condutor SelecionarCondutorPorCPF(string cpf_cnpj);

        Condutor SelecionarCondutorPorCNH(string cnh);
    }
}
