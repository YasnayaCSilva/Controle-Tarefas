using ControleTarefas.API.Models;
using ControleTarefas.API.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleTarefas.API.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class TarefaController : Controller
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;


        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tarefa>>> BuscarTodosTarefas()
        {
            List<Tarefa> tarefas = await _tarefaRepositorio.BuscarTodasTarefas();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> BuscarPorId(int id)
        {
            Tarefa tarefa = await _tarefaRepositorio.BuscarPorId(id);
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<Tarefa>> Cadastrar([FromBody] Tarefa tarefaModel)
        {
            Tarefa tarefa = await _tarefaRepositorio.Adicionar(tarefaModel);
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Tarefa>> Cadastrar([FromBody] Tarefa tarefaModel, int id)
        {
            tarefaModel.Id = id;
            Tarefa tarefa = await _tarefaRepositorio.Atualizar(tarefaModel, id);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            bool sucesso = await _tarefaRepositorio.Apagar(id);
            return Ok(sucesso);
        }
    }
}