using sistemaServer.Models;

namespace sistemaServer.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllProducts();
        Task<ProductModel> GetById(int id);
        Task<ProductModel> Add(ProductModel product);
        Task<ProductModel> Update(ProductModel product, int id);
        Task<bool> Delete(int id);
    }
}
