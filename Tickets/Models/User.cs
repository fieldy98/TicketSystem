using System.ComponentModel.DataAnnotations;
using System.Linq;
using Tickets.EF;

namespace Tickets.Models
{
    public class User
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
        public string Password { get; set; }
        //public bool IsTeacher(string badge)
        //{
        //    var db = new RenExtractEntities().SchoolTeachersWithADLogins;
        //    var queryDb = db.FirstOrDefault(x => x.BADGE_NUM == badge);
        //    return queryDb != null;
        //}
        public bool IsTech(string username, string password)
        {
            var db = new TicketsEntities().TechLogins;

            var queryDb = db.FirstOrDefault(x => x.Username == username && x.Password == password && x.IsAdmin == false && x.IsActive == true);
            return queryDb != null;
        }
        public bool IsAdmin(string username, string password)
        {
            var db = new TicketsEntities().TechLogins;

            var queryDb = db.FirstOrDefault(x => x.Username == username && x.Password == password && x.IsAdmin == true && x.IsActive == true);
            return queryDb != null;
        }

    }
}