using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistemaServer.Models;
using sistemaServer.Repositories.Interfaces;

namespace sistemaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerModel>>> GetAllCustomers()
        {
            List<CustomerModel> customers = await _customerRepository.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerModel>> GetById(int id)
        {
            CustomerModel customer = await _customerRepository.GetById(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerModel>> Add([FromBody] CustomerModel customerModel)
        {
            CustomerModel customer = await _customerRepository.Add(customerModel);
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerModel>> Update([FromBody] CustomerModel customerModel, int id)
        {
            customerModel.Id = id;
            CustomerModel customer = await _customerRepository.Update(customerModel, id);
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerModel>> Delete(int id)
        {
            bool customerDelete = await _customerRepository.Delete(id);
            return Ok(customerDelete);
        }
    }
}
