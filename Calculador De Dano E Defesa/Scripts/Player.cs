using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculador_De_Dano_E_Defesa.Scripts
{
    public class Player
    {
        public float hp , stamina ,pesomax;
        public int forca , destreza , resistencia , vigor , magia;
        public int slotsmagia;

        public float danofisico, danofogo , danoraio , danoveneno , danomagico; // DANO
        public float defesafisica, defesafogo, defesaraio, defesaveneno, defesamagica;//DEFESA

        public Armadura armadura;
        public Arma arma;

        //com influencias (DANO)
        public float DanoFisico {get {return Influencias(danofisico, arma);}}
        public float DanoFogo { get { return Influencias(danofogo, arma);} }        
        public float DanoRaio { get { return Influencias(danoraio, arma);} }       
        public float DanoVeneno { get { return Influencias(danoveneno, arma);} }
        public float DanoMagico { get { return Influencias(danomagico, arma);} }

        //com influencias (Defesa)
        public float DefesaFisica { get { return Influencias(defesafisica, armadura); } }
        public float DefesaFogo { get { return Influencias(defesafogo, armadura); } }
        public float DefesaRaio { get { return Influencias(defesaraio, armadura); } }
        public float DefesaVeneno { get { return Influencias(defesaveneno, armadura); } }
        public float DefesaMagica { get { return Influencias(defesamagica, armadura); } }

        public Player(int forca, int destreza, int resistencia, int vigor,int magia,string tipo)
        {
            this.forca = forca>100?100:forca;
            this.destreza = destreza>100?100:destreza;
            this.resistencia = resistencia > 100 ? 100 : resistencia;
            this.vigor = vigor > 100 ? 100 : vigor;
            this.magia = magia > 100 ? 100 : magia;
            Influencias();
        }

        //influencia da skill
        public void Influencias() { // 1 = influencia
            hp = (200 * 1) * (vigor * 0.25f);       
            stamina = (50 * 1)*(vigor * 0.10f);                                
            pesomax = (12 * 1) * (resistencia * 0.10f);
            slotsmagia = (int)Math.Floor((float)magia * 0.10f);

            danofisico = (1 * (forca * destreza - (magia * 0.025f)) * 0.05f);//FIX THAT
            danofogo = 0;
            danoraio = 0;
            danoveneno = 0;
            danomagico = 0;

            defesafisica = (1 * (resistencia * vigor - (magia * 0.025f)) * 0.05f);
            defesaraio = (1 * (resistencia * magia) * 0.0025f);
            defesafogo = (1 * (resistencia * vigor) * 0.0025f);
            defesaveneno = (1 * (vigor * 0.25f));
            defesamagica = (1 * (magia * 0.05f - ((vigor + resistencia) * 0.025f)));
        }
        
        //influencia do equipamento (fixar?)
        public float Influencias(float n, Equipamento equip){
            foreach (Influencia item in equip.influencia)
            {
                switch (item)
                {
                    case Influencia.Forca:
                        n = n * ((float)forca* ((float)equip.classe) * 0.10f);
                        break;
                    case Influencia.Destreza:
                        n = n * ((float)destreza * ((float)equip.classe) * 0.10f);
                        break;
                    case Influencia.Resistencia:
                        n = n * ((float)resistencia * ((float)equip.classe) * 0.10f);
                        break;
                    case Influencia.Vigor:
                        n = n * ((float)vigor * ((float)equip.classe) * 0.10f);
                        break;
                    case Influencia.Magia:
                        n = n * ((float)magia * ((float)equip.classe) * 0.10f);
                        break;
                    case Influencia.Nada:  
                        return n * 0.10f;
                    default:
                        break;
                }
            }         
            return n / equip.influencia.Count;
        }
    }
}
