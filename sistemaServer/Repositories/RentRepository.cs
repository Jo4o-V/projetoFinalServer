using Microsoft.EntityFrameworkCore;
using sistemaServer.Context;
using sistemaServer.Models;
using sistemaServer.Repositories.Interfaces;

namespace sistemaServer.Repositories
{
    public class RentRepository : IRentRepository
    {
        private readonly AppDbContext _dbContext;

        public RentRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<RentModel> GetById(int id)
        {
            return await _dbContext.Rents
                .Include(x => x.customerCode)
                .Include(x => x.Code)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<RentModel>> GetAllRents()
        {
            return await _dbContext.Rents
                .Include(x => x.customerCode)
                .Include(x => x.Code)
                .ToListAsync();
        }

        public async Task<RentModel> Add(RentModel rent)
        {
            await _dbContext.Rents.AddAsync(rent);
            await _dbContext.SaveChangesAsync();

            return rent;
        }

        public async Task<RentModel> Update(RentModel rent, int id)
        {
            RentModel rentById = await GetById(id);

            if (rentById == null)
            {
                throw new Exception($"Aluguel para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            rentById.rentCode = rent.rentCode;
            rentById.customerCode = rent.customerCode;
            rentById.Code = rent.Code;
            rentById.Amount = rent.Amount;
            rentById.Status = rent.Status;

            _dbContext.Rents.Update(rentById);
            await _dbContext.SaveChangesAsync();

            return rentById;
        }

        public async Task<bool> Delete(int id)
        {
            RentModel rentById = await GetById(id);

            if (rentById == null)
            {
                throw new Exception($"Aluguel para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            _dbContext.Rents.Remove(rentById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
