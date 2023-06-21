using sistemaServer.Models;

namespace sistemaServer.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<CustomerModel>> GetAllCustomers();
        Task<CustomerModel> GetById(int id);
        Task<CustomerModel> Add(CustomerModel customer);
        Task<CustomerModel> Update(CustomerModel customer, int id);
        Task<bool> Delete(int id);
    }
}
