using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloLocacao
{
    public partial class TelaCadastroLocacao : Form
    {
        public TelaCadastroLocacao()
        {
            InitializeComponent();
            this.ConfigurarTela();
        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }
    }
}
