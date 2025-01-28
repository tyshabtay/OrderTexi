using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderTexi.Data;
using OrderTexi.Modals;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
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
        public static bool IsValidEmail(string email)
        {
            var emailAddress = new EmailAddressAttribute();
            return emailAddress.IsValid(email);
        }
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8 || password.Length > 10)
                return false;
            if (!Regex.IsMatch(password, @"[a-z]") && !Regex.IsMatch(password, @"[A-Z]")) return false; // לפחות תו אלפביתי קטן או גדול
            if (!Regex.IsMatch(password, @"[0-9]")) return false; // לפחות תו מספרי
            return true;
        }
        //public void ForgetPassword(string userName)
        //{
        //  //  פונקצית sendmail שמחזירה הודעה נשלח לך סיסמא למייל ומשם תמשים את התהליך
        //}
        //public void SendMail()
        //{

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
        [HttpPost]
        public string AddNewUser(string userName, string password, string name)
        {
            var entities = _context.Users.ToList();
            //וולידציה לבדוק בהמשך איך מוודאים שהמייל תקין וכן איך בודקים שהסיסמא מכילה אות גדולה +אות קטנה + מספרים
            if (UserController.IsValidPassword(password) && UserController.IsValidEmail(userName))
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
