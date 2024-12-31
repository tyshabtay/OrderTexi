using Microsoft.AspNetCore.Mvc;
using OrderTexi.Data;
using OrderTexi.Modals;
using System.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderTexi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaxiController(AppDbContext context)
        {
            _context = context;
        }
       
        // GET: api/<TaxiController>
        [HttpGet]
        //מחזיר את כל המוניות
        public IEnumerable<Texi> Get()
        {
            var entities = _context.Texis.ToList();
            return (IEnumerable<Texi>)Ok(entities);
           // return new string[] { "value1", "value2" };
        }

        // GET api/<TaxiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TaxiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TaxiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TaxiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        //הוספת מונית
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Texi myEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Texis.Add(myEntity); // הוספת הישות
                await _context.SaveChangesAsync(); // שמירת השינויים
                return RedirectToAction(nameof(Index)); // הפנייה לעמוד אחר לאחר השמירה
            }
            return Ok(myEntity);
        }
    }
}
