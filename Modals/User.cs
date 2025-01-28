using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace OrderTexi.Modals
{
    public class User
    {
        // public string Jwt { get; set; }
        [Key]
        public string UserName { get; set; }
        [Column, DisallowNull]
        public string Password { get; set; }
        [Column, DisallowNull]
        public string Name { get; set; }



    }
}
