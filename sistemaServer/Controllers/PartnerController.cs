using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistemaServer.Models;
using sistemaServer.Repositories.Interfaces;

namespace sistemaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerRepository _partnerRepository;

        public PartnerController(IPartnerRepository partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PartnerModel>>> GetAllPartners()
        {
            List<PartnerModel> partners = await _partnerRepository.GetAllPartners();
            return Ok(partners);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PartnerModel>> GetById(int id)
        {
            PartnerModel partner = await _partnerRepository.GetById(id);
            return Ok(partner);
        }

        [HttpPost]
        public async Task<ActionResult<PartnerModel>> Add([FromBody] PartnerModel partnerModel)
        {
            PartnerModel partner = await _partnerRepository.Add(partnerModel);
            return Ok(partner);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PartnerModel>> Update([FromBody] PartnerModel partnerModel, int id)
        {
            partnerModel.Id = id;
            PartnerModel partner = await _partnerRepository.Update(partnerModel, id);
            return Ok(partner);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PartnerModel>> Delete(int id)
        {
            bool partnerDelete = await _partnerRepository.Delete(id);
            return Ok(partnerDelete);
        }
    }
}
