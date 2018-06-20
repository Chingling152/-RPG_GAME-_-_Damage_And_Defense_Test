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
        /// txt_df , txt_dfg , txt_dr , txt_dv = dano\defesa fisic@ , raio , veneno fogo , veneno
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
        public Equipamento equipamento;

        public Form1()
        {
            InitializeComponent();
        }
        
        //Valores base
        private void Form1_Load(object sender, EventArgs e)
        {
            cbo_dp.SelectedIndex = 0;
            cbo_de.SelectedIndex = 0;
        }

        //criar player
        private void btn_cp_Click(object sender, EventArgs e){
            try { 
            //Atributos
            float hp , stamina , pesomax;
                //Buscando nas textboxes
            float.TryParse(txt_Php.Text,out hp);
            float.TryParse(txt_Psta.Text, out stamina);
            float.TryParse(txt_Pp.Text, out pesomax);

            //Skills
            int forca, destreza, vigor, resistencia;
                //Buscando nas textboxes
            int.TryParse(txt_PF.Text , out forca);
            int.TryParse(txt_PD.Text, out destreza);
            int.TryParse(txt_PR.Text, out resistencia);
            int.TryParse(txt_PV.Text, out vigor);     
                //Verificação (Para nunca ser 0 ou menor)
            if(forca <= 0) { forca = 1; txt_PF.Text = forca.ToString(); }
            if(destreza <= 0) { destreza = 1; txt_PD.Text = destreza.ToString(); }
            if(vigor <= 0) { vigor = 1; txt_PV.Text = vigor.ToString(); }
            if(resistencia <= 0) { resistencia = 1; txt_PR.Text = resistencia.ToString(); }

            //String teste (e usado no tipo de influencia)
            string t = cbo_dp.SelectedItem.ToString();

            //Criação do player
            player = new Player(hp,stamina,pesomax,forca,destreza,resistencia,vigor,t);
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
                    btn_cp.Enabled = false;
                }
            }
        }
        //limpar (Player)
        private void btn_lp_Click(object sender, EventArgs e)
        {
            player = null;

            txt_Php.Clear();
            txt_Psta.Clear();
            txt_Pp.Clear();

            txt_PF.Clear();
            txt_PD.Clear();
            txt_PR.Clear();
            txt_PV.Clear();

            txt_PF.Enabled = true;
            txt_PD.Enabled = true;
            txt_PV.Enabled = true;
            txt_PR.Enabled = true;
            btn_cp.Enabled = true;
        }

        //criar equipamento
        private void btn_ce_Click(object sender, EventArgs e)
        {
            if(player != null) {
                try { 
                    float dfisico, draio, dfogo, dveneno;
                    List<Influencia> influencia = new List<Influencia>(){
                        Influencia.Forca,
                        Influencia.Destreza,
                        Influencia.Vigor,
                        Influencia.Resistencia
                    };

                    CheckBox[] check = new CheckBox[4] {
                        cb_f,
                        cb_d,
                        cb_v,
                        cb_r
                    };

                    Classe classe = 
                        r_A.Checked? Classe.A :
                        r_B.Checked? Classe.B :
                        r_C.Checked? Classe.C :
                        r_D.Checked? Classe.D :
                        r_E.Checked? Classe.E : 
                        Classe.E;

                    string tipo = cbo_de.SelectedItem.ToString();

                    for (int i = 0; i < check.Length; i++)
                    {
                        if (!check[i].Checked)
                        {
                            influencia.RemoveAt(i);
                        }
                    }

                    float.TryParse(txt_df.Text.ToString(),out dfisico);
                    float.TryParse(txt_dr.Text.ToString(), out draio);
                    float.TryParse(txt_dfg.Text.ToString(), out dfogo);
                    float.TryParse(txt_dv.Text.ToString(), out dveneno);

                    //atualizar equipamento.influencias depois de criar

                    equipamento = new Equipamento(dfisico, draio, dfogo, dveneno, influencia, classe, tipo);
                    
                    Resultado r = new Resultado(equipamento,player);
                } catch(Exception ex) {
                    MessageBox.Show("Erro Ao criar Equipamento : \n"+ ex.Message);
                }
            }
            else {
                MessageBox.Show("Primeiro Crie o Player","Exceção",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
        //mudança do combo box (player)
        private void cbo_dp_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo_de.SelectedIndex = cbo_dp.SelectedIndex;
            if (player != null) {
                player.influencias(cbo_dp.SelectedItem.ToString());
                MudandoInfluencias(cbo_dp);
            }
        }
        //mudança do combo box (equipamento)
        private void cbo_de_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo_dp.SelectedIndex = cbo_de.SelectedIndex;
            if (player != null && equipamento!=null)
            {
                MudandoInfluencias(cbo_de);
            }
        }
        
        //mudança de influencias (ambos)
        void MudandoInfluencias(ComboBox CBO) {
            if (CBO.SelectedItem.Equals("Dano")){//if & else basico 
                if(CBO.Name.Equals("cbo_dp")){//se for a combo box do player
                    //dano
                    txt_Pdf.Text = player.dfisico.ToString();
                    txt_Pdfg.Text = player.dfogo.ToString();
                    txt_Pdr.Text = player.draio.ToString();
                    txt_Pdv.Text = player.dveneno.ToString();

                    //statisticas
                    txt_Php.Text = player.hp.ToString();
                    txt_Psta.Text = player.stamina.ToString();
                    txt_Pp.Text = player.pesomax.ToString();
                }
                else 
                if (CBO.Name.Equals("cbo_de")) {//se for a combo box do equipamento
                    txt_Pdf.Text = equipamento.dfisico.ToString();
                    txt_Pdfg.Text = equipamento.dfogo.ToString();
                    txt_Pdr.Text = equipamento.draio.ToString();
                    txt_Pdv.Text = equipamento.dveneno.ToString();
                }
            }
            else if (CBO.SelectedItem.Equals("Defesa")) {// o mesmo que la em cima ... porem com influenciia da defesa
                if (CBO.Name.Equals("cbo_dp"))
                {
                    txt_Pdf.Text = player.dfisico.ToString();
                    txt_Pdfg.Text = player.dfogo.ToString();
                    txt_Pdr.Text = player.draio.ToString();
                    txt_Pdv.Text = player.dveneno.ToString();

                    txt_Php.Text = player.hp.ToString();
                    txt_Psta.Text = player.stamina.ToString();
                    txt_Pp.Text = player.pesomax.ToString();
                }
                else
              if (CBO.Name.Equals("cbo_de"))
                {
                    txt_Pdf.Text = equipamento.dfisico.ToString();
                    txt_Pdfg.Text = equipamento.dfogo.ToString();
                    txt_Pdr.Text = equipamento.draio.ToString();
                    txt_Pdv.Text = equipamento.dveneno.ToString();
                }
            }
        }
        

        /*Deixa isso ai....*/
        private void panel4_Paint(object sender, PaintEventArgs e){
            
        }
    
    }
}
