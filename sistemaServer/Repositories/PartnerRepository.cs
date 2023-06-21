using Microsoft.EntityFrameworkCore;
using sistemaServer.Context;
using sistemaServer.Models;
using sistemaServer.Repositories.Interfaces;

namespace sistemaServer.Repositories
{
    public class PartnerRepository : IPartnerRepository
    {
        private readonly AppDbContext _dbContext;

        public PartnerRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<PartnerModel> GetById(int id)
        {
            return await _dbContext.Partners
                .Include(x => x.City)
                .FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<List<PartnerModel>> GetAllPartners()
        {
            return await _dbContext.Partners
                .Include(x => x.City)
                .ToListAsync();
        }

        public async Task<PartnerModel> Add(PartnerModel partner)
        {
            await _dbContext.Partners.AddAsync(partner);
            await _dbContext.SaveChangesAsync();

            return partner;
        }

        public async Task<PartnerModel> Update(PartnerModel partner, int id)
        {
            PartnerModel partnerById = await GetById(id);

            if (partnerById == null)
            {
                throw new Exception($"Parceiro para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            partnerById.Name = partner.Name;
            partnerById.Cnpj = partner.Cnpj;
            partnerById.Partnership = partner.Partnership;
            partnerById.Contact = partner.Contact;
            partnerById.Email = partner.Email;
            partnerById.Status = partner.Status;
            partnerById.CityId = partner.CityId;

            _dbContext.Partners.Update(partnerById);
            await _dbContext.SaveChangesAsync();

            return partnerById;
        }

        public async Task<bool> Delete(int id)
        {
            PartnerModel partnerById = await GetById(id);

            if (partnerById == null)
            {
                throw new Exception($"Parceiro para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            _dbContext.Partners.Remove(partnerById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
