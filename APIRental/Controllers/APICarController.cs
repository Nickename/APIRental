using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using DataAccess.Data;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;

namespace APIRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class APICarController : ControllerBase
    {
        private readonly IRepository<Car> carRep;

        public APICarController(IRepository<Car> carRep)
        {
            this.carRep = carRep;
        }

        // GET: api/<APICarController>
        [HttpGet]
        public Task<List<Car>> Get()
        {
            return carRep.GetAllAsync();
        }

        //GET api/<APICarController>/5
        [HttpGet("filter/{filter}")]
        public async Task<ActionResult<IEnumerable<Car>>> Get(string? filter = null)
        {
            if (await carRep.GetAllAsync() == null)
            {
                return NotFound();
            }
            if (filter == null)
            {
                return await carRep.GetAllAsync();
            }

            var p = Expression.Parameter(typeof(Car), "x");
            var e = (Expression)DynamicExpressionParser.ParseLambda(new[] { p }, null, filter);
            var typedExpression = (Expression<Func<Car, bool>>)e;
            return await carRep.GetAllAsync(typedExpression);
        }

        [HttpGet("{id}")]
        public Task<Car?> Get(int id)
        {
            return carRep.GetByIdAsync(id);
        }

        // POST api/<APICarController>
        [HttpPost]
        public async Task Post(Car car)
        {
            await carRep.CreateAsync(car);
            return;
        }

        // PUT api/<APICarController>/5
        [HttpPut]
        public async Task Put(Car car)
        {
            await carRep.UpdateAsync(car);
            return;
        }

        // DELETE api/<APICarController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var car = await carRep.GetByIdAsync(id);
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }
            await carRep.DeleteAsync(car);
            return;
        }
    }
}
