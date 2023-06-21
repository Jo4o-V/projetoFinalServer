using Microsoft.EntityFrameworkCore;
using sistemaServer.Context;
using sistemaServer.Models;
using sistemaServer.Repositories.Interfaces;

namespace sistemaServer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<CategoryModel> GetById(int id)
        {
            return await _dbContext.Categories
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CategoryModel>> GetAllCategories()
        {
            return await _dbContext.Categories
                .ToListAsync();
        }

        public async Task<CategoryModel> Add(CategoryModel category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<CategoryModel> Update(CategoryModel category, int id)
        {
            CategoryModel categoryById = await GetById(id);

            if (categoryById == null)
            {
                throw new Exception($"Categoria para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            categoryById.Code = category.Code;
            categoryById.Category = category.Category;
            categoryById.Type = category.Type;
            categoryById.Status = category.Status;

            _dbContext.Categories.Update(categoryById);
            await _dbContext.SaveChangesAsync();

            return categoryById;
        }

        public async Task<bool> Delete(int id)
        {
            CategoryModel categoryById = await GetById(id);

            if (categoryById == null)
            {
                throw new Exception($"Categoria para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            _dbContext.Categories.Remove(categoryById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
