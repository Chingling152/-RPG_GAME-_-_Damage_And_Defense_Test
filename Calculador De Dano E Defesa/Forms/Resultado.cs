using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculador_De_Dano_E_Defesa.Scripts;

namespace Calculador_De_Dano_E_Defesa.Forms
{
    public partial class Resultado : Form
    {
        public Equipamento equipamento;

        public Resultado(Equipamento equipamento)
        {
            InitializeComponent();
            this.equipamento = equipamento;
        }

        private void Resultado_Load(object sender, EventArgs e)
        {

        }
    }
}
