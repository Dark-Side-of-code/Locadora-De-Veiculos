using Locadora_De_Veiculos.Dominio.ModuloCliente;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Banco.ModuloCliente
{
    public class MapeadorCliente : MapeadorBase<Cliente>
    {
        public override void ConfigurarParametros(Cliente registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("CPF_CNPJ", registro.CPF_CNPJ);
            comando.Parameters.AddWithValue("CNH", registro.CNH);
            comando.Parameters.AddWithValue("VALIDADE_CNH", registro.Validade_CNH);
            comando.Parameters.AddWithValue("TIPO_CLIENTE", registro.Tipo_Cliente);
            comando.Parameters.AddWithValue("EMAIL", registro.Email);
            comando.Parameters.AddWithValue("TELEFONE", registro.Telefone);
        }

        public override Cliente ConverterRegistro(SqlDataReader leitorRegistro)
        {
            int id = Convert.ToInt32(leitorRegistro["ID"]);
            string nome = Convert.ToString(leitorRegistro["NOME"]);
            string cpf_cnpj = Convert.ToString(leitorRegistro["CPF_CNPJ"]);
            string cnh = Convert.ToString(leitorRegistro["CNH"]);
            DateTime validade_cnh = Convert.ToDateTime(leitorRegistro["VALIDADE_CNH"]);
            string tipo_cliente = Convert.ToString(leitorRegistro["TIPO_CLIENTE"]);
            string email = Convert.ToString(leitorRegistro["EMAIL"]);
            string telefone = Convert.ToString(leitorRegistro["TELEFONE"]);

            return new Cliente()
            {
                Id = id,
                Nome = nome,
                CPF_CNPJ = cpf_cnpj,
                CNH = cnh,
                Validade_CNH = validade_cnh,
                Tipo_Cliente = tipo_cliente,
                Email = email,
                Telefone = telefone
            };
        }
    }
}
