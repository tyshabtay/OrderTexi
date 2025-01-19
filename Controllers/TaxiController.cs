using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderTexi.Data;
using OrderTexi.Modals;
using System.Net.NetworkInformation;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

//For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        //[HttpGet]
        //public IEnumerable<Texi> GetAllTexies()
        //{
        //    var entities = _context.Texis.ToList();
        //    return (IEnumerable<Texi>)entities;
        //}

        //[HttpGet("{id}")]
        //public Texi GetTexiById(int id)
        //{
        //    var entities = _context.Texis.ToList();
        //    Texi currentTaxi = new Texi();
        //    try {
        //        currentTaxi = entities.FirstOrDefault(t => t.TexiId == id);
        //        return currentTaxi;
        //    }
        //    catch { return new Texi(); }

        //}
        [HttpGet("{driverId}")]
        public async Task<IActionResult> GetTexiByDriverId(int driverId)
        {
            var query = from texi in _context.Texis
                        join driver in _context.Drivers
                      on texi.TDriverId.DriverId equals driver.DriverId
                        select new
                        {
                            TexiId = texi.TexiId,
                            XgoogleMaps = texi.XgoogleMaps,
                            YgoogleMaps = texi.YgoogleMaps,
                            Tdriver = texi.TDriverId,
                            Tstatus = texi.Tstatus
                        };
            var result = await query.FirstOrDefaultAsync();
            return Ok(result);
        }
        ////פונקציה לא מושלמת של שליפה לפי איזור
        //[HttpGet("{x,y}")]
        //public IEnumerable<Texi> GetTexisByArea(string area)
        //{
        //    List<Texi> texis = new List<Texi>();
        //    var entities = _context.Texis.ToList();
        //    string texiArea = "";
        //    foreach (var item in entities)
        //    {
        //        texiArea = item.YgoogleMaps.ToString();
        //        if (texiArea == area)
        //            texis.Add(item);
        //    }
        //    return texis;
        //}
        //[HttpGet("{status}")]
        //public IEnumerable<Texi> GetTexiesByStatus(Status status)
        //{
        //    var entities = _context.Texis.ToList();
        //    var texies = entities.Where(i => i.Tstatus == status);
        //    return texies;

        //}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTexiById(int id, [FromBody] Texi value)
        {
            var entities = _context.Texis.ToList();
            var texi = entities.FirstOrDefault(i => i.TexiId == value.TexiId);
            if(texi==null)
            {
                return NotFound();
            }
            var properties = typeof(Texi).GetProperties();
            foreach (var property in properties)
            {
                var newValue = property.GetValue(value);
                property.SetValue(texi, newValue);
            }
       

            
           await     _context.SaveChangesAsync();
            return Ok(texi);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTexiById(int id)
        {
            var entities = _context.Texis.ToList();
            var item = entities.FirstOrDefault(i => i.TexiId == id);
            if(item==null)
            {
                return NotFound();
            }    
            _context.Remove(item);
           await _context.SaveChangesAsync();
            return NoContent();
        }
 

    } }
