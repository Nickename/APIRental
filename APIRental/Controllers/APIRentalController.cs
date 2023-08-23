using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace APIRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class APIRentalController : ControllerBase
    {
        private readonly IRepository<Rental> rentalRep;

        public APIRentalController(IRepository<Rental> rentalRep)
        {
            this.rentalRep = rentalRep;
        }

        // GET: api/<APIRentalController>
        [HttpGet]
        public Task<List<Rental>> Get()
        {
            return rentalRep.GetAllAsync();
        }

        //GET api/<APIRentalController>/5
        [HttpGet("filter/{filter}")]
        public async Task<ActionResult<IEnumerable<Rental>>> Get(string? filter = null)
        {
            if (await rentalRep.GetAllAsync() == null)
            {
                return NotFound();
            }
            if (filter == null)
            {
                return await rentalRep.GetAllAsync();
            }

            var p = Expression.Parameter(typeof(Rental), "x");
            var e = (Expression)DynamicExpressionParser.ParseLambda(new[] { p }, null, filter);
            var typedExpression = (Expression<Func<Rental, bool>>)e;
            return await rentalRep.GetAllAsync(typedExpression);
        }

        [HttpGet("{id}")]
        public Task<Rental?> Get(int id)
        {
            return rentalRep.GetByIdAsync(id);
        }

        // POST api/<APIRentalController>
        [HttpPost]
        public async Task Post(Rental rental)
        {
            await rentalRep.CreateAsync(rental);
            return;
        }

        // PUT api/<APIRentalController>/5
        [HttpPut]
        public async Task Put(Rental rental)
        {
            await rentalRep.UpdateAsync(rental);
        }

        // DELETE api/<APIRentalController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var rental = await rentalRep.GetByIdAsync(id);
            if (rental == null)
            {
                throw new ArgumentNullException(nameof(rental));
            }
            await rentalRep.DeleteAsync(rental);
            return;
        }
    }
}
