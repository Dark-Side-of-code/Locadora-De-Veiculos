﻿using Locadora_De_Veiculos.Dominio.ModuloCliente;
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
            comando.Parameters.AddWithValue("TIPO_CLIENTE", registro.Tipo_Cliente);
            comando.Parameters.AddWithValue("EMAIL", registro.Email);
            comando.Parameters.AddWithValue("TELEFONE", registro.Telefone);
        }

        public override Cliente ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Guid.Parse(leitorRegistro["ID"].ToString());
            string nome = Convert.ToString(leitorRegistro["NOME"]);
            string cpf_cnpj = Convert.ToString(leitorRegistro["CPF_CNPJ"]);
            string tipo_cliente = Convert.ToString(leitorRegistro["TIPO_CLIENTE"]);
            string email = Convert.ToString(leitorRegistro["EMAIL"]);
            string telefone = Convert.ToString(leitorRegistro["TELEFONE"]);

            return new Cliente()
            {
                Id = id,
                Nome = nome,
                CPF_CNPJ = cpf_cnpj,
                Tipo_Cliente = tipo_cliente,
                Email = email,
                Telefone = telefone
            };
        }
    }
}
