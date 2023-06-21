using sistemaServer.Models;

namespace sistemaServer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetById(int id);
        Task<UserModel> Update(UserModel user, int id);
        Task<bool> Delete(int id);
    }
}
