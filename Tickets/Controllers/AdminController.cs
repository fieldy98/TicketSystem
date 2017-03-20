using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tickets.Models;
using Tickets.ViewModels;
using Tickets.EF;
using System.Globalization;

namespace Tickets.Controllers
{
    public class AdminController : Controller
    {
        TicketsEntities db = new TicketsEntities();
        // GET: Admin
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult TechAssignments()
        {
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();

            var schools = db.SitesToDays.OrderBy(x => x.School).ToList();

            foreach (var item in schools)
            {
                SchoolAssigments s = new SchoolAssigments();

                s.School = item.School;
                var techname = db.TechLogins.First(x => x.ID == item.TechID);
                s.TechName = techname.LastName + ", " + techname.FirstName;
                s.Days = item.Day1 + ", " + item.Day2;
                if (item.Day3 != null && item.Day3 != null && item.Day3 != null)
                {
                    s.Days = s.Days + ", " + item.Day3 + ", " + item.Day4 + ", " + item.Day5;
                }

                tcvm.schoolassignments.Add(s);
            }
            foreach(var item in db.SchoolNames)
            {
                if(db.Schedules.Any(x=>x.School == item.Site))
                {
                    
                }
                else
                {
                    SchoolAssigments s = new SchoolAssigments();

                    s.School = item.Site;


                    tcvm.schoolassignments.Add(s);
                }
            }


            tcvm.schoolassignments = tcvm.schoolassignments.ToList();
            return View(tcvm);
        }
        public ActionResult SchoolAssignment(string selectedSchool)
        {
            Assignments tcvm = new Assignments();

            if (db.Schedules.Any(x => x.School == selectedSchool))
            {
                var staff = db.Schedules.SingleOrDefault(x => x.School == selectedSchool);
                tcvm.TechID = staff.TechID;
                tcvm.School = staff.School;
                tcvm.Monday = staff.Monday;
                tcvm.Tuesday = staff.Tuesday;
                tcvm.Wednesday = staff.Wednesday;
                tcvm.Thursday = staff.Thursday;
                tcvm.Friday = staff.Friday;
            }

            foreach (var item in db.TechLogins.OrderBy(x=>x.LastName))
            {
                SchoolTech st = new SchoolTech();

                st.TechID = item.ID;
                st.TechName = item.LastName + ", " + item.FirstName;

                tcvm.schooltech.Add(st);
            }
            tcvm.School = selectedSchool;

            tcvm.schooltech = tcvm.schooltech.ToList();
            return View(tcvm);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SchoolAssignment([Bind(Include = "School,TechID,Monday,Tuesday,Wednesday,Thursday,Friday")] Assignments a)
        {
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();

            if (ModelState.IsValid)
            {
                var tickets = db.Tickets.Where(x=>x.Site == a.School && x.CloseTime == null).ToList();
                foreach(var item in tickets)
                {
                    Ticket t = db.Tickets.FirstOrDefault(x => x.TicketNumber == item.TicketNumber);
                    t.TechID = a.TechID;

                    db.Entry(t).State = EntityState.Modified;
                   
                }
                if (db.Schedules.Any(x => x.School == a.School))
                {
                    Schedule s = db.Schedules.FirstOrDefault(x => x.School == a.School);
                    s.TechID = a.TechID;
                    s.Monday = a.Monday;
                    s.Tuesday = a.Tuesday;
                    s.Wednesday = a.Wednesday;
                    s.Thursday = a.Thursday;
                    s.Friday = a.Friday;
                    db.Entry(s).State = EntityState.Modified;
                }
                else
                {
                    Schedule s = new Schedule();

                    s.School = a.School;
                    s.TechID = a.TechID;
                    s.Monday = a.Monday;
                    s.Tuesday = a.Tuesday;
                    s.Wednesday = a.Wednesday;
                    s.Thursday = a.Thursday;
                    s.Friday = a.Friday;

                    db.Schedules.Add(s);
                }
                db.SaveChanges();

                return RedirectToAction("TechAssignments");
            }

            return View(tcvm);
        }
        public ActionResult SchoolStaff()
        {
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();

            var today = DateTime.Now.ToString("dddd");
            ViewBag.Today = today;
            var schools = db.Schedules.OrderBy(x => x.School).ToList();

            foreach (var item in schools)
            {
                SchoolAssigments s = new SchoolAssigments();
                if(db.MailLists.Any(x=>x.School == item.School))
                {
                    var mail = db.MailLists.SingleOrDefault(x => x.School == item.School);
                    s.Poc1 = mail.Principal;
                    s.Poc2 = mail.Clerk;
                    s.Poc3 = mail.Librarian;
                }
                
                s.School = item.School;

                tcvm.schoolassignments.Add(s);
            }

            tcvm.schoolassignments = tcvm.schoolassignments.ToList();
            return View(tcvm);
        }
        public ActionResult StaffToEmail(string selectedSchool)
        {
            StaffToEmail tcvm = new StaffToEmail();
            tcvm.School = selectedSchool;
            if(db.MailLists.Any(x=>x.School == selectedSchool))
            {
                var staff = db.MailLists.SingleOrDefault(x => x.School == selectedSchool);
                tcvm.Principal = staff.Principal;
                tcvm.Clerk = staff.Clerk;
                tcvm.Librarian = staff.Librarian;
            }
            

            return View(tcvm);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StaffToEmail([Bind(Include = "School,Principal,Clerk,Librarian")] StaffToEmail ste)
        {
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();

            if (ModelState.IsValid)
            {

                if (db.MailLists.Any(x => x.School == ste.School))
                {
                    MailList ml = db.MailLists.FirstOrDefault(x => x.School == ste.School);
                    ml.Principal= ste.Principal;
                    ml.Clerk = ste.Clerk;
                    ml.Librarian = ste.Librarian;
                    db.Entry(ml).State = EntityState.Modified;
                }
                else
                {
                    MailList s = new MailList();

                    s.School = ste.School;
                    s.Principal = ste.Principal;
                    s.Clerk = ste.Clerk;
                    s.Librarian = ste.Librarian;

                    db.MailLists.Add(s);
                }
                db.SaveChanges();

                return RedirectToAction("SchoolStaff");
            }

            return View(tcvm);
        }
        public ActionResult ShowTechs()
        {
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();

            var techs = db.TechLogins.Where(x=>x.IsActive == true).OrderBy(x => x.LastName).ToList();

            foreach (var item in techs)
            {
                Techs s = new Techs();
                s.Tech = item.LastName + ", " + item.FirstName;
                s.TechID = item.ID;
                s.IsAdmin = item.IsAdmin.ToString();

                tcvm.techs.Add(s);
            }

            
            tcvm.schoolassignments = tcvm.schoolassignments.ToList();
            return View(tcvm);
        }
        public ActionResult ShowInactiveTechs()
        {
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();

            var deadtechs = db.TechLogins.Where(x => x.IsActive == false).OrderBy(x => x.LastName).ToList();

            foreach (var item in deadtechs)
            {
                InactiveTechs s = new InactiveTechs();
                s.Tech = item.LastName + ", " + item.FirstName;
                s.TechID = item.ID;
                s.IsAdmin = item.IsAdmin.ToString();

                tcvm.inactivetechs.Add(s);
            }


            tcvm.schoolassignments = tcvm.schoolassignments.ToList();
            return View(tcvm);
        }
        public ActionResult Techs(int? selectedTech)
        {
            EditUser tcvm = new EditUser();
            if (db.TechLogins.Any(x => x.ID == selectedTech))
            {
                var tech = db.TechLogins.SingleOrDefault(x => x.ID == selectedTech);
                tcvm.Username = tech.Username;
                tcvm.FirstName = tech.FirstName;
                tcvm.LastName = tech.LastName;
                tcvm.IsAdmin = tech.IsAdmin;
                if(tech.IsActive == false)
                {
                    tcvm.IsActive = true;
                }
                tcvm.ID = tech.ID;
            }


            return View(tcvm);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Techs([Bind(Include = "ID,Username,FirstName,LastName,IsAdmin,IsActive")] EditUser ste)
        {

            if (ModelState.IsValid)
            {
                    TechLogin ml = db.TechLogins.FirstOrDefault(x => x.Username == ste.Username);
                    ml.Username = ste.Username;
                    ml.FirstName = ste.FirstName;
                    ml.LastName = ste.LastName;
                    ml.IsAdmin = ste.IsAdmin;
                if(ste.IsActive == true)
                {
                    ml.IsActive = false;
                }
                else
                {
                    ml.IsActive = true;
                }
                    db.Entry(ml).State = EntityState.Modified;

                
                db.SaveChanges();

                return RedirectToAction("ShowTechs");
            }

            return View(ste);
        }
        

        public ActionResult AutoAssign()
        {
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();

                var tickets = db.Schedules.ToList();
                foreach (var item in tickets)
                {
                    if (item.School == "Nutrition")
                    {
                        var t = db.Tickets.Where(x => x.Nutrition == true && x.CloseTime == null).ToList();
                        foreach (var s in t)
                        {
                            Ticket ticket = db.Tickets.SingleOrDefault(x => x.TicketNumber == s.TicketNumber);
                            ticket.TechID = item.TechID;
                            db.Entry(ticket).State = EntityState.Modified;
                        }
                    }
                    else
                    {
                        var t = db.Tickets.Where(x => x.Site == item.School && x.CloseTime == null).ToList();
                        foreach (var s in t)
                        {
                            if (s.Issue.Contains("Nutrition") || s.Issue.Contains("nutrition"))
                        {
                            Ticket ticket = db.Tickets.SingleOrDefault(x => x.TicketNumber == s.TicketNumber);
                            var tech = db.Schedules.SingleOrDefault(x => x.School == "Nutrition").TechID;
                            ticket.TechID = tech;
                            db.Entry(ticket).State = EntityState.Modified;
                        }
                        else
                        {
                            Ticket ticket = db.Tickets.SingleOrDefault(x => x.TicketNumber == s.TicketNumber);
                            ticket.TechID = item.TechID;
                            db.Entry(ticket).State = EntityState.Modified;
                        }
                            
                        }
                    }
                    
                }
                db.SaveChanges();

            return Json(new { success = true });
        }
    }
}