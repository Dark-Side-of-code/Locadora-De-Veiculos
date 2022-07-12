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

        public override Funcionario ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Guid.Parse(leitorRegistro["ID"].ToString());
            var nome = Convert.ToString(leitorRegistro["NOME"]);
            var login = Convert.ToString(leitorRegistro["LOGIN"]);
            var senha = Convert.ToString(leitorRegistro["SENHA"]);
            var salario = Convert.ToDouble(leitorRegistro["SALARIO"]);
            var dataAdimissao = Convert.ToDateTime(leitorRegistro["DATA_ADMISSAO"]);
            var tipoFuncionario = Convert.ToString(leitorRegistro["TIPOFUNCIONARIO"]);

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
