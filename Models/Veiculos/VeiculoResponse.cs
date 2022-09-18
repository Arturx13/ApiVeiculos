using Prova_Tinnova_Artur.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova_Tinnova_Artur.Models.Veiculos
{
    public class VeiculoResponse
    {

        public int id { get; set; }
        public string veiculo { get; set; }
        public string descricao { get; set; }
        public string marca { get; set; }
        public int ano { get; set; }
        public bool vendido { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public List<VeiculoResponse> Lista { get; set; }






    }
}
