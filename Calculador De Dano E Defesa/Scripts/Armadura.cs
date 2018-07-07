using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculador_De_Dano_E_Defesa.Scripts
{
    public class Armadura : Equipamento
    {
        public Armadura(float dfisico, float draio, float dfogo, float dveneno, float dmagico, List<Influencia> influencia, Classe classe)
        {
            this.dfisico = dfisico;
            this.draio = draio;
            this.dfogo = dfogo;
            this.dveneno = dveneno;
            this.dmagico = dmagico;
            this.influencia = influencia;
            this.classe = classe;
        }
    }
}
