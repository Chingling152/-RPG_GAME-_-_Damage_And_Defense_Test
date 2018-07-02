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

            player.equipamento = this.equipamento;
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

                txt_pdf.Text = player.dfisico.ToString("N3");
                txt_pdfg.Text = player.dfogo.ToString("N3");
                txt_pdr.Text = player.draio.ToString("N3");
                txt_pdv.Text = player.dveneno.ToString("N3");
                txt_pdm.Text = player.dmagico.ToString("N3");

                txt_php.Text = player.hp.ToString();
                txt_pe.Text = player.stamina.ToString();
                txt_ppm.Text = player.pesomax.ToString();
                txt_psm.Text = player.slotsmagia.ToString();

            //Equipamento
                txt_eif.Text = equipamento.influencia.Contains(Influencia.Forca)?"Sim":"Não";
                txt_eid.Text = equipamento.influencia.Contains(Influencia.Destreza) ? "Sim" : "Não";
                txt_eir.Text = equipamento.influencia.Contains(Influencia.Resistencia) ? "Sim" : "Não";
                txt_eiv.Text = equipamento.influencia.Contains(Influencia.Vigor) ? "Sim" : "Não";
                txt_eim.Text = equipamento.influencia.Contains(Influencia.Magia) ? "Sim" : "Não";

                txt_edf.Text = equipamento.dfisico.ToString();
                txt_edfg.Text = equipamento.dfogo.ToString();
                txt_edr.Text = equipamento.draio.ToString();
                txt_edv.Text = equipamento.dveneno.ToString();
                txt_edm.Text = equipamento.dmagico.ToString();

                txt_en.Text = equipamento.classe.ToString();

            // Player + Equipamento
                txt_fdf.Text = player.Dfisico.ToString("N3");
                txt_fdfg.Text = player.DFogo.ToString("N3");
                txt_fdr.Text = player.DRaio.ToString("N3");
                txt_fdv.Text = player.DVeneno.ToString("N3");
                txt_fdm.Text = player.DMagico.ToString("N3");

        }
    }        
}
