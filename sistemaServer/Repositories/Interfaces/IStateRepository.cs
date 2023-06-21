using sistemaServer.Models;

namespace sistemaServer.Repositories.Interfaces
{
    public interface IStateRepository
    {
        Task<List<StateModel>> GetAllStates();
        Task<StateModel> GetById(int id);
        Task<StateModel> Add(StateModel satate);
        Task<StateModel> Update(StateModel satate, int id);
        Task<bool> Delete(int id);
    }
}
