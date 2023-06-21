using sistemaServer.Models;

namespace sistemaServer.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<CountryModel>> GetAllCountries();
        Task<CountryModel> GetById(int id);
        Task<CountryModel> Add(CountryModel country);
        Task<CountryModel> Update(CountryModel country, int id);
        Task<bool> Delete(int id);
    }
}
