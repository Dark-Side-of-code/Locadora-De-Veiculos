using Locadora_De_Veiculos.Dominio.ModuloFuncionario;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using System;
using System.Data.SqlClient;


namespace Locadora_De_Veiculos.Infra.Banco.ModuloFuncionario
{
    public class MapeadorFuncionario : MapeadorBase<Funcionario>
    {
        public override void ConfigurarParametros(Funcionario funcionario, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", funcionario.Id);
            comando.Parameters.AddWithValue("NOME", funcionario.Nome);
            comando.Parameters.AddWithValue("LOGIN", funcionario.Login);
            comando.Parameters.AddWithValue("SENHA", funcionario.Senha);
            comando.Parameters.AddWithValue("SALARIO", funcionario.Salario);
            comando.Parameters.AddWithValue("DATA_ADMISSAO", funcionario.DataAdmissao);
            comando.Parameters.AddWithValue("TIPOFUNCIONARIO", funcionario.TipoFuncionario);
        }

        public override Funcionario ConverterRegistro(SqlDataReader leitorFuncionario)
        {
            var id = Convert.ToInt32(leitorFuncionario["ID"]);
            var nome = Convert.ToString(leitorFuncionario["NOME"]);
            var login = Convert.ToString(leitorFuncionario["LOGIN"]);
            var senha = Convert.ToString(leitorFuncionario["SENHA"]);
            var salario = Convert.ToDouble(leitorFuncionario["SALARIO"]);
            var dataAdimissao = Convert.ToDateTime(leitorFuncionario["DATA_ADMISSAO"]);
            var tipoFuncionario = Convert.ToBoolean(leitorFuncionario["TIPOFUNCIONARIO"]);

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
