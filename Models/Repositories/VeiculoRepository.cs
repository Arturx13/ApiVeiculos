using Prova_Tinnova_Artur.Models.Entities;
using Prova_Tinnova_Artur.Models.Veiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova_Tinnova_Artur.Models.Repositories
{
    public class VeiculoRepository
    {

        private static IList<Veiculo> veiculosPardrao = new List<Veiculo>();
        private  IList<Veiculo> veiculo = veiculosPardrao.ToList();


        public Veiculo GetById(int id)
        {

            return veiculo.FirstOrDefault(c => c.id == id);
        }

        public List<Veiculo> GetAll(string marca = "", int ano = 0, string cor = "")
        {
            if (!string.IsNullOrEmpty(marca))
                veiculo = veiculo.Where(c => c.marca.ToUpper().Contains(marca.ToUpper())).ToList();
            if (ano> 0)
                veiculo = veiculo.Where(c => c.ano == ano).ToList();
            if (!string.IsNullOrEmpty(cor))
                veiculo = veiculo.Where(c => c.descricao.Contains(cor)).ToList();

            return veiculo.ToList();
        }

        public bool Save(Veiculo vei)
        {
            vei.id =  veiculo.Count() + 1;

            veiculo.Add(vei);
            veiculosPardrao.Add(vei);
            return true;
        }

        public bool Update(VeiculoRequest vei)
        {
            var edit = veiculo.FirstOrDefault(c => c.id == vei.id);
            edit.veiculo = vei.veiculo;
            edit.ano = vei.ano;
            edit.marca = vei.marca;
            edit.vendido = vei.vendido;
            edit.descricao = vei.descricao;
            edit.updated = DateTime.Now;

            return true;
        }

        public bool Delete(int id)
        {
            var vei = veiculo.FirstOrDefault(c => c.id   == id);
            veiculo.Remove(vei);
            veiculosPardrao.Remove(vei);

            return true;
        }


    }
}
