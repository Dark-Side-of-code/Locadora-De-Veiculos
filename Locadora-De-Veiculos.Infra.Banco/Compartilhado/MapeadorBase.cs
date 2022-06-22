﻿using Locadora_De_Veiculos.Dominio.Compartilhado;
using System.Data.SqlClient;

namespace Locadora_De_Veiculos.Infra.Banco.Compartilhado
{
    public abstract class MapeadorBase<T> where T : EntidadeBase<T>
    {
        public abstract void ConfigurarParametros(T registro, SqlCommand comando);

        public abstract T ConverterRegistro(SqlDataReader leitorRegistro);
    }
}
