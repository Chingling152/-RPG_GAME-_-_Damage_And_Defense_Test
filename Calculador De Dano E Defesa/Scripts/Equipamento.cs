using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculador_De_Dano_E_Defesa.Scripts
{
    public enum Influencia{
        Forca,
        Destreza,
        Resistencia,
        Vigor
    }

    public enum Tipo {
        Arma, Armadura//?
    }

    public enum Classe {
        A = 10,
        B = 20,
        C = 30,
        D = 40,
        E = 50
    }

    public class Equipamento
    {
        public float dfisico , draio, dfogo, dveneno;
        public List<Influencia> influencia;
        public Classe classe;

        public Equipamento(float dfisico, float draio, float dfogo, float dveneno, List<Influencia> influencia,Classe classe,string tipo)
        {
            this.dfisico = dfisico;
            this.draio = draio;
            this.dfogo = dfogo;
            this.dveneno = dveneno;
            this.influencia = influencia;
            this.classe = classe;
        }

    }
}
