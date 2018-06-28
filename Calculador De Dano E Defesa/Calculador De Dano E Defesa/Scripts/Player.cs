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
        public float dfisico, dfogo , draio , dveneno , dmagico; // Sem influencias
        public Equipamento equipamento;

        //com influencias
        public float Dfisico {get => dfisico + influencias(dfisico,equipamento);}
        public float DFogo {get => dfogo + influencias(dfogo, equipamento);}        
        public float DRaio {get => draio + influencias(draio, equipamento);}       
        public float DVeneno { get => dveneno + influencias(dveneno, equipamento);}

        public Player(float hp, float stamina, float pesomax, int forca, int destreza, int resistencia, int vigor,int magia,string tipo)
        {
            this.hp = hp;
            this.stamina = stamina;
            this.pesomax = pesomax;
            this.forca = forca>100?100:forca;
            this.destreza = destreza>100?100:destreza;
            this.resistencia = resistencia > 100 ? 100 : resistencia;
            this.vigor = vigor > 100 ? 100 : vigor;
            this.magia = magia > 100 ? 100 : magia;
            influencias(tipo);
        }

        //influencia da skill
        public void influencias(string tipo) { // 1 = influencia
            hp = (100 * 1) * (vigor * 0.25f);       
            stamina = (50 * 1)*(vigor * 0.10f);                                
            pesomax = (12 * 1) * (resistencia * 0.10f);
            
            if(tipo == "Dano") { //teste novo dano
                dfisico = (1 * (forca * destreza - (magia * 0.025f)) * 0.05f) ;
                dfogo = 0 ;
                draio = 0 ;
                dveneno = 0 ;
                dmagico = (1* (magia * 0.05f * ((vigor + resistencia) * 0.025f)));
            }else{          
                dfisico = (1 * (resistencia * vigor - (magia * 0.025f)) * 0.05f);
                draio = (1 * (resistencia * magia ) * 0.0025f);
                dfogo = (1 * (resistencia * vigor) * 0.0025f);
                dveneno = (1 * (vigor * 0.25f));       
                dmagico = (1* (magia * 0.05f - ((vigor + resistencia ) * 0.025f)));
            }
        }

        //influencia do equipamento
        public float influencias(float n, Equipamento equip){
            foreach (Influencia item in equip.influencia)
            {
                switch (item)
                {
                    case Influencia.Forca:
                        n = n * ((float)forca* ((float)equip.classe * 0.10f));
                        break;
                    case Influencia.Destreza:
                        n = n * ((float)destreza * ((float)equip.classe * 0.10f));
                        break;
                    case Influencia.Resistencia:
                        n = n * ((float)resistencia * ((float)equip.classe * 0.10f));
                        break;
                    case Influencia.Vigor:
                        n = n * ((float)vigor * ((float)equip.classe * 0.10f));
                        break;
                    case Influencia.Nada:
                        ///Return n;
                        break;
                    default:
                        break;
                }
            }
            return n / equip.influencia.Count;
        }
    }
}
