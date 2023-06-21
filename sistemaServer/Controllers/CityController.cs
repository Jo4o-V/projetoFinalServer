using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistemaServer.Models;
using sistemaServer.Repositories.Interfaces;

namespace sistemaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CityModel>>> GetAllCities()
        {
            List<CityModel> cities = await _cityRepository.GetAllCities();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityModel>> GetById(int id)
        {
            CityModel city = await _cityRepository.GetById(id);
            return Ok(city);
        }

        [HttpPost]
        public async Task<ActionResult<CityModel>> Add([FromBody] CityModel cityModel)
        {
            CityModel city = await _cityRepository.Add(cityModel);
            return Ok(city);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CityModel>> Update([FromBody] CityModel cityModel, int id)
        {
            cityModel.Id = id;
            CityModel city = await _cityRepository.Update(cityModel, id);
            return Ok(city);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CityModel>> Delete(int id)
        {
            bool cityDelete = await _cityRepository.Delete(id);
            return Ok(cityDelete);
        }
    }
}
