using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prova_Tinnova_Artur.Models;

using Prova_Tinnova_Artur.Models.Entities;
using Prova_Tinnova_Artur.Models.Repositories;
using Prova_Tinnova_Artur.Models.Veiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova_Tinnova_Artur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly VeiculoRepository _veiculoRepository;
        private readonly List<VeiculoResponse> _Lista;
        public VeiculosController()
        {

            _veiculoRepository = new VeiculoRepository();
            _Lista = new List<VeiculoResponse>();
        }
        [HttpPost]
        public IActionResult Post(VeiculoRequest request)
        {
            var registro = new Veiculo(request);

            if (!ValidaMarca(registro.marca.ToUpper()))
                return StatusCode(400, "Marca do veiculo Inexistente!");
       

            _veiculoRepository.Save(registro);
            var response = CreateResponse(registro);
            return StatusCode(201, response);
        }

        [HttpGet]
        public IActionResult Get(int id = 0, string marca = "", int ano = 0, string cor = "")
        {
            if (id == 0)
            {
                List<Veiculo> registros = _veiculoRepository.GetAll(string.IsNullOrEmpty(marca) ? marca : marca.ToUpper(), ano, cor).ToList();

                var response = CreateResponse(registros);
                return StatusCode(200, response);
            }
            else
            {
                Veiculo registro = _veiculoRepository.GetById(id);
                var response = CreateResponse(registro);
                return StatusCode(200, response);         
            }
        }



        [HttpPut]
        public IActionResult Put(VeiculoRequest request)
        {
            if (!ValidaMarca(request.marca.ToUpper()))
                return StatusCode(400, "Marca do veiculo Inexistente!");
         

            bool registro = _veiculoRepository.Update(request);


            return StatusCode(204 , registro ? "Editado" : "Não foi possivel editar o registro informado");
          
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
           bool delete = _veiculoRepository.Delete(id);

            return StatusCode(204, delete ? "Registro Excluido" : "Não foi possivel excluir o Veiculo informado!");
        }


        [HttpPatch]
        public IActionResult Path(VeiculoRequest request)
        {
            if (!ValidaMarca(request.marca.ToUpper()))
                return StatusCode(400, "Marca do veiculo Inexistente!");

            bool registro = _veiculoRepository.Update(request);
            return StatusCode(204, registro ? "Editado" : "Não foi possivel editar o registro informado");

        }


        [HttpGet]
        [Route("ResultadoVotos")]
        public IActionResult ResultadoVotos()
        {

            return StatusCode(200, new ResultadoVotos());
        }

        [HttpGet]
        [Route("SomaMultiplos")]
        public IActionResult SomaMultiplos(int numero)
        {

            return StatusCode(200, new Multiplos(numero));
        }

        [HttpGet]
        [Route("RetonaFatorial")]
        public IActionResult RetonaFatorial(int numero)
        {
            return StatusCode(200, new Fatorial(numero));
        }



        [HttpGet]
        [Route("BubbleSort")]
        public IActionResult BubbleSort()
        {

            return StatusCode(200, new BubbleSort());
        }

        private VeiculoResponse CreateResponse(Veiculo veiculo)
        {
            return new VeiculoResponse
            {
                id = veiculo.id,
                veiculo = veiculo.veiculo,
                descricao = veiculo.descricao,
                ano = veiculo.ano,
                marca = veiculo.marca,
                vendido = veiculo.vendido,
                updated = veiculo.updated,
                created = veiculo.created,

            };

        }
        private List<VeiculoResponse> CreateResponse(List<Veiculo> veiculo)
        {
            foreach (Veiculo registro in veiculo)
                _Lista.Add(CreateResponse(registro));

            return _Lista;
        }

        private bool ValidaMarca(string marca)
        {
            if (!new MarcasDemo().Lista.Contains(marca.ToUpper()))
                return false;
            else return true;
        }

    }
}
