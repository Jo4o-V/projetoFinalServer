using Microsoft.EntityFrameworkCore;
using sistemaServer.Context;
using sistemaServer.Models;
using sistemaServer.Repositories.Interfaces;

namespace sistemaServer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _dbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<CustomerModel> GetById(int id)
        {
            return await _dbContext.Customers
                .FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<List<CustomerModel>> GetAllCustomers()
        {
            return await _dbContext.Customers
                .ToListAsync();
        }

        public async Task<CustomerModel> Add(CustomerModel customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();

            return customer;
        }

        public async Task<CustomerModel> Update(CustomerModel customer, int id)
        {
            CustomerModel customerById = await GetById(id);

            if (customerById == null)
            {
                throw new Exception($"Cliente para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            customerById.Name = customer.Name;
            customerById.LastName = customer.LastName;
            customerById.Cpf = customer.Cpf;
            customerById.Contact = customer.Contact;
            customerById.Email = customer.Email;
            customerById.Address = customer.Address;
            customerById.Status = customer.Status;
            customerById.City = customer.City;

            _dbContext.Customers.Update(customerById);
            await _dbContext.SaveChangesAsync();

            return customerById;
        }

        public async Task<bool> Delete(int id)
        {
            CustomerModel customerById = await GetById(id);

            if (customerById == null)
            {
                throw new Exception($"Cliente para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            _dbContext.Customers.Remove(customerById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
