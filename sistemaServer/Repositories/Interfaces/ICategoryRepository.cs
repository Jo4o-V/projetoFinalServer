using sistemaServer.Models;

namespace sistemaServer.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryModel>> GetAllCategories();
        Task<CategoryModel> GetById(int id);
        Task<CategoryModel> Add(CategoryModel category);
        Task<CategoryModel> Update(CategoryModel category, int id);
        Task<bool> Delete(int id);
    }
}
