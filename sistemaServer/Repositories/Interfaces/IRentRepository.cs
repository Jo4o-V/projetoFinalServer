using sistemaServer.Models;

namespace sistemaServer.Repositories.Interfaces
{
    public interface IRentRepository
    {
        Task<List<RentModel>> GetAllRents();
        Task<RentModel> GetById(int id);
        Task<RentModel> Add(RentModel rent);
        Task<RentModel> Update(RentModel rent, int id);
        Task<bool> Delete(int id);
    }
}
