using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrderTexi.Modals
{
    public class Driver
    {
        
       [Key] public int driver { get; set; }
        public string DriverName;
        public int Phone;
    }
}
