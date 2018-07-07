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

        public Player player;
        public Armadura armadura;
        public Arma arma;

        public Resultado(Arma arma,Armadura armadura, Player player)
        {
            InitializeComponent();

            this.armadura = armadura;
            this.arma = arma;
            this.player = player;

            player.armadura = this.armadura;
            player.arma = this.arma;
        }

        private void Resultado_Load(object sender, EventArgs e)
        {
            //Player
                int nivel = player.destreza + player.forca + player.resistencia + player.vigor + player.magia ;

                txt_nv.Text = nivel.ToString();

                txt_pf.Text = player.forca.ToString();
                txt_pd.Text = player.destreza.ToString();
                txt_pr.Text = player.resistencia.ToString();
                txt_pv.Text = player.vigor.ToString();
                txt_pm.Text = player.magia.ToString();

                /*txt_pdf.Text = player.dfisico.ToString("N3");
                txt_pdfg.Text = player.dfogo.ToString("N3");
                txt_pdr.Text = player.draio.ToString("N3");
                txt_pdv.Text = player.dveneno.ToString("N3");
                txt_pdm.Text = player.dmagico.ToString("N3");*/

                txt_php.Text = player.hp.ToString();
                txt_pe.Text = player.stamina.ToString();
                txt_ppm.Text = player.pesomax.ToString();
                txt_psm.Text = player.slotsmagia.ToString();

            //Equipamento (arma)
                txt_eif.Text = arma.influencia.Contains(Influencia.Forca)?"Sim":"Não";
                txt_eid.Text = arma.influencia.Contains(Influencia.Destreza) ? "Sim" : "Não";
                txt_eir.Text = arma.influencia.Contains(Influencia.Resistencia) ? "Sim" : "Não";
                txt_eiv.Text = arma.influencia.Contains(Influencia.Vigor) ? "Sim" : "Não";
                txt_a_m.Text = arma.influencia.Contains(Influencia.Magia) ? "Sim" : "Não";

                txt_a_df.Text = arma.dfisico.ToString();
                txt_a_dfg.Text = arma.dfogo.ToString();
                txt_a_dr.Text = arma.draio.ToString();
                txt_a_dv.Text = arma.dveneno.ToString();
                txt_a_dm.Text = arma.dmagico.ToString();

                txt_en.Text = arma.classe.ToString();

        }
    }        
}
