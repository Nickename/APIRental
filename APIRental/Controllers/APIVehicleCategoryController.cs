using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class APIVehicleCategoryController : ControllerBase
    {
        private readonly IRepository<VehicleCategory> categoryRep;

        public APIVehicleCategoryController(IRepository<VehicleCategory> categoryRep)
        {
            this.categoryRep = categoryRep;
        }

        // GET: api/<APIVehicleCategoryController>
        [HttpGet]
        public Task<List<VehicleCategory>> Get()
        {
            return categoryRep.GetAllAsync();
        }

        [HttpGet("{id}")]
        public Task<VehicleCategory?> Get(int id)
        {
            return categoryRep.GetByIdAsync(id);
        }

        // POST api/<APIVehicleCategoryController>
        [HttpPost]
        public async Task Post(VehicleCategory category)
        {
            await categoryRep.CreateAsync(category);
        }

        // PUT api/<APIVehicleCategoryController>/5
        [HttpPut]
        public async Task Put(VehicleCategory category)
        {
            await categoryRep.UpdateAsync(category);
        }

        // DELETE api/<APIVehicleCategoryController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var category = await categoryRep.GetByIdAsync(id);
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            await categoryRep.DeleteAsync(category);
            return;
        }
    }
}
