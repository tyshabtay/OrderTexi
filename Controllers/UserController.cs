using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderTexi.Data;
using OrderTexi.Modals;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using OrderTexi.Services;
namespace OrderTexi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }
       
        //public void ForgetPassword(string userName)
        //{
        //    Console.WriteLine("נשלח לך קישור לאיפוס סיסמא למייל");
        //    //  //  פונקצית sendmail שמחזירה הודעה נשלח לך סיסמא למייל ומשם תמשים את התהליך
        //}
       
        [HttpPut("{password}")]
        public async Task<IActionResult> UpdatePasswordByUserName(string userName, string password, string newPassword)
        {

            var entities = _context.Users.ToList();
            var currentUser = entities.FirstOrDefault(i => i.UserName == userName && i.Password == password);
            if (currentUser == null)
            {
                return NotFound();
            }
            else
            {
                currentUser.Password = newPassword;
            }

            await _context.SaveChangesAsync();
            return Ok(currentUser);
        }
        [HttpPost("/AddNewUser")]
        public string AddNewUser(string userName, string password, string name)
        {
            var entities = _context.Users.ToList();
            //וולידציה לבדוק בהמשך איך מוודאים שהמייל תקין וכן איך בודקים שהסיסמא מכילה אות גדולה +אות קטנה + מספרים
            if (EmailService.IsValidPassword(password) && EmailService.IsValidEmail(userName))
            {
                if (entities.FindAll(i => i.UserName == userName && i.Password == password).Count > 0)
                    return "משתמש קיים כבר במערכת";
                else
                {
                    Modals.User user = new Modals.User();
                    user.UserName = userName;
                    user.Password = password;
                    user.Name = name;
                    entities.Add(user);
                    _context.SaveChanges();
                    return "מזל טוב נוספת בהצלחה!";

                }
            }
            return "שם משתמש וסיסמא לא תקינים";
        }
    }
}
