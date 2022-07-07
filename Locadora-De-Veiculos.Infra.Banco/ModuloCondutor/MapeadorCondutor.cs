using Locadora_De_Veiculos.Dominio.ModuloCliente;
using Locadora_De_Veiculos.Dominio.ModuloCondutor;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Banco.ModuloCondutor
{
    public class MapeadorCondutor : MapeadorBase<Condutor>
    {
        public override void ConfigurarParametros(Condutor registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("CPF", registro.CPF);
            comando.Parameters.AddWithValue("CNH", registro.CNH);
            comando.Parameters.AddWithValue("VALIDADE_CNH", registro.Validade_CNH);
            comando.Parameters.AddWithValue("EMAIL", registro.Email);
            comando.Parameters.AddWithValue("TELEFONE", registro.Telefone);
            comando.Parameters.AddWithValue("ENDEREÇO", registro.Edereco);
            comando.Parameters.AddWithValue("CLIENTE_ID", registro.Cliente.Id);
        }

        public override Condutor ConverterRegistro(SqlDataReader leitorRegistro)
        {
            int id = Convert.ToInt32(leitorRegistro["ID"]);
            string nome = Convert.ToString(leitorRegistro["NOME"]);
            string cpf_cnpj = Convert.ToString(leitorRegistro["CPF"]);
            string cnh = Convert.ToString(leitorRegistro["CNH"]);
            DateTime validade_cnh = Convert.ToDateTime(leitorRegistro["VALIDADE"]);
            string email = Convert.ToString(leitorRegistro["EMAIL"]);
            string telefone = Convert.ToString(leitorRegistro["TELEFONE"]);
            string endereco = Convert.ToString(leitorRegistro["ENDEREÇO"]);

            int numeroCliente = Convert.ToInt32(leitorRegistro["CLIENTE_ID"]);
            string nomeCliente = Convert.ToString(leitorRegistro["CLIENTE_NOME"]);

            var cliente = new Cliente()
            {
                Id = numeroCliente,
                Nome = nomeCliente
            };

            var condutor = new Condutor()
            {
                Id = id,
                Nome = nome,
                CPF = cpf_cnpj,
                CNH = cnh,
                Validade_CNH = validade_cnh,
                Email = email,
                Edereco = endereco,
                Telefone = telefone
            };

            condutor.ConfigurarCondutor(cliente);

            return condutor;
        }
    }
}
