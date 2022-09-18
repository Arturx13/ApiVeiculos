
using Prova_Tinnova_Artur.Models.Veiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova_Tinnova_Artur.Models.Entities
{
    public class Veiculo
    {

        public  Veiculo(VeiculoRequest request)
        {
            var random = new Random();
            ExternalId = "cus_" + random.Next(999999);
            veiculo = request.veiculo;
            descricao = request.descricao;
            marca = request.marca;
            ano = request.ano;
            vendido = request.vendido;
            created = DateTime.Now;

        }

        public Veiculo()
        {
    

        }


        public int id { get; set; }
        public string ExternalId { get; set; }
        public string veiculo { get; set; }
        public string descricao { get; set; }
        public string marca { get; set; }
        public int ano { get; set; }
        public bool vendido { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }



    }
}
