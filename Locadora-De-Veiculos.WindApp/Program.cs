using Locadora_De_Veiculos.Infra.Logging;
using Locadora_De_Veiculos.Infra.Orm.Compartilhado;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        
        {
            MigradorBancoDados.AtualizarBancoDados();
            ConfiguracaoLogsLocadora.ConfigurarEscritaLog();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //var serviceLocator = new ServiceLocatorComAutofac();
            var serviceLocator = new ServiceLocatorManual();
            Application.Run(new TelaInicioForm(serviceLocator));
        }
    }
}
