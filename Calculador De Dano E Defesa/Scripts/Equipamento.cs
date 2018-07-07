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
        Vigor,
        Magia,
        Nada
    }

    public enum Classe {
        A = 5,
        B = 4,
        C = 3,
        D = 2,
        E = 1
    }

    public abstract class Equipamento
    {
        public float dfisico , draio, dfogo, dveneno, dmagico;
        public List<Influencia> influencia;
        public Classe classe;       
    }
}
