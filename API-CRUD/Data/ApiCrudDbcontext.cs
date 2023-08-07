using API_CRUD.Data.Map;
using API_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD.Data
{
    public class ApiCrudDbcontext : DbContext
    {
        public ApiCrudDbcontext(DbContextOptions<ApiCrudDbcontext> options) 
            :base(options)
        {

        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
