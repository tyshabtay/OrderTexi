using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderTexi.Data;
using OrderTexi.Modals;

namespace OrderTexi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiverController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DiverController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Driver> GetDrivers()
        {
            var entities = _context.Drivers.ToList();
            return (IEnumerable<Driver>)entities;
        }
        [HttpGet("id")]
        public Driver GetDriverByID(int id)
        {
            var entities = _context.Drivers.ToList();
            var currentDriver = entities.FirstOrDefault(i => i.DriverId == id);
            if (currentDriver == null)
            { return null; }             
            return currentDriver;
        }
        [HttpPost]
        public async void AddNewDriver([FromBody]Driver newDriver)
        {
            var entities = _context.Drivers.ToList();
            entities.Add(newDriver);
          await  _context.SaveChangesAsync();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDriverById(int id, [FromBody] Driver value)
        {
            var entities = _context.Drivers.ToList();
            var driver = entities.FirstOrDefault(i => i.DriverId == value.DriverId);
            if (driver == null)
            {
                return NotFound();
            }
            var properties = typeof(Driver).GetProperties();
            foreach (var property in properties)
            {
                var newValue = property.GetValue(value);
                property.SetValue(driver, newValue);
            }

            await _context.SaveChangesAsync();
            return Ok(driver);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriverById(int id)
        {
            var entities = _context.Drivers.ToList();
            var item = entities.FirstOrDefault(i => i.DriverId == id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Remove(item);//.FirstOrDifault().Delete();
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
