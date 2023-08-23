using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class APICustomerController : ControllerBase
    {
        private readonly IRepository<Customer> customerRep;

        public APICustomerController(IRepository<Customer> customerRep)
        {
            this.customerRep = customerRep;
        }

        // GET: api/<APICustomerController>
        [HttpGet]
        public Task<List<Customer>> Get()
        {
            return customerRep.GetAllAsync();
        }

        [HttpGet("{id}")]
        public Task<Customer?> Get(int id)
        {
            return customerRep.GetByIdAsync(id);
        }

        // POST api/<APICustomerController>
        [HttpPost]
        public async Task Post(Customer customer)
        {
            await customerRep.CreateAsync(customer);
        }

        // PUT api/<APICustomerController>/5
        [HttpPut]
        public async Task Put(Customer customer)
        {
            await customerRep.UpdateAsync(customer);
        }

        // DELETE api/<APICustomerController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var customer = await customerRep.GetByIdAsync(id);
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            await customerRep.DeleteAsync(customer);
            return;
        }
    }
}
