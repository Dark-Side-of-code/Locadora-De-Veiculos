﻿using FluentValidation.Results;
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
    public class RepositorioClienteEmBancoDados : RepositorioBase<Cliente, MapeadorCliente>,
        IRepositorioCliente
    {
        protected override string sqlInserir =>
        @"INSERT INTO [TBCLIENTE] 
            (
                [ID],
                [NOME],
                [CPF_CNPJ],
                [TIPO_CLIENTE],
                [EMAIL],
                [TELEFONE]
	        )
	        VALUES
            (
                @ID,
                @NOME,
                @CPF_CNPJ,
                @TIPO_CLIENTE,
                @EMAIL,
                @TELEFONE

            );";

        protected override string sqlEditar =>
        @"UPDATE [TBCLIENTE]	
		    SET
			    [NOME] = @NOME,
                [CPF_CNPJ] = @CPF_CNPJ,
                [TIPO_CLIENTE] = @TIPO_CLIENTE,
                [EMAIL] = @EMAIL,
                [TELEFONE] = @TELEFONE

		    WHERE
			    [ID] = @ID";

        protected override string sqlExcluir =>
        @"DELETE FROM [TBCLIENTE]			        
		    WHERE
			    [ID] = @ID";

        protected override string sqlSelecionarPorId =>
        @"SELECT
                [ID],
		        [NOME],
                [CPF_CNPJ],
                [TIPO_CLIENTE],
                [EMAIL],
                [TELEFONE]
	        FROM 
		        [TBCLIENTE]
		    WHERE
                [ID] = @ID";

        protected override string sqlSelecionarTodos =>
        @"SELECT
                [ID],
		        [NOME],
                [CPF_CNPJ],
                [TIPO_CLIENTE],
                [EMAIL],
                [TELEFONE]
	        FROM 
		        [TBCLIENTE]";

        protected string sqlSelecionarPorCPF_CNPJ =>
        @"SELECT
                [ID],
		        [NOME],
                [CPF_CNPJ],
                [TIPO_CLIENTE],
                [EMAIL],
                [TELEFONE]
	        FROM 
		        [TBCLIENTE]
		    WHERE
                [CPF_CNPJ] = @CPF_CNPJ";

        protected string sqlSelecionarPorNome =>
        @"SELECT
                [ID],
		        [NOME],
                [CPF_CNPJ],
                [TIPO_CLIENTE],
                [EMAIL],
                [TELEFONE]
	        FROM 
		        [TBCLIENTE]
		    WHERE
                [NOME] = @NOME";

        public Cliente SelecionarClientePorCPF_CNPJ(string cpf_cnpj)
        {
            return SelecionarPorParametro(sqlSelecionarPorCPF_CNPJ, new SqlParameter("CPF_CNPJ", cpf_cnpj));
        }

        public Cliente SelecionarClientePorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }
    }
}
