using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistemaServer.Context;
using sistemaServer.Models;
using sistemaServer.Repositories.Interfaces;

namespace sistemaServer.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _dbContext;

        public CountryRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<CountryModel> GetById(int id)
        {
            return await _dbContext.Countries.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<List<CountryModel>> GetAllCountries()
        {
            return await _dbContext.Countries.ToListAsync();
        }

        public async Task<CountryModel> Add(CountryModel country)
        {
            await _dbContext.Countries.AddAsync(country);
            await _dbContext.SaveChangesAsync();

            return country;
        }

        public async Task<CountryModel> Update(CountryModel country, int id)
        {
            CountryModel countryById = await GetById(id);

            if (countryById == null)
            {
                throw new Exception($"País para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            countryById.Name = country.Name;
            countryById.Acronym = country.Acronym;
            countryById.Continent = country.Continent;
            countryById.Status = country.Status;

            _dbContext.Countries.Update(countryById);
            await _dbContext.SaveChangesAsync();

            return countryById;
        }

        public async Task<bool> Delete(int id)
        {
            CountryModel countryById = await GetById(id);

            if (countryById == null)
            {
                throw new Exception($"País para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            _dbContext.Countries.Remove(countryById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
