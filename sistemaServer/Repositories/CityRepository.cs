using Microsoft.EntityFrameworkCore;
using sistemaServer.Context;
using sistemaServer.Models;
using sistemaServer.Repositories.Interfaces;

namespace sistemaServer.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _dbContext;

        public CityRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<CityModel> GetById(int id)
        {
            return await _dbContext.Cities
                .Include(x => x.State)
                .Include(x => x.State.Country)
                .FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<List<CityModel>> GetAllCities()
        {
            return await _dbContext.Cities
                .Include(x => x.State)
                .Include(x => x.State.Country)
                .ToListAsync();
        }

        public async Task<CityModel> Add(CityModel city)
        {
            await _dbContext.Cities.AddAsync(city);
            await _dbContext.SaveChangesAsync();

            return city;
        }

        public async Task<CityModel> Update(CityModel city, int id)
        {
            CityModel cityById = await GetById(id);

            if (cityById == null)
            {
                throw new Exception($"Cidade para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            cityById.Name = city.Name;
            cityById.Status = city.Status;
            cityById.StateId = city.StateId;

            _dbContext.Cities.Update(cityById);
            await _dbContext.SaveChangesAsync();

            return cityById;
        }

        public async Task<bool> Delete(int id)
        {
            CityModel cityById = await GetById(id);

            if (cityById == null)
            {
                throw new Exception($"Cidade para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            _dbContext.Cities.Remove(cityById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
