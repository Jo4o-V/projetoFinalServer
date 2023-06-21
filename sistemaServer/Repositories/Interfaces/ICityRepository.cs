using sistemaServer.Models;

namespace sistemaServer.Repositories.Interfaces
{
    public interface ICityRepository
    {
        Task<List<CityModel>> GetAllCities();
        Task<CityModel> GetById(int id);
        Task<CityModel> Add(CityModel city);
        Task<CityModel> Update(CityModel city, int id);
        Task<bool> Delete(int id);
    }
}
