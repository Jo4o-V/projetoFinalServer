using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistemaServer.Models;
using sistemaServer.Repositories.Interfaces;

namespace sistemaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<LocationModel>>> GetAllLocations()
        {
            List<LocationModel> locations = await _locationRepository.GetAllLocations();
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocationModel>> GetById(int id)
        {
            LocationModel location = await _locationRepository.GetById(id);
            return Ok(location);
        }

        [HttpPost]
        public async Task<ActionResult<LocationModel>> Add([FromBody] LocationModel locationModel)
        {
            LocationModel location = await _locationRepository.Add(locationModel);
            return Ok(location);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LocationModel>> Update([FromBody] LocationModel locationModel, int id)
        {
            locationModel.Id = id;
            LocationModel location = await _locationRepository.Update(locationModel, id);
            return Ok(location);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<LocationModel>> Delete(int id)
        {
            bool locationDelete = await _locationRepository.Delete(id);
            return Ok(locationDelete);
        }
    }
}
