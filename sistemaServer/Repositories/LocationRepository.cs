using Microsoft.EntityFrameworkCore;
using sistemaServer.Context;
using sistemaServer.Models;
using sistemaServer.Repositories.Interfaces;

namespace sistemaServer.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _dbContext;

        public LocationRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<LocationModel> GetById(int id)
        {
            return await _dbContext.Locations
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<LocationModel>> GetAllLocations()
        {
            return await _dbContext.Locations
                .ToListAsync();
        }

        public async Task<LocationModel> Add(LocationModel location)
        {
            await _dbContext.Locations.AddAsync(location);
            await _dbContext.SaveChangesAsync();

            return location;
        }

        public async Task<LocationModel> Update(LocationModel location, int id)
        {
            LocationModel locationById = await GetById(id);

            if (locationById == null)
            {
                throw new Exception($"Local para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            locationById.Name = location.Name;
            locationById.Contact = location.Contact;
            locationById.Email = location.Email;
            locationById.StockType = location.StockType;
            locationById.QtdTotal = location.QtdTotal;
            locationById.Status = location.Status;

            _dbContext.Locations.Update(locationById);
            await _dbContext.SaveChangesAsync();

            return locationById;
        }

        public async Task<bool> Delete(int id)
        {
            LocationModel locationById = await GetById(id);

            if (locationById == null)
            {
                throw new Exception($"Local para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            _dbContext.Locations.Remove(locationById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
