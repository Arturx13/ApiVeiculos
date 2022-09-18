using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova_Tinnova_Artur.Models
{
    public class Fatorial
    {
        public double result { get; set; }

        public Fatorial(int param)
        {

            this.result = BuscaFatorial(param);


        }
        public  double BuscaFatorial(int param)
        {
            double resultado = 1;
            while (param != 1)
            {
                resultado = resultado * param;
                param = param - 1;
            }
            return resultado;
        }

    }


}
