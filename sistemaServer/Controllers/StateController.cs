using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistemaServer.Models;
using sistemaServer.Repositories.Interfaces;

namespace sistemaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateRepository _stateRepository;

        public StateController(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<StateModel>>> GetAllStates()
        {
            List<StateModel> states = await _stateRepository.GetAllStates();
            return Ok(states);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StateModel>> GetById(int id)
        {
            StateModel state = await _stateRepository.GetById(id);
            return Ok(state);
        }

        [HttpPost]
        public async Task<ActionResult<StateModel>> Add([FromBody] StateModel stateModel)
        {
            StateModel state = await _stateRepository.Add(stateModel);
            return Ok(state);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StateModel>> Update([FromBody] StateModel stateModel, int id)
        {
            stateModel.Id = id;
            StateModel state = await _stateRepository.Update(stateModel, id);
            return Ok(state);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StateModel>> Delete(int id)
        {
            bool stateDelete = await _stateRepository.Delete(id);
            return Ok(stateDelete);
        }
    }
}
