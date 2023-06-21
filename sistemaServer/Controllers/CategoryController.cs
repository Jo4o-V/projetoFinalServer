using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistemaServer.Models;
using sistemaServer.Repositories.Interfaces;

namespace sistemaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryModel>>> GetAllCategories()
        {
            List<CategoryModel> categories = await _categoryRepository.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> GetById(int id)
        {
            CategoryModel category = await _categoryRepository.GetById(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryModel>> Add([FromBody] CategoryModel categoryModel)
        {
            CategoryModel category = await _categoryRepository.Add(categoryModel);
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryModel>> Update([FromBody] CategoryModel categoryModel, int id)
        {
            categoryModel.Id = id;
            CategoryModel category = await _categoryRepository.Update(categoryModel, id);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryModel>> Delete(int id)
        {
            bool categoryDelete = await _categoryRepository.Delete(id);
            return Ok(categoryDelete);
        }
    }
}
