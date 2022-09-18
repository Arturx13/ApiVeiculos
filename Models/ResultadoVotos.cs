using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova_Tinnova_Artur.Models
{
    public class ResultadoVotos
    {
        private int max { get; set; } = 1000;
        public double percentualValidosTotal { get; set; } = 800;
        public double percentualBrancos { get; set; } = 150;
        public double percentualVtsNulos { get; set; } = 50;
        private double percentual { get; set; } = 100;
        public ResultadoVotos()
        {
            CalcularPercentualValidosTotal();
            CalcularPercentualBrancosTotal();
            CalcularPercentualVtsNulos();
        }

        public int CalcularPercentualValidosTotal()
        {
            return Convert.ToInt32(this.percentualValidosTotal = (this.percentualValidosTotal * this.percentual) / this.max);

        }
        public int CalcularPercentualBrancosTotal()
        {
            return Convert.ToInt32(this.percentualBrancos = (this.percentualBrancos * this.percentual) / this.max);

        }
        public int CalcularPercentualVtsNulos()
        {
            return Convert.ToInt32(this.percentualVtsNulos = (this.percentualVtsNulos * this.percentual) / this.max);
        }


    }
}
