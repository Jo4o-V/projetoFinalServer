using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistemaServer.Models;
using sistemaServer.Repositories.Interfaces;

namespace sistemaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countriesRepository;

        public CountryController(ICountryRepository countriesRepository)
        {
            _countriesRepository = countriesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CountryModel>>> GetAllCountries()
        {
            List<CountryModel> countries = await _countriesRepository.GetAllCountries();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryModel>> GetById(int id)
        {
            CountryModel country = await _countriesRepository.GetById(id);
            return Ok(country);
        }

        [HttpPost]
        public async Task<ActionResult<CountryModel>> Add([FromBody] CountryModel countryModel)
        {
            CountryModel country = await _countriesRepository.Add(countryModel);
            return Ok(country);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CountryModel>> Update([FromBody] CountryModel countryModel, int id)
        {
            countryModel.Id = id;
            CountryModel country = await _countriesRepository.Update(countryModel, id);
            return Ok(country);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CountryModel>> Delete(int id)
        {
            bool countryDelete = await _countriesRepository.Delete(id);
            return Ok(countryDelete);
        }
    }
}
