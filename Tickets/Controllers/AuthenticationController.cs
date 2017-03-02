using System.Web.Mvc;
using System.Web.Security;
using Tickets.Models;
using Tickets.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using Tickets.EF;


//
// OVERVIEW:
//      This controller handles the login/logout of users throughout the application.
//      It checks with the 'User' model for verification of the staff members entered badge.
//

namespace Tickets.Controllers
{
    public class AuthenticationController : Controller
    {
        private TicketsEntities db = new TicketsEntities();
        // GET: Return Teacher/Sub select screen
        public ActionResult Index()
        {
            return View();
        }
        // GET: Return Login Page
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        // POST: Authenticatate user
        // If the user is valid, create a cookie and return the teacher landing page.
        [HttpPost]
        public ActionResult Login(Models.User user, SimplerAESModel EncryptedPassword)
        {
            var password = EncryptedPassword.Encrypt(user.Password);
            // Checks with the 'User' model and runs the users input through the IsValid method.
            if (!ModelState.IsValid) return View(user);
            if (user.IsAdmin(user.Username, password))
            {
                // If a match is found, create a cookie and return the Principal homepage
                FormsAuthentication.SetAuthCookie(user.Username, true);
                return RedirectToAction("Index", "Admin");
            }
            else if (user.IsTech(user.Username, password))
            {
                // If a match is found, create a cookie and return the Principal homepage
                FormsAuthentication.SetAuthCookie(user.Username, true);
                return RedirectToAction("Index", "Tickets");
            }
            //else if (user.IsTeacher(user.StaffBadgeNumber))
            //{
            //    // If a match is found, create a cookie and return the teacher homepage
            //    FormsAuthentication.SetAuthCookie(user.StaffBadgeNumber, true);
            //    return RedirectToAction("Index", "Teacher");
            //}
            else
            {
                // If no match found, report error.
                ModelState.AddModelError("", "Incorrect Username and/or Password.");
            }
            return View(user);
        }
        public ActionResult Logout()
        {
            // Expire Cookie and redirect to Teacher/Sub page
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Tickets");
        }
        public ActionResult Register()
        {
            RegisterUser rvm = new RegisterUser();

            return View(rvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "LastName,FirstName,Username,Password,IsAdmin")] RegisterUser r,SimplerAESModel DecryptedPassword)
        {
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();
            if (ModelState.IsValid)
            {
                TechLogin tl = new TechLogin();

                tl.Username = r.Username;
                tl.Password = DecryptedPassword.Encrypt(r.Password);
                tl.FirstName = r.FirstName;
                tl.LastName = r.LastName;
                tl.IsActive = true;
                tl.IsAdmin = r.IsAdmin;
                
                db.TechLogins.Add(tl);
                db.SaveChanges();
                return RedirectToAction("Index", "Tickets");
            }

            return View(r);
        }
        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword(int ID)
        {
            ChangePassword tcvm = new ChangePassword();
            
            tcvm.ID = ID;
            return View(tcvm);
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword([Bind(Include = "OldPassword,NewPassword,ConfirmPassword,ID")] ChangePassword r, SimplerAESModel DecryptedPassword)
        {
            var old = DecryptedPassword.Encrypt(r.OldPassword);
            TechLogin user = db.TechLogins.FirstOrDefault(x => x.ID == r.ID);
            
            
            if (user != null && user.Password == old)
            {
                if(r.NewPassword == r.ConfirmPassword)
                {
                    user.Password = DecryptedPassword.Encrypt(r.NewPassword);
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Tickets");
                }
                else
                {
                    ViewBag.Failed = "Failed To Change Password";
                    return Redirect(Request.UrlReferrer.PathAndQuery);
                }
            }
            else
            {
                ViewBag.Failed = "Failed To Change Password";
                return Redirect(Request.UrlReferrer.PathAndQuery);
            }
            

        }
    }
}