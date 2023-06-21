using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistemaServer.Context;
using sistemaServer.Models;
using sistemaServer.Repositories.Interfaces;

namespace sistemaServer.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _dbContext;

        public SupplierRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<SupplierModel> GetById(int id)
        {
            return await _dbContext.Suppliers
                .Include(x => x.City)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<SupplierModel>> GetAllSuppliers()
        {
            return await _dbContext.Suppliers
                .Include(x => x.City)
                .ToListAsync();
        }

        public async Task<SupplierModel> Add(SupplierModel supplier)
        {
            await _dbContext.Suppliers.AddAsync(supplier);
            await _dbContext.SaveChangesAsync();

            return supplier;
        }

        public async Task<SupplierModel> Update(SupplierModel supplier, int id)
        {
            SupplierModel supplierById = await GetById(id);

            if (supplierById == null)
            {
                throw new Exception($"Fornecedor para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            supplierById.Name = supplier.Name;
            supplierById.Cnpj = supplier.Cnpj;
            supplierById.Supply = supplier.Supply;
            supplierById.Contact = supplier.Contact;
            supplierById.Email = supplier.Email;
            supplierById.Status = supplier.Status;
            supplierById.CityId = supplier.CityId;

            _dbContext.Suppliers.Update(supplierById);
            await _dbContext.SaveChangesAsync();

            return supplierById;
        }

        public async Task<bool> Delete(int id)
        {
            SupplierModel supplierById = await GetById(id);

            if (supplierById == null)
            {
                throw new Exception($"Fornecedor para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            _dbContext.Suppliers.Remove(supplierById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
