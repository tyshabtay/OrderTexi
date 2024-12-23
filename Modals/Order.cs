using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderTexi.Modals
{
    public class Order
    {
        [Key] public int OrderId { get; set; }
        //להוסיף מחלקת points
        public int XcurrentPlace;
        public int YcurrentPlace;
        public int XDestination;
        public int YDestination;
        [ForeignKey ("driver")]  public int OrderDriver;
        public int OrderPhone;

    }
}
