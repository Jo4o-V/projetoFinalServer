using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistemaServer.Models;
using sistemaServer.Repositories.Interfaces;

namespace sistemaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepository _supplierRepository;

        public  SupplierController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<SupplierModel>>> GetAllSuppliers()
        {
            List<SupplierModel> suppliers = await _supplierRepository.GetAllSuppliers();
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierModel>> GetById(int id)
        {
            SupplierModel supplier = await _supplierRepository.GetById(id);
            return Ok(supplier);
        }

        [HttpPost]
        public async Task<ActionResult<SupplierModel>> Add([FromBody] SupplierModel supplierModel)
        {
            SupplierModel supplier = await _supplierRepository.Add(supplierModel);
            return Ok(supplier);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SupplierModel>> Update([FromBody] SupplierModel supplierModel, int id)
        {
            supplierModel.Id = id;
            SupplierModel supplier = await _supplierRepository.Update(supplierModel, id);
            return Ok(supplier);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SupplierModel>> Delete(int id)
        {
            bool supplierDelete = await _supplierRepository.Delete(id);
            return Ok(supplierDelete);
        }
    }
}
