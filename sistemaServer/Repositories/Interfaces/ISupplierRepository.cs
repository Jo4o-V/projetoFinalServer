using Microsoft.AspNetCore.Mvc;
using sistemaServer.Models;

namespace sistemaServer.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        Task<List<SupplierModel>> GetAllSuppliers();
        Task<SupplierModel> GetById(int id);
        Task<SupplierModel> Add(SupplierModel supplier);
        Task<SupplierModel> Update(SupplierModel supplier, int id);
        Task<bool> Delete(int id);
    }
}
