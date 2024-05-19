using CustomerAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomersAPI.Controllers
{
    public class CustomerController(CustomerDbContext context) : BaseController(context)
    {

        [HttpGet("create/customersCount={customersCount}")]
        public async Task<ActionResult> CreateCostomersAsync(int customersCount)
        {
            try
            {
                if (customersCount < 1 || customersCount > 30)
                {
                    return BadRequest("Die Anzahl der Kunden muss zwischen 1 und 30 liegen.");
                }

                await CreateCustomersDataAsync(customersCount);
                return Ok("Datenbank erfolgreich aktualisiert.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Fehler beim Aktualisieren der Datenbank: {ex.Message}");
            }
        }

        [HttpGet("delete")]
        public async Task<ActionResult> DeleteCustomersDataAsync()
        {
            try
            {
                _context.Customers.RemoveRange(_context.Customers);
                await _context.SaveChangesAsync();
                return Ok("Daten in der Datenbank erfolgreich gelöscht.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Fehler beim Löschen der Daten: {ex.Message}");
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllCustomersAsync()
        {
            _context.Database.SetCommandTimeout(180); // Timeout auf 180 Sekunden setzen

            var customers = await _context.Customers
                                            .Include(c => c.company)
                                            .Include(c => c.Travels).ThenInclude(t => t.Transfers)
                                            .Include(c => c.Travels).ThenInclude(t => t.Passengers)
                                            .Include(c => c.Actions)
                                            .Include(c => c.Cards)
                                            .ToListAsync();
            if (customers == null || customers.Count == 0)
            {
                return Ok("Keine Daten vorhanden");
            }
            return Ok(customers);
        }

        [HttpGet("fullname={fullname}")]
        public async Task<ActionResult> GetCustomerAsync(string fullname)
        {
            var customer = await _context.Customers
                                          .Include(c => c.Travels).ThenInclude(t => t.Transfers)
                                          .Include(c => c.Travels).ThenInclude(t => t.Passengers)
                                          .Include(c => c.Actions)
                                          .Include(c => c.Cards)
                                          .FirstOrDefaultAsync(c => c.Fullname == fullname);
            if (customer == null)
            {
                return Ok("Kunde nicht vorhanden");
            }
            return Ok(customer);
        }
    }
}