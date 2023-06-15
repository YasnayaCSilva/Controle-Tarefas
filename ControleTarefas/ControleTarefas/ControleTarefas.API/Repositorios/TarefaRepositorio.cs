using ControleTarefas.API.Data;
using ControleTarefas.API.Models;
using ControleTarefas.API.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;


public class TarefaRepositorio : ITarefaRepositorio
{
    private readonly ControleTarefasDBContext _dbContext;
    public TarefaRepositorio(ControleTarefasDBContext controleTarefasDBContext)
    {
        _dbContext = controleTarefasDBContext;
    }

    public async Task<Tarefa> Adicionar(Tarefa tarefa)
    {
        await _dbContext.Tarefas.AddAsync(tarefa);
        await _dbContext.SaveChangesAsync();
        return tarefa;
    }

    public async Task<bool> Apagar(int id)
    {
        Tarefa tarefaPorId = await BuscarPorId(id);
        if (tarefaPorId == null) throw new Exception("Tarefa para o Id " + id.ToString() + " não foi encontrado.");

        _dbContext.Tarefas.Remove(tarefaPorId);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Tarefa> Atualizar(Tarefa tarefa, int id)
    {
        Tarefa tarefaPorId = await BuscarPorId(id);
        if (tarefaPorId == null) throw new Exception("Tarefa para o Id " + id.ToString() + " não foi encontrado.");

        tarefaPorId.Nome = tarefa.Nome;
        tarefaPorId.Descricao = tarefa.Descricao;
        tarefaPorId.Status = tarefa.Status;
        tarefaPorId.Usuario = tarefa.Usuario;

        _dbContext.Tarefas.Update(tarefaPorId);
        await _dbContext.SaveChangesAsync();

        return tarefaPorId;
    }

    public async Task<Tarefa> BuscarPorId(int id)
    {
        return await _dbContext.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Tarefa>> BuscarTodasTarefas()
    {
        return await _dbContext.Tarefas.ToListAsync();
    }
}