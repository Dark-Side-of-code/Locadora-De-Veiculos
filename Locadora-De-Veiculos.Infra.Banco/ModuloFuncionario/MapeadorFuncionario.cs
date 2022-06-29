using Locadora_De_Veiculos.Dominio.ModuloFuncionario;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using System;
using System.Data.SqlClient;


namespace Locadora_De_Veiculos.Infra.Banco.ModuloFuncionario
{
    public class MapeadorFuncionario : MapeadorBase<Funcionario>
    {
        public override void ConfigurarParametros(Funcionario registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("LOGIN", registro.Login);
            comando.Parameters.AddWithValue("SENHA", registro.Senha);
            comando.Parameters.AddWithValue("SALARIO", registro.Salario);
            comando.Parameters.AddWithValue("DATA_ADMISSAO", registro.DataAdmissao);
            comando.Parameters.AddWithValue("TIPOFUNCIONARIO", registro.TipoFuncionario);
        }

        public override Funcionario ConverterRegistro(SqlDataReader leitorFuncionario)
        {
            var id = Convert.ToInt32(leitorFuncionario["ID"]);
            var nome = Convert.ToString(leitorFuncionario["NOME"]);
            var login = Convert.ToString(leitorFuncionario["LOGIN"]);
            var senha = Convert.ToString(leitorFuncionario["SENHA"]);
            var salario = Convert.ToDouble(leitorFuncionario["SALARIO"]);
            var dataAdimissao = Convert.ToDateTime(leitorFuncionario["DATA_ADMISSAO"]);
            var tipoFuncionario = Convert.ToString(leitorFuncionario["TIPOFUNCIONARIO"]);

            Funcionario funcionario = new Funcionario();
            funcionario.Id = id;
            funcionario.Nome = nome;
            funcionario.Login = login;
            funcionario.Senha = senha;
            funcionario.Salario = salario;
            funcionario.DataAdmissao = dataAdimissao;
            funcionario.TipoFuncionario = tipoFuncionario;


            return funcionario;
        }
    }
}
