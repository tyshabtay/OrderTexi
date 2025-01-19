using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace OrderTexi.Modals
{
    public class User
    {
        [Key]
        public string Jwt { get; set; }
        [  Column, NotNull]
        public string UserName { get; set; }
        [Column, NotNull]
        public string Password { get; set; }
        [Column, NotNull]
        public string Name { get; set; }


   
    }
}
