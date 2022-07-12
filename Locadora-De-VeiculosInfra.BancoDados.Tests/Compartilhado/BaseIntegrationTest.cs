using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_VeiculosInfra.BancoDados.Tests.Compartilhado
{
    public class BaseIntegrationTest
    {
        public BaseIntegrationTest()
        {
            Db.ExecutarSql("DELETE FROM TBVEICULO");

            Db.ExecutarSql("DELETE FROM TbPlanoCobranca");

            Db.ExecutarSql("DELETE FROM TbCondutor");

            Db.ExecutarSql("DELETE FROM TbTaxas");

            Db.ExecutarSql("DELETE FROM TbFuncionario");

            Db.ExecutarSql("DELETE FROM TbCliente");

            Db.ExecutarSql("DELETE FROM TbCategoriaVeiculo");
        }
    }
}
