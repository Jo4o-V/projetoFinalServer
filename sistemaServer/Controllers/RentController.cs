using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistemaServer.Models;
using sistemaServer.Repositories.Interfaces;

namespace sistemaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IRentRepository _rentRepository;

        public RentController(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<RentModel>>> GetAllRents()
        {
            List<RentModel> rents = await _rentRepository.GetAllRents();
            return Ok(rents);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RentModel>> GetById(int id)
        {
            RentModel rent = await _rentRepository.GetById(id);
            return Ok(rent);
        }

        [HttpPost]
        public async Task<ActionResult<RentModel>> Add([FromBody] RentModel rentModel)
        {
            RentModel rent = await _rentRepository.Add(rentModel);
            return Ok(rent);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RentModel>> Update([FromBody] RentModel rentModel, int id)
        {
            rentModel.Id = id;
            RentModel rent = await _rentRepository.Update(rentModel, id);
            return Ok(rent);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RentModel>> Delete(int id)
        {
            bool rentDelete = await _rentRepository.Delete(id);
            return Ok(rentDelete);
        }
    }
}
