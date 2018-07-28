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
        public float DanoFisico {
            get {
                if(arma != null) {
                    return Influencias(danofisico, arma,arma.dfisico);
                }else{
                    return danofisico;
                }
            }
        }
        public float DanoFogo {
            get {
                if (arma != null) {
                    return Influencias(danofogo, arma, arma.dfogo);
                }
                else {
                    return danofogo;
                }
            }
        }        
        public float DanoRaio {
            get {
                if (arma != null){
                    return Influencias(danoraio, arma,arma.draio);
                }else{
                    return danoraio;
                }
            }
        }           
        public float DanoVeneno {
            get {
                if(arma != null) { 
                    return Influencias(danoveneno, arma,arma.dveneno);
                }
                else {
                    return danoveneno;
                }
            }
        }
        public float DanoMagico {
            get {
                if (arma != null){
                    return Influencias(danomagico, arma,arma.dmagico);
                }
                else {
                    return danomagico;
                }
            }
        }

        //com influencias (Defesa)
        public float DefesaFisica {
            get {
                if (armadura != null){
                    return Influencias(defesafisica, armadura , armadura.dfisico);
                }
                else {
                    return defesafisica;
                }
            }
        }
        public float DefesaFogo {
            get {
                if (armadura != null){
                    return Influencias(defesafogo, armadura , armadura.dfogo);
                }
                else{
                    return defesafogo;
                }
            }
        }
        public float DefesaRaio {
            get {
                if (armadura != null){
                    return Influencias(defesaraio, armadura , armadura.draio);
                }else {
                    return defesaraio;
                }
            }
        }
        public float DefesaVeneno {
            get {
                if (armadura != null){
                    return Influencias(defesaveneno, armadura , armadura.dveneno);
                }
                else {
                    return defesaveneno;
                }
            }
        }
        public float DefesaMagica {
            get {
                if (armadura != null){
                    return Influencias(defesamagica, armadura , armadura.dmagico);
                }
                else {
                    return defesamagica;
                }
            }
        }

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

            danofisico = 
                (1 * (forca * destreza - (magia * 0.025f)) * 0.05f) >= 0.0f? 
                (1 * (forca * destreza - (magia * 0.025f)) * 0.05f) : 0.0f ;
            danofogo = 0;
            danoraio = 0;
            danoveneno = 0;
            danomagico = 0;

            defesafisica = 
                (1 * (resistencia * vigor *0.5f) - (magia * 0.05f)) >= 0.0f ?
                (1 * (resistencia * vigor * 0.5f) - (magia * 0.05f)) : 0.0f;
            defesaraio = (1 * (resistencia * magia) * 0.25f);
            defesafogo = (1 * (resistencia * vigor) * 0.25f);
            defesaveneno = (1 * (vigor * 0.25f));
            defesamagica = 
                (1 * (magia * 0.5f) - ((vigor + resistencia) * 0.05f)) >= 0.0f?
                (1 * (magia * 0.5f) - ((vigor + resistencia) * 0.05f)) : 0.0f;
        }
        
        //influencia do equipamento (fixar?) 
        // X =  DMG\DEF = Y = EQUIP.DMG\DEF
        public float Influencias(float x, Equipamento equip,float y){
                foreach (Influencia item in equip.influencia)
                {
                    switch (item)
                    {
                        case Influencia.Forca:
                            x = x + ( (float)forca *  y) * ( (float)equip.classe * 0.10f);
                          //x = 100 + ( (100 * 100) * (5/10))) = 5100 
                            break;
                        case Influencia.Destreza:
                            x = x + ( (float)destreza * y) * ( (float)equip.classe * 0.10f);
                            break;
                        case Influencia.Resistencia:
                            x = x + ((float)resistencia * y) * ( (float)equip.classe * 0.10f);
                            break;
                        case Influencia.Vigor:
                            x = x + ((float)vigor * y) * ( (float)equip.classe * 0.10f);
                            break;
                        case Influencia.Magia:
                            x = x + ((float)magia * y) * ( (float)equip.classe * 0.10f);
                            break;
                        case Influencia.Nada:  
                            return x + y;//( y * ((float)equip.classe * 0.10f));
                        default:
                            break;
                    }
                }
                return x / equip.influencia.Count;
        }
    }
}
