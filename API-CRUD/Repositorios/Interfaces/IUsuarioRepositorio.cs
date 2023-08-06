using API_CRUD.Models;

namespace API_CRUD.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> GetAll(); 

        Task<UsuarioModel> GetById(int id);

        Task<UsuarioModel> Add(UsuarioModel usuario);

        Task<UsuarioModel> Update(UsuarioModel usuario, int id);

        Task<bool> Delete(int id);
    }
}
    