using Microsoft.EntityFrameworkCore;
using sistemaServer.Context;
using sistemaServer.Models;
using sistemaServer.Repositories.Interfaces;

namespace sistemaServer.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly AppDbContext _dbContext;

        public StateRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<StateModel> GetById(int id)
        {
            return await _dbContext.States
                .Include(x => x.Country)
                .FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<List<StateModel>> GetAllStates()
        {
            return await _dbContext.States
                .Include(x => x.Country)
                .ToListAsync();
        }

        public async Task<StateModel> Add(StateModel state)
        {
            await _dbContext.States.AddAsync(state);
            await _dbContext.SaveChangesAsync();

            return state;
        }

        public async Task<StateModel> Update(StateModel state, int id)
        {
            StateModel stateById = await GetById(id);

            if (stateById == null)
            {
                throw new Exception($"Estado para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            stateById.Name = state.Name;
            stateById.Acronym = state.Acronym;
            stateById.Status = state.Status;
            stateById.CountryId = state.CountryId;

            _dbContext.States.Update(stateById);
            await _dbContext.SaveChangesAsync();

            return stateById;
        }

        public async Task<bool> Delete(int id)
        {
            StateModel stateById = await GetById(id);

            if (stateById == null)
            {
                throw new Exception($"Estado para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            _dbContext.States.Remove(stateById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
