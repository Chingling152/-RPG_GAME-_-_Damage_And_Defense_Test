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

                lbl_n_v.Text = nivel.ToString();

                lbl_p_f.Text = player.forca.ToString();
                lbl_p_d.Text = player.destreza.ToString();
                lbl_p_r.Text = player.resistencia.ToString();
                lbl_p_v.Text = player.vigor.ToString();
                lbl_p_m.Text = player.magia.ToString();

                lbl_p_dmg_f.Text = player.danofisico.ToString("N2");
                lbl_p_dmg_fg.Text = player.danofogo.ToString("N2");
                lbl_p_dmg_r.Text = player.danoraio.ToString("N2");
                lbl_p_dmg_v.Text = player.danoveneno.ToString("N2");
                lbl_p_dmg_m.Text = player.danomagico.ToString("N2");

                lbl_p_def_f.Text = player.defesafisica.ToString("N2");
                lbl_p_def_fg.Text = player.defesafogo.ToString("N2");
                lbl_p_def_r.Text = player.defesaraio.ToString("N2");
                lbl_p_def_v.Text = player.defesaveneno.ToString("N2");
                lbl_p_def_m.Text = player.defesamagica.ToString("N2");

                lbl_p_hp.Text = player.hp.ToString();
                lbl_p_e.Text = player.stamina.ToString();
                lbl_p_pm.Text = player.pesomax.ToString();
                lbl_p_sm.Text = player.slotsmagia.ToString();

            
            //Equipamento (arma)
            if (arma != null) {
                gb_a.Enabled = true;
                lbl_a_f.Text = arma.influencia.Contains(Influencia.Forca)?"Sim":"Não";
                lbl_a_d.Text = arma.influencia.Contains(Influencia.Destreza) ? "Sim" : "Não";
                lbl_a_r.Text = arma.influencia.Contains(Influencia.Resistencia) ? "Sim" : "Não";
                lbl_a_v.Text = arma.influencia.Contains(Influencia.Vigor) ? "Sim" : "Não";
                lbl_a_m.Text = arma.influencia.Contains(Influencia.Magia) ? "Sim" : "Não";

                lbl_a_df.Text = arma.dfisico.ToString();
                lbl_a_dfg.Text = arma.dfogo.ToString();
                lbl_a_dr.Text = arma.draio.ToString();
                lbl_a_dv.Text = arma.dveneno.ToString();
                lbl_a_dm.Text = arma.dmagico.ToString();

                txt_a_n.Text = arma.classe.ToString();
            }
            else {
                gb_a.Enabled = false;
            }

            //Equipamento (Armadura)
            if(armadura != null) {
                gb_ar.Enabled = true;
                lbl_arm_f.Text = armadura.influencia.Contains(Influencia.Forca) ? "Sim" : "Não";
                lbl_arm_d.Text = armadura.influencia.Contains(Influencia.Destreza) ? "Sim" : "Não";
                lbl_arm_r.Text = armadura.influencia.Contains(Influencia.Resistencia) ? "Sim" : "Não";
                lbl_arm_v.Text = armadura.influencia.Contains(Influencia.Vigor) ? "Sim" : "Não";
                lbl_arm_m.Text = armadura.influencia.Contains(Influencia.Magia) ? "Sim" : "Não";

                lbl_arm_df.Text = armadura.dfisico.ToString();
                lbl_arm_dfg.Text = armadura.dfogo.ToString();
                lbl_arm_dr.Text = armadura.draio.ToString();
                lbl_arm_dv.Text = armadura.dveneno.ToString();
                lbl_arm_dm.Text = armadura.dmagico.ToString();

                lbl_arm_n.Text = armadura.classe.ToString();
            }
            else {
                gb_ar.Enabled = false;
            }

            //Player + influencias
            lbl_p_f_2.Text = player.forca.ToString();
            lbl_p_d_2.Text = player.destreza.ToString();
            lbl_p_r_2.Text = player.resistencia.ToString();
            lbl_p_v_2.Text = player.vigor.ToString();
            lbl_p_m_2.Text = player.magia.ToString();
        
            lbl_p_dmg_f_2.Text = player.DanoFisico.ToString("N2");
            lbl_p_dmg_fg_2.Text = player.DanoFogo.ToString("N2");
            lbl_p_dmg_r_2.Text = player.DanoRaio.ToString("N2");
            lbl_p_dmg_v_2.Text = player.DanoVeneno.ToString("N2");
            lbl_p_dmg_m_2.Text = player.DanoMagico.ToString("N2");
            
            /* 
            MessageBox.Show(
                "Dano Fisico : " + player.DanoFisico.ToString("N2") + 
                "\nDano raio : " + player.DanoRaio.ToString("N2") + 
                "\nDano Fogo : " + player.DanoFogo.ToString("N2") +
                "\nDano Veneno : " + player.DanoVeneno.ToString("N2") +
                "\nDano Magico : " + player.DanoMagico.ToString("N2")
                );

            MessageBox.Show(
                "Defesa Fisica : " + player.DefesaFisica.ToString("N2") +
                "\nDefesa raio : " + player.DefesaRaio.ToString("N2") +
                "\nDefesa Fogo : " + player.DefesaFogo.ToString("N2") +
                "\nDefesa Veneno : " + player.DefesaVeneno.ToString("N2") +
                "\nDefesa Magica : " + player.DefesaMagica.ToString("N2")
                );
            */

            lbl_p_def_f_2.Text = player.DefesaFisica.ToString("N2");
            lbl_p_def_fg_2.Text = player.DefesaFogo.ToString("N2");
            lbl_p_def_r_2.Text = player.DefesaRaio.ToString("N2");
            lbl_p_def_v_2.Text = player.DefesaVeneno.ToString("N2");
            lbl_p_def_m_2.Text = player.DefesaMagica.ToString("N2");
        }
    }        
}
