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
        public int forca , destreza , resistencia , vigor;
        public float dfisico, dfogo , draio , dveneno;
        public Equipamento equipamento;

        public Player() { 
        }

        public Player(float hp, float stamina, float pesomax, int forca, int destreza, int resistencia, int vigor,string tipo)
        {
            this.hp = hp;
            this.stamina = stamina;
            this.pesomax = pesomax;
            this.forca = Player.SaveCap(forca);
            this.destreza = Player.SaveCap(destreza);
            this.resistencia = Player.SaveCap(resistencia);
            this.vigor = Player.SaveCap(vigor);
            influencias(tipo);
        }

        public void influencias(string tipo) { // 1 = influencia
            hp = (100 * 1) * (vigor * 0.25f);       
            stamina = (50 * 1)*(vigor * 0.10f);                                
            pesomax = (12 * 1) * (resistencia * 0.10f);
            
            if(tipo == "Dano") { 
                dfisico = (1 * (forca * destreza) * 0.05f);
                dfogo = 0 ;
                draio = 0 ;
                dveneno = 0 ;
            }else{          
                dfisico = (1 * (resistencia * vigor) * 0.05f);
                draio = (1 * (resistencia * 0.25f));
                dfogo = (1 * (resistencia * vigor) * 0.10f);
                dveneno = (1 * (vigor * 0.25f));          
            }
        }

        public static int SaveCap(int numero) {
            if (numero > 100){
                numero = 100;
            }
            return numero;
        }
    }
}
