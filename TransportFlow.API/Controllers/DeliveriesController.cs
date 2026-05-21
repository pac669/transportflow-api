using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportFlow.API.Data;
using TransportFlow.API.Models;

namespace TransportFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DeliveriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/deliveries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Delivery>>> GetDeliveries()
        {
            return await _context.Deliveries.ToListAsync();
        }

        // POST: api/deliveries
        [HttpPost]
        public async Task<ActionResult<Delivery>> CreateDelivery(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);

            await _context.SaveChangesAsync();

            return Ok(delivery);
        }
        
        // GET: api/deliveries/1

        [HttpGet("{id}")]
        public async Task<ActionResult<Delivery>> GetDelivery(int id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);

            if (delivery == null)
            {
                return NotFound();
            }

            return delivery;
        }
        // PUT: api/deliveries/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDelivery(int id, Delivery delivery)
        {
            if (id != delivery.Id)
            {
                return BadRequest();
            }

            _context.Entry(delivery).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }
        // DELETE: api/deliveries/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery(int id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);

            if (delivery == null)
            {
                return NotFound();
            }

            _context.Deliveries.Remove(delivery);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}