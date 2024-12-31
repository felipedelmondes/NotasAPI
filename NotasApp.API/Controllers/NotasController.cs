using Microsoft.AspNetCore.Mvc;
using NotasApp.BLL.DTO;
using NotasApp.BLL.Interfaces.Services;
using NotasApp.BLL.ViewModels;

namespace NotasApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotasController:ControllerBase
    {
        private readonly INotasServices _service;
        public NotasController(INotasServices service)
        {
            _service = service;
        }

        [HttpGet]
        public List<NotasDTO> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public NotaViewModel GetById(int id)
        {
            if (id == null)
            {
                return null;
            }
            return _service.getById(id);
        }

        [HttpPost]
        [Route("AdicionarNota")]
        public string Post([FromForm] NotaViewModel notas)
        {
            return _service.addnota(notas);
        }

        [HttpPut]
        [Route("AtualizarNota")]
        public string AtualizaNota(int notaId, NotaViewModel nota)
        {
            return _service.updatenota(notaId, nota);
        }

        [HttpDelete]
        [Route("ExcluirNota/{notaId}")]
        public string ExcluirNota(int notaId)
        {
            if (notaId == null)
            {
                return "Erro, ID Invalido";
            }
            _service.deleteNota(notaId);

            return "Sucesso ao excluir a nota " + notaId;
        }
    
    }

}