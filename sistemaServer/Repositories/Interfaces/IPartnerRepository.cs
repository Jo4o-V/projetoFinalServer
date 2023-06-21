using sistemaServer.Models;

namespace sistemaServer.Repositories.Interfaces
{
    public interface IPartnerRepository
    {
        Task<List<PartnerModel>> GetAllPartners();
        Task<PartnerModel> GetById(int id);
        Task<PartnerModel> Add(PartnerModel partner);
        Task<PartnerModel> Update(PartnerModel partner, int id);
        Task<bool> Delete(int id);
    }
}
