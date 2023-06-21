using sistemaServer.Models;

namespace sistemaServer.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        Task<List<LocationModel>> GetAllLocations();
        Task<LocationModel> GetById(int id);
        Task<LocationModel> Add(LocationModel location);
        Task<LocationModel> Update(LocationModel location, int id);
        Task<bool> Delete(int id);
    }
}
