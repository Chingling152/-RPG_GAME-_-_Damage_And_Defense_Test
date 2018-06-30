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
        public Player player;

        public Resultado(Equipamento equipamento,Player player)
        {
            InitializeComponent();
            this.equipamento = equipamento;
            this.player = player;
        }

        private void Resultado_Load(object sender, EventArgs e)
        {
            //Player
            int nivel = player.destreza + player.forca + player.resistencia + player.vigor + player.magia - 5 ;

            txt_nv.Text = nivel.ToString();

            txt_pf.Text = player.forca.ToString();
            txt_pd.Text = player.destreza.ToString();
            txt_pr.Text = player.resistencia.ToString();
            txt_pv.Text = player.vigor.ToString();
            txt_pm.Text = player.magia.ToString();

            txt_pdf.Text = player.dfisico.ToString();
            txt_pdfg.Text = player.dfogo.ToString();
            txt_pdr.Text = player.draio.ToString();
            txt_pdv.Text = player.dfisico.ToString();
            txt_pdm.Text = player.dmagico.ToString();

            txt_php.Text = player.hp.ToString();
            txt_pe.Text = player.stamina.ToString();
            txt_ppm.Text = player.pesomax.ToString();
        }
    }

        
}
