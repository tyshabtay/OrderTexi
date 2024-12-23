using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderTexi.Modals
{
    public enum Status
    {
        empty,
        full,
        goingToBeEmpty
    }
    public class Texi
    {
        [Key] 
        //לבדוק הגדרה של 
        public int TexiId { get; set; }
        public int XgoogleMaps;
        public int YgoogleMaps;
        [ForeignKey ("driver")] int Tdriver { get; set; }
        public Status Tstatus;

    }
}
