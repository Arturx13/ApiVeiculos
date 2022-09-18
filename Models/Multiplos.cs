using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova_Tinnova_Artur.Models
{
    public class Multiplos
    {
        private int tres { get; set; } = 3;
        private int cinco { get; set; } = 5;
        public int result { get; set; } = 0;
        public Multiplos(int param)
        {
            for (int i = 0; i < param; i++)
            {
                if (i % tres == 0 || i % cinco == 0)
                    result += i;
            }


        }


    }
}
