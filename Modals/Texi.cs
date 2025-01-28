using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

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

        //public Texi(Texi texi)
        //{
        //    this.TexiId = texi.TexiId;
        //    this.XgoogleMaps = texi.XgoogleMaps;
        //    this.YgoogleMaps = texi.YgoogleMaps;
        //    this.Tstatus = texi.Tstatus;
        //    this.Tdriver = texi.Tdriver;
        //}
        //לבדוק הגדרה של 
        [Key ,NotNull]
        public int TexiId { get; set; }
        [Column, DisallowNull]
        public int XgoogleMaps { get; set; }
        [Column, DisallowNull]
        public int YgoogleMaps { get; set; }
        [ForeignKey("DriverId") ]
        public virtual Driver TDriver { get; set; }
        [Column, DisallowNull]
        public Status Tstatus { get; set; }

    }
}
