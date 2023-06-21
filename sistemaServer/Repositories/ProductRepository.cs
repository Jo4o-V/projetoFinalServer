using Microsoft.EntityFrameworkCore;
using sistemaServer.Context;
using sistemaServer.Models;
using sistemaServer.Repositories.Interfaces;

namespace sistemaServer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<ProductModel> GetById(int id)
        {
            return await _dbContext.Products
                .Include(x => x.Type)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            return await _dbContext.Products
                .Include(x => x.Type)
                .ToListAsync();
        }

        public async Task<ProductModel> Add(ProductModel product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<ProductModel> Update(ProductModel product, int id)
        {
            ProductModel productById = await GetById(id);

            if (productById == null)
            {
                throw new Exception($"Produto para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            productById.Code = product.Code;
            productById.Range = product.Range;
            productById.Color = product.Color;
            productById.Value = product.Value;
            productById.Status = product.Status;
            productById.TypeId = product.TypeId;

            _dbContext.Products.Update(productById);
            await _dbContext.SaveChangesAsync();

            return productById;
        }

        public async Task<bool> Delete(int id)
        {
            ProductModel productById = await GetById(id);

            if (productById == null)
            {
                throw new Exception($"Produto para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            _dbContext.Products.Remove(productById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
