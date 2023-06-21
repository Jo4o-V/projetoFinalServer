using Microsoft.EntityFrameworkCore;
using sistemaServer.Context;
using sistemaServer.Models;
using sistemaServer.Repositories.Interfaces;

namespace sistemaServer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users
                .ToListAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userById = await GetById(id);

            if (userById == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            userById.Name = user.Name;
            userById.LastName = user.LastName;
            userById.UserName = user.UserName;
            userById.Role = user.Role;
            userById.Cpf = user.Cpf;
            userById.Contact = user.Contact;
            userById.Wage = user.Wage;
            userById.Password = user.Password;
            userById.Email = user.Email;
            userById.Status = user.Status;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userById = await GetById(id);

            if (userById == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
