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
using Calculador_De_Dano_E_Defesa.Forms;

namespace Calculador_De_Dano_E_Defesa
{
    public partial class Form1 : Form
    {
        /// <TextBoxes>
        /// /// Equipamento ///
        /// r_A , r_b , r_c , r_D , r_E = nivel de influencia
        /// influences = influencias
        /// txt_a_df , txt_a_dfg , txt_a_dr , txt_a_dv = dano fisico , raio , veneno fogo , veneno
        /// /// Player ///
        /// txt_Pf , txt_pd , txt_Pv , txt_Pr = força vigor , destreza e resistencia
        /// txt_Pdf , txt_Pdfg , txt_Pdr , txt_Pdv = dano\defesa fisic@ , raio , veneno fogo , veneno
        /// txt_Php , txt_Psta , txt_Pp = hp , stamina e peso max 
        /// </TextBoxes>

        /// <Botões>
        /// btn_cp , btn_ce = criar player , criar equipamento
        /// btn_lp , btn_le = limpar campos : player , equipamento
        /// </Botões>

        public Player player;
        public Arma arma;
        public Armadura armadura;

        public Form1()
        {
            InitializeComponent();
        }
        
        //Valores base
        private void Form1_Load(object sender, EventArgs e)
        {
            cbo_dp.SelectedIndex = 0;
        }

        //criar player
        private void Btn_cp_Click(object sender, EventArgs e){
            try { 
                //Buscando nas textboxes
                int.TryParse(txt_PF.Text , out int forca);
                int.TryParse(txt_PD.Text, out int destreza);
                int.TryParse(txt_PR.Text, out int resistencia);
                int.TryParse(txt_PV.Text, out int vigor);     
                int.TryParse(txt_PM.Text, out int magia);
                    //Verificação (Para nunca ser 0 ou menor)
                if(forca <= 0) {forca = 1; txt_PF.Text = forca.ToString(); }
                if(destreza <= 0) { destreza = 1; txt_PD.Text = destreza.ToString(); }
                if(vigor <= 0) {vigor = 1; txt_PV.Text = vigor.ToString(); }
                if(resistencia <= 0) {resistencia = 1; txt_PR.Text = resistencia.ToString(); }
                if(magia <= 0) {magia = 1; txt_PM.Text = resistencia.ToString(); }

                //String teste (e usado no tipo de influencia)
                string t = cbo_dp.SelectedItem.ToString();

                //Criação do player
                player = new Player(forca,destreza,resistencia,vigor,magia,t);
            }
            catch (Exception ex) {
                MessageBox.Show("Erro Ao criar Player: \n"+ ex.Message);
            }
            finally {
                //Setando influencias
                MudandoInfluencias(cbo_dp);
                if (player!=null){
                    //Desabilitar controles (impossibilitando modificar o player depois de criado) caso ele exista
                    txt_PF.Enabled = false;
                    txt_PD.Enabled = false;
                    txt_PV.Enabled = false;
                    txt_PR.Enabled = false;
                    txt_PM.Enabled = false;
                    btn_cp.Enabled = false;
                }
            }
        }
        //limpar (Player)
        private void Btn_lp_Click(object sender, EventArgs e)
        {
            player = null;

            LimparPlayer();

            txt_PF.Enabled = true;
            txt_PD.Enabled = true;
            txt_PV.Enabled = true;
            txt_PR.Enabled = true;
            txt_PM.Enabled = true;
            btn_cp.Enabled = true;
        }
        //Limpar campos (Player)
        void LimparPlayer() {

            txt_Php.Clear();
            txt_Psta.Clear();
            txt_Pp.Clear();
            txt_Psm.Clear();

            txt_PF.Clear();
            txt_PD.Clear();
            txt_PR.Clear();
            txt_PV.Clear();
            txt_PM.Clear();

            txt_Pdf.Clear();
            txt_Pdfg.Clear();
            txt_Pdr.Clear();
            txt_Pdv.Clear();
            txt_Pdm.Clear();
        }

        //mudança do combo box (player)
        private void Cbo_dp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (player != null)
            {
                player.Influencias();
                MudandoInfluencias(cbo_dp);
            }
        }
        //mudança de influencias
        void MudandoInfluencias(ComboBox CBO)
        {
            /*Player*/
            if (CBO.SelectedIndex.Equals(0))
            {
                txt_Pdf.Text = player.danofisico.ToString();
                txt_Pdfg.Text = player.danofogo.ToString();
                txt_Pdr.Text = player.danoraio.ToString();
                txt_Pdv.Text = player.danoveneno.ToString();
                txt_Pdm.Text = player.danomagico.ToString();
            }
            else
            {
                txt_Pdf.Text = player.defesafisica.ToString();
                txt_Pdfg.Text = player.defesafogo.ToString();
                txt_Pdr.Text = player.defesaraio.ToString();
                txt_Pdv.Text = player.defesaveneno.ToString();
                txt_Pdm.Text = player.defesamagica.ToString();
            }
            //statisticas
            txt_Php.Text = player.hp.ToString();
            txt_Psta.Text = player.stamina.ToString();
            txt_Pp.Text = player.pesomax.ToString();
            txt_Psm.Text = player.slotsmagia.ToString();
        }

        //Ativar arma
        private void Cb_A_CheckedChanged(object sender, EventArgs e)
        {

            if (!cb_a.Checked)
            {
                //Limpar campos
                LimparArma();

                //desabilitar campos
                txt_adf.Enabled = false;
                txt_adfg.Enabled = false;
                txt_adv.Enabled = false;
                txt_adr.Enabled = false;
                txt_adm.Enabled = false;

                cb_af.Enabled = false;
                cb_ad.Enabled = false;
                cb_ar.Enabled = false;
                cb_av.Enabled = false;
                cb_am.Enabled = false;

                r_a_A.Enabled = false;
                r_a_B.Enabled = false;
                r_a_C.Enabled = false;
                r_a_D.Enabled = false;
                r_a_E.Enabled = false;

                btn_ca.Enabled = false;
                btn_la.Enabled = false;
            }
            else
            {
                txt_adf.Enabled = true;
                txt_adfg.Enabled = true;
                txt_adv.Enabled = true;
                txt_adr.Enabled = true;
                txt_adm.Enabled = true;

                cb_af.Enabled = true;
                cb_ad.Enabled = true;
                cb_ar.Enabled = true;
                cb_av.Enabled = true;
                cb_am.Enabled = true;

                r_a_A.Enabled = true;
                r_a_B.Enabled = true;
                r_a_C.Enabled = true;
                r_a_D.Enabled = true;
                r_a_E.Enabled = true;

                btn_ca.Enabled = true;
                btn_la.Enabled = true;
            }
        }
        //criar arma
        private void Btn_ca_Click(object sender, EventArgs e)
        {
            if(player != null) {
                try {
                    List<Influencia> influencia = new List<Influencia>(){
                        Influencia.Forca,
                        Influencia.Destreza,
                        Influencia.Vigor,
                        Influencia.Resistencia,
                        Influencia.Magia
                    };

                    CheckBox[] check = new CheckBox[5] {
                        cb_af,
                        cb_ad,
                        cb_ar,
                        cb_av,
                        cb_am
                    };

                    Classe classe = 
                        r_a_A.Checked? Classe.A :
                        r_a_B.Checked? Classe.B :
                        r_a_C.Checked? Classe.C :
                        r_a_D.Checked? Classe.D :
                        r_a_E.Checked? Classe.E : 
                        Classe.E;

                    if (classe.Equals(Classe.E) && !r_a_E.Checked) {
                        r_a_E.Select();
                    }

                    for (int i = 0; i < check.Length; i++)
                    {           
                        if (!check[i].Checked)
                        {
                            influencia.Remove((Influencia)i);
                        }
                    }

                    if(influencia.Count == 0) {
                        influencia.Add(Influencia.Nada);
                    }

                    float.TryParse(txt_adf.Text,out float danofisico);
                    float.TryParse(txt_adr.Text, out float danoraio);
                    float.TryParse(txt_adfg.Text, out float danofogo);
                    float.TryParse(txt_adv.Text, out float danoveneno);
                    float.TryParse(txt_adm.Text, out float danomagico);

                    if (danofisico <= 0) { danofisico = 0; txt_adf.Text = danofisico.ToString(); }
                    if (danoraio <= 0) { danoraio = 0; txt_adr.Text = danoraio.ToString(); }
                    if (danofogo <= 0) { danofogo = 0; txt_adfg.Text = danofogo.ToString(); }
                    if (danoveneno <= 0) { danoveneno = 0; txt_adv.Text = danoveneno.ToString(); }
                    if (danomagico <= 0) { danomagico = 0; txt_adm.Text = danomagico.ToString(); }

                    //atualizar equipamento.influencias depois de criar

                    arma = new Arma(danofisico, danoraio, danofogo, danoveneno, danomagico, influencia, classe);

                    //bloquear controles
                    txt_adf.Enabled = false;
                    txt_adfg.Enabled = false;
                    txt_adr.Enabled = false;
                    txt_adv.Enabled = false;
                    txt_adm.Enabled = false;

                    foreach (CheckBox item in check)
                    {
                        item.Enabled = false;
                    }

                    btn_ca.Enabled = false;
                    r_a_A.Enabled = false;
                    r_a_B.Enabled = false;
                    r_a_C.Enabled = false;
                    r_a_D.Enabled = false;
                    r_a_E.Enabled = false;

                } catch(Exception ex) {
                    MessageBox.Show("Erro Ao criar Equipamento : \n"+ ex);
                }
            }
            else {
                MessageBox.Show("Primeiro Crie o Player","Exceção",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
        //Limpar arma
        private void Btn_la_Click(object sender, EventArgs e)
        {
            //Limpar campos
            LimparArma();

            //ativar campos
            txt_adf.Enabled = true;
            txt_adfg.Enabled = true;
            txt_adv.Enabled = true;
            txt_adr.Enabled = true;
            txt_adm.Enabled = true;

            cb_af.Enabled = true;
            cb_ad.Enabled = true;
            cb_ar.Enabled = true;
            cb_av.Enabled = true;
            cb_am.Enabled = true;

            r_a_A.Enabled = true;
            r_a_B.Enabled = true;
            r_a_C.Enabled = true;
            r_a_D.Enabled = true;
            r_a_E.Enabled = true;

            btn_ca.Enabled = true;
        }
        //Limpar campos (Arma)
        void LimparArma() {
            txt_adf.Clear();
            txt_adfg.Clear();
            txt_adv.Clear();
            txt_adr.Clear();
            txt_adm.Clear();

            cb_af.Checked = false;
            cb_ad.Checked = false;
            cb_ar.Checked = false;
            cb_av.Checked = false;
            cb_am.Checked = false;

            r_a_A.Select();
            r_a_A.Checked = false;
        }

        //Criar armadura
        private void Btn_c_ar_Click(object sender, EventArgs e)
        {
            if (player != null)
            {
                try
                {
                    List<Influencia> influencia = new List<Influencia>(){
                        Influencia.Forca,
                        Influencia.Destreza,
                        Influencia.Vigor,
                        Influencia.Resistencia,
                        Influencia.Magia
                    };

                    CheckBox[] check = new CheckBox[5] {
                        cb_ar_f,
                        cb_ar_d,
                        cb_ar_r,
                        cb_ar_v,
                        cb_ar_m
                    };
                    //arrume isso
                    Classe classe =
                        r_ar_A.Checked ? Classe.A :
                        r_ar_B.Checked ? Classe.B :
                        r_ar_C.Checked ? Classe.C :
                        r_ar_D.Checked ? Classe.D :
                        r_ar_E.Checked ? Classe.E :
                        Classe.E;

                    if (classe.Equals(Classe.E) && !r_ar_E.Checked)
                    {
                        r_ar_E.Select();
                    }

                    for (int i = 0; i < check.Length; i++)
                    {
                        if (!check[i].Checked)
                        {
                            influencia.Remove((Influencia)i);
                        }
                    }

                    if (influencia.Count == 0)
                    {
                        influencia.Add(Influencia.Nada);
                    }

                    float.TryParse(txt_ar_df.Text, out float defesafisica);
                    float.TryParse(txt_ar_dr.Text, out float defesaraio);
                    float.TryParse(txt_ar_dfg.Text, out float defesafogo);
                    float.TryParse(txt_ar_dv.Text, out float defesaveneno);
                    float.TryParse(txt_ar_dm.Text, out float defesamagica);

                    if (defesafisica <= 0) { defesafisica = 0; txt_ar_df.Text = defesafisica.ToString(); }
                    if (defesaraio <= 0) { defesaraio = 0; txt_ar_dr.Text = defesaraio.ToString(); }
                    if (defesafogo <= 0) { defesafogo = 0; txt_ar_dfg.Text = defesafogo.ToString(); }
                    if (defesaveneno <= 0) { defesaveneno = 0; txt_ar_dv.Text = defesaveneno.ToString(); }
                    if (defesamagica <= 0) { defesamagica = 0; txt_ar_dm.Text = defesamagica.ToString(); }

                    //atualizar equipamento.influencias depois de criar

                    armadura = new Armadura(defesafisica, defesaraio, defesafogo, defesaveneno, defesamagica, influencia, classe);

                    //bloquear controles
                    txt_ar_df.Enabled = false;
                    txt_ar_dfg.Enabled = false;
                    txt_ar_dr.Enabled = false;
                    txt_ar_dv.Enabled = false;
                    txt_ar_dm.Enabled = false;

                    foreach (CheckBox item in check)
                    {
                        item.Enabled = false;
                    }

                    btn_c_ar.Enabled = false;
                    r_ar_A.Enabled = false;
                    r_ar_B.Enabled = false;
                    r_ar_C.Enabled = false;
                    r_ar_D.Enabled = false;
                    r_ar_E.Enabled = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro Ao criar Equipamento : \n" + ex);
                }
            }
            else
            {
                MessageBox.Show("Primeiro Crie o Player", "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }       
        }
        //Limpar armadura
        private void Btn_l_ar_Click(object sender, EventArgs e)
        {
            //Limpar campos
            LimparArmadura();

            //ativar campos
            txt_ar_df.Enabled = true;
            txt_ar_dfg.Enabled = true;
            txt_ar_dv.Enabled = true;
            txt_ar_dr.Enabled = true;
            txt_ar_dm.Enabled = true;

            cb_ar_f.Enabled = true;
            cb_ar_d.Enabled = true;
            cb_ar_r.Enabled = true;
            cb_ar_v.Enabled = true;
            cb_ar_m.Enabled = true;

            r_ar_A.Enabled = true;
            r_ar_B.Enabled = true;
            r_ar_C.Enabled = true;
            r_ar_D.Enabled = true;
            r_ar_E.Enabled = true;

            btn_ca.Enabled = true;
        }
        //Limpar campos (armadura)
        void LimparArmadura()
        {
            txt_ar_df.Clear();
            txt_ar_dfg.Clear();
            txt_ar_dv.Clear();
            txt_ar_dr.Clear();
            txt_ar_dm.Clear();

            cb_ar_f.Checked = false;
            cb_ar_d.Checked = false;
            cb_ar_r.Checked = false;
            cb_ar_v.Checked = false;
            cb_ar_m.Checked = false;

            r_ar_A.Select();
            r_ar_A.Checked = false;
        }
        //Ativar armadura
        private void Cb_arm_CheckedChanged(object sender, EventArgs e)
        {
            if (!cb_arm.Checked)
            {
                //Limpar campos
                LimparArmadura();

                //desabilitar campos
                txt_ar_df.Enabled = false;
                txt_ar_dfg.Enabled = false;
                txt_ar_dv.Enabled = false;
                txt_ar_dr.Enabled = false;
                txt_ar_dm.Enabled = false;

                cb_ar_f.Enabled = false;
                cb_ar_d.Enabled = false;
                cb_ar_r.Enabled = false;
                cb_ar_v.Enabled = false;
                cb_ar_m.Enabled = false;

                r_ar_A.Enabled = false;
                r_ar_B.Enabled = false;
                r_ar_C.Enabled = false;
                r_ar_D.Enabled = false;
                r_ar_E.Enabled = false;

                btn_c_ar.Enabled = false;
                btn_l_ar.Enabled = false;
            }
            else {
                //habilitar campos
                txt_ar_df.Enabled = true;
                txt_ar_dfg.Enabled = true;
                txt_ar_dv.Enabled = true;
                txt_ar_dr.Enabled = true;
                txt_ar_dm.Enabled = true;

                cb_ar_f.Enabled = true;
                cb_ar_d.Enabled = true;
                cb_ar_r.Enabled = true;
                cb_ar_v.Enabled = true;
                cb_ar_m.Enabled = true;

                r_ar_A.Enabled = true;
                r_ar_B.Enabled = true;
                r_ar_C.Enabled = true;
                r_ar_D.Enabled = true;
                r_ar_E.Enabled = true;

                btn_c_ar.Enabled = true;
                btn_l_ar.Enabled = true;
            }
            
        }

        //RESULTADO
        private void Button1_Click(object sender, EventArgs e)
        {
            if (!cb_a.Checked) { arma = null;}
            if (!cb_arm.Checked) { armadura = null;}

            if (player != null) {
                if (arma == null && armadura == null) {
                    MessageBox.Show("O Player não pode ser instanciado sem equipamento!!", "Erro");                  
                }
                else {
                    Resultado r = new Resultado(this.arma, this.armadura, this.player);
                    r.ShowDialog();
                }
            }
            else {
                MessageBox.Show("Primeiro crie o player");
            }
        }

    }
}
