using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace OrderTexi.Modals
{
    public class Driver
    {

        [Key ,NotNull ] public int DriverId { get; set; }
        [Column, NotNull]
        public string DriverName { get; set; }
        [Column, NotNull]
        public int Phone { get; set; }
       
    }
}
