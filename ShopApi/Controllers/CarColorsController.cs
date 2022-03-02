using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToyCarsShop.Domain.Core;
using ToyCarsShop.Infrastructure.Data;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarColorsController : ControllerBase
    {
        private readonly CarsContext _context;

        public CarColorsController(CarsContext context)
        {
            _context = context;
        }

        // GET: api/CarColors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarColor>>> GetCarColor()
        {
            return await _context.CarColor.ToListAsync();
        }

        // GET: api/CarColors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarColor>> GetCarColor(int id)
        {
            var carColor = await _context.CarColor.FindAsync(id);

            if (carColor == null)
            {
                return NotFound();
            }

            return carColor;
        }

        // PUT: api/CarColors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarColor(int id, CarColor carColor)
        {
            if (id != carColor.ColorId)
            {
                return BadRequest();
            }

            _context.Entry(carColor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarColorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CarColors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarColor>> PostCarColor(CarColor carColor)
        {
            _context.CarColor.Add(carColor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarColor", new { id = carColor.ColorId }, carColor);
        }

        // DELETE: api/CarColors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarColor(int id)
        {
            var carColor = await _context.CarColor.FindAsync(id);
            if (carColor == null)
            {
                return NotFound();
            }

            _context.CarColor.Remove(carColor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarColorExists(int id)
        {
            return _context.CarColor.Any(e => e.ColorId == id);
        }
    }
}
