using System.ComponentModel.DataAnnotations;

namespace OrderTexi.Modals
{
    public class User
    {
      [Key]  public int Uid { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }
        private string Jwt { get; set; }
    }
}
