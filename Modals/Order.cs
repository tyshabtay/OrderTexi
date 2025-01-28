using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace OrderTexi.Modals
{
    public class Order
    {
        [Key] public int OrderId { get; set; }
        //להוסיף מחלקת points
        [Column, DisallowNull]
        public int XcurrentPlace { get; set; }
        [Column, DisallowNull]
        public int YcurrentPlace { get; set; }
        [Column, DisallowNull]
        public int XDestination { get; set; }
        [Column, DisallowNull]
        public int YDestination { get; set; }
        [ForeignKey("driver")] public int OrderDriver;
        [Column, DisallowNull]
        public int OrderPhone { get; set; }

    }
}
