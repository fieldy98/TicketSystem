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

namespace Tickets.Controllers
{
    public class SearchController : Controller
    {
        TicketsEntities db = new TicketsEntities();
        // GET: Search
        public ActionResult Index()
        {
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();
            var Schools = db.StaffToSites.Select(x => x.Site).Distinct().OrderBy(x => x).ToList();

            foreach (var item in Schools)
            {
                School s = new School();
                s.Site = item;
                tcvm.school.Add(s);
            }
            foreach (var item in db.Equipments.OrderBy(x => x.Equipment1))
            {
                CreateEquipment e = new CreateEquipment();
                e.Equipment = item.Equipment1;
                tcvm.createequipment.Add(e);
            }

            tcvm.school = tcvm.school.ToList();

            return View(tcvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Site,UserID,Location,Equipment,Issue,Nutrition")] TicketsCreateViewModel ticket)
        {
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();

            if (ModelState.IsValid)
            {
                
                              
                return RedirectToAction("SearchResults", new { site = ticket.Site, user = ticket.User, location = ticket.Location, equipment = ticket.Equipment, issue = ticket.Issue, nutrition = ticket.Nutrition});
            }



            return View(ticket);
        }
        public ActionResult SearchResults(string site, string user, string location, string equipment, string issue, bool? nutrition)
        {
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();

            var searchResults = db.Tickets.ToList();
            if(site != null)
            {
                searchResults = searchResults.Where(x => x.Site == site).ToList();
            }
            if (user != null)
            {
                searchResults = searchResults.Where(x => x.TroubleUser == user).ToList();
            }
            if (location != null)
            {
                searchResults = searchResults.Where(x => x.Location == location).ToList();
            }
            if (equipment != null)
            {
                searchResults = searchResults.Where(x => x.Equipment == equipment).ToList();
            }
            if (issue != null)
            {
                searchResults = searchResults.Where(x => x.Issue != null && x.Issue.Contains(issue)).ToList();
            }
            if (nutrition == true)
            {
                searchResults = searchResults.Where(x => x.Nutrition == true).ToList();
            }
            foreach(var item in searchResults)
            {
                Create c = new Create();

                c.TicketNumber = item.TicketNumber;
                c.Issue = item.Issue;
                c.Equipment = item.Equipment;
                if(item.CreateTime != null)
                {
                    c.Time = item.CreateTime.Value.ToShortDateString();
                }
                
                c.Location = item.Location;
                c.Site = item.Site;
                c.TroubleUser = item.TroubleUser;
                

                tcvm.create.Add(c);
            }

            tcvm.Site = issue;

            tcvm.create = tcvm.create.ToList();
            return View(tcvm);
        }
        public ActionResult SimpleSearch(string SearchString)
        {
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();

            var tickets = db.Tickets.Where(x => x.Site.Contains(SearchString) || x.Location.Contains(SearchString) || x.TroubleUser.Contains(SearchString) || x.Issue.Contains(SearchString) || x.Equipment.Contains(SearchString));

            foreach (var item in tickets)
            {
                Create c = new Create();

                c.TicketNumber = item.TicketNumber;
                c.Issue = item.Issue;
                c.Equipment = item.Equipment;
                if (item.CreateTime != null)
                {
                    c.Time = item.CreateTime.Value.ToShortDateString();
                }

                c.Location = item.Location;
                c.Site = item.Site;
                c.TroubleUser = item.TroubleUser;


                tcvm.create.Add(c);
            }

            tcvm.create = tcvm.create.ToList();

            return View(tcvm);
        }
        public ActionResult _getRoom(string selectedSchool)
        {
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();
            var Library = db.TeacherToRooms.Where(x => x.Room.Contains("Lib"));
            var site = db.StaffToSites.FirstOrDefault(x => x.Site == selectedSchool).Site;

            for (var i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    Room r = new Room();
                    r.Location = "Office";
                    tcvm.room.Add(r);
                }
                else if (i == 1)
                {
                    Room r = new Room();
                    r.Location = "MPR";
                    tcvm.room.Add(r);
                }
                else if (i == 2)
                {
                    Room r = new Room();
                    r.Location = "Library";
                    tcvm.room.Add(r);
                }

                else
                {
                    Room r = new Room();
                    r.Location = "Stage";
                    tcvm.room.Add(r);
                }

            }
            if (site == "BV")
            {
                site = "Buena Vista";
            }
            if(site == "Doug Miller")
            {
                site = "Miller";
            }
            if(site == "Sing Lum")
            {
                site = "Lum";
            }

            var rooms = db.TeacherToRooms.Where(x => x.Site.Contains(site)).Except(Library).Select(x => x.Room).OrderBy(x => x).GroupBy(x => x).ToList();

            foreach (var item in rooms)
            {
                Room r = new Room();
                r.Location = item.Key;

                tcvm.room.Add(r);

            }
            tcvm.room = tcvm.room.ToList();
            return PartialView(tcvm);
        }
    }
}