using ControleTarefas.API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ControleTarefas.API.Data.Map
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Status).IsRequired();
            builder.HasKey(x => x.UsuarioId);
            builder.HasOne(x => x.Usuario);

        }
    }
}