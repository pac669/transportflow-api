using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportFlow.API.Data;
using TransportFlow.API.Models;
using TransportFlow.API.DTOs;

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
        public async Task<ActionResult<IEnumerable<DeliveryDto>>> GetDeliveries()
        {
            var deliveries = await _context.Deliveries
                .Select(d => new DeliveryDto
                {
                    Id = d.Id,
                    CustomerName = d.CustomerName,
                    Address = d.Address,
                    DeliveryDate = d.DeliveryDate,
                    Completed = d.Completed
                })
                .ToListAsync();

            return Ok(deliveries);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryDto>> GetDelivery(int id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);

            if (delivery == null)
            {
                return NotFound();
            }

            var dto = new DeliveryDto
            {
                Id = delivery.Id,
                CustomerName = delivery.CustomerName,
                Address = delivery.Address,
                DeliveryDate = delivery.DeliveryDate,
                Completed = delivery.Completed
            };

            return Ok(dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDelivery(int id, UpdateDeliveryDto dto)
        {
            var delivery = await _context.Deliveries.FindAsync(id);

            if (delivery == null)
            {
                return NotFound();
            }

            delivery.CustomerName = dto.CustomerName;
            delivery.Address = dto.Address;
            delivery.DeliveryDate = dto.DeliveryDate;
            delivery.Completed = dto.Completed;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/deliveries
        [HttpPost]
        public async Task<ActionResult<DeliveryDto>> CreateDelivery(CreateDeliveryDto dto)
        {
            var delivery = new Delivery
            {
                CustomerName = dto.CustomerName,
                Address = dto.Address,
                DeliveryDate = dto.DeliveryDate,
                Completed = false
            };

            _context.Deliveries.Add(delivery);

            await _context.SaveChangesAsync();

            var result = new DeliveryDto
            {
                Id = delivery.Id,
                CustomerName = delivery.CustomerName,
                Address = delivery.Address,
                DeliveryDate = delivery.DeliveryDate,
                Completed = delivery.Completed
            };

            return Ok(result);
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