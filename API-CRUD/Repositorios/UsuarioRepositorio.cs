using API_CRUD.Data;
using API_CRUD.Models;
using API_CRUD.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly ApiCrudDbcontext _dbContext;

        public UsuarioRepositorio(ApiCrudDbcontext apiCrudDbcontext)
        {
            _dbContext = apiCrudDbcontext;
        }


        public async Task<List<UsuarioModel>> GetAll()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> GetById(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UsuarioModel> Add(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Delete(int id)
        {
            UsuarioModel usuaPorId = await GetById(id);

            if (usuaPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} nao foi encontrado no banco de dados");
            }

            _dbContext.Usuarios.Remove(usuaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<UsuarioModel> Update(UsuarioModel usuario, int id)
        {
            UsuarioModel usuaPorId = await GetById(id);

            if(usuaPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} nao foi encontrado no banco de dados");
            }

            usuaPorId.Nome = usuario.Nome;
            usuaPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuaPorId);
            await _dbContext.SaveChangesAsync();

            return usuaPorId;
        }
    }
}
