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
using System.Net.Mail;
using System.IO;

namespace Tickets.Controllers
{
    public class TicketsController : Controller
    {
        private TicketsEntities db = new TicketsEntities();

        // GET: Tickets
        public ActionResult Index(string ShowAll)
        {
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();
            IdentifySiteModel ism = new IdentifySiteModel();
            var test = db.ScheduledSchoolsTickets.ToList();

            var clientIP = Request.UserHostAddress;
            var site = ism.IdentifySite(clientIP);
                
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                var name = ticket.Name;
                var tech = db.TechLogins.SingleOrDefault(x => x.Username == name);
                tcvm.IsAdmin = tech.IsAdmin;
                tcvm.TechID = tech.ID;


                    if (DateTime.Now.ToString("dddd") == "Monday")
                    {
                    if (db.Schedules.SingleOrDefault(x => x.School == "Nutrition").TechID == tech.ID)
                    {
                        var Nutrition = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition")).ToList();
                        foreach (var item in Nutrition)
                        {
                            IndexView iv = new IndexView();

                            iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                            iv.Equipment = item.Equipment;
                            iv.Issue = item.Issue;
                            iv.Location = item.Location;
                            if (item.Nutrition == true)
                            {
                                iv.Nutrition = true;
                            }
                            else
                            {
                                iv.Nutrition = false;
                            }
                            iv.Site = item.Site;
                            iv.TicketNumber = item.TicketNumber;
                            iv.User = item.TroubleUser;


                            tcvm.indexview.Add(iv);
                        }
                    }
                    test = test.Where(x => x.TechID == tech.ID && x.Monday == true).ToList();
                    
                        
                        foreach (var item in test)
                        {
                            IndexView iv = new IndexView();

                            iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                            iv.Equipment = item.Equipment;
                            iv.Issue = item.Issue;
                            iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                            iv.TicketNumber = item.TicketNumber;
                            iv.User = item.TroubleUser;


                            tcvm.indexview.Add(iv);
                        }
                    if (db.Schedules.Any(x => x.TechID == tech.ID))
                    {
                        MySchools ms = new MySchools();
                        ms.School = "Today";
                        ms.TicketCount = test.Count();
                        tcvm.myschools.Add(ms);
                        tcvm.myschools = tcvm.myschools.ToList();
                    }
                    }
                    else if (DateTime.Now.ToString("dddd") == "Tuesday")
                    {
                    if (db.Schedules.SingleOrDefault(x => x.School == "Nutrition").TechID == tech.ID)
                    {
                        var Nutrition = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition")).ToList();
                        foreach (var item in Nutrition)
                        {
                            IndexView iv = new IndexView();

                            iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                            iv.Equipment = item.Equipment;
                            iv.Issue = item.Issue;
                            iv.Location = item.Location;
                            if (item.Nutrition == true)
                            {
                                iv.Nutrition = true;
                            }
                            else
                            {
                                iv.Nutrition = false;
                            }
                            iv.Site = item.Site;
                            iv.TicketNumber = item.TicketNumber;
                            iv.User = item.TroubleUser;


                            tcvm.indexview.Add(iv);
                        }
                    }
                    test = test.Where(x => x.TechID == tech.ID && x.Tuesday == true).ToList();
                    
                    
                        foreach (var item in test)
                        {
                            IndexView iv = new IndexView();

                            iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                            iv.Equipment = item.Equipment;
                            iv.Issue = item.Issue;
                            iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                            iv.TicketNumber = item.TicketNumber;
                            iv.User = item.TroubleUser;


                            tcvm.indexview.Add(iv);
                        }
                    if (db.Schedules.Any(x => x.TechID == tech.ID))
                    {
                        MySchools ms = new MySchools();
                        ms.School = "Today";
                        ms.TicketCount = test.Count();
                        tcvm.myschools.Add(ms);
                        tcvm.myschools = tcvm.myschools.ToList();
                    }
                }
                    else if (DateTime.Now.ToString("dddd") == "Wednesday")
                    {
                    if (db.Schedules.SingleOrDefault(x => x.School == "Nutrition").TechID == tech.ID)
                    {
                        var Nutrition = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition")).ToList();
                        foreach (var item in Nutrition)
                        {
                            IndexView iv = new IndexView();

                            iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                            iv.Equipment = item.Equipment;
                            iv.Issue = item.Issue;
                            iv.Location = item.Location;
                            if (item.Nutrition == true)
                            {
                                iv.Nutrition = true;
                            }
                            else
                            {
                                iv.Nutrition = false;
                            }
                            iv.Site = item.Site;
                            iv.TicketNumber = item.TicketNumber;
                            iv.User = item.TroubleUser;


                            tcvm.indexview.Add(iv);
                        }
                    }
                    test = test.Where(x => x.TechID == tech.ID && x.Wednesday == true).ToList();
                    
                        foreach (var item in test)
                        {
                            IndexView iv = new IndexView();

                            iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                            iv.Equipment = item.Equipment;
                            iv.Issue = item.Issue;
                            iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                            iv.TicketNumber = item.TicketNumber;
                            iv.User = item.TroubleUser;


                            tcvm.indexview.Add(iv);
                        }
                    if (db.Schedules.Any(x => x.TechID == tech.ID))
                    {
                        MySchools ms = new MySchools();
                        ms.School = "Today";
                        ms.TicketCount = test.Count();
                        tcvm.myschools.Add(ms);
                        tcvm.myschools = tcvm.myschools.ToList();
                    }
                }
                    else if (DateTime.Now.ToString("dddd") == "Thursday")
                    {
                    if (db.Schedules.SingleOrDefault(x => x.School == "Nutrition").TechID == tech.ID)
                    {
                        var Nutrition = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition")).ToList();
                        foreach (var item in Nutrition)
                        {
                            IndexView iv = new IndexView();

                            iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                            iv.Equipment = item.Equipment;
                            iv.Issue = item.Issue;
                            iv.Location = item.Location;
                            if (item.Nutrition == true)
                            {
                                iv.Nutrition = true;
                            }
                            else
                            {
                                iv.Nutrition = false;
                            }
                            iv.Site = item.Site;
                            iv.TicketNumber = item.TicketNumber;
                            iv.User = item.TroubleUser;


                            tcvm.indexview.Add(iv);
                        }
                    }
                    test = test.Where(x => x.TechID == tech.ID && x.Thursday == true).ToList();
                    
                        foreach (var item in test)
                        {
                            IndexView iv = new IndexView();

                            iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                            iv.Equipment = item.Equipment;
                            iv.Issue = item.Issue;
                            iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                            iv.TicketNumber = item.TicketNumber;
                            iv.User = item.TroubleUser;


                            tcvm.indexview.Add(iv);
                        }
                    if (db.Schedules.Any(x => x.TechID == tech.ID))
                    {
                        MySchools ms = new MySchools();
                        ms.School = "Today";
                        ms.TicketCount = test.Count();
                        tcvm.myschools.Add(ms);
                        tcvm.myschools = tcvm.myschools.ToList();
                    }
                }
                    else if (DateTime.Now.ToString("dddd") == "Friday")
                    {
                    if (db.Schedules.SingleOrDefault(x => x.School == "Nutrition").TechID == tech.ID)
                    {
                        var Nutrition = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition")).ToList();
                        foreach (var item in Nutrition)
                        {
                            IndexView iv = new IndexView();

                            iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                            iv.Equipment = item.Equipment;
                            iv.Issue = item.Issue;
                            iv.Location = item.Location;
                            if (item.Nutrition == true)
                            {
                                iv.Nutrition = true;
                            }
                            else
                            {
                                iv.Nutrition = false;
                            }
                            iv.Site = item.Site;
                            iv.TicketNumber = item.TicketNumber;
                            iv.User = item.TroubleUser;


                            tcvm.indexview.Add(iv);
                        }
                    }

                        test = test.Where(x => x.TechID == tech.ID && x.Friday == true).ToList();

                        foreach (var item in test)
                        {
                            IndexView iv = new IndexView();

                            iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                            iv.Equipment = item.Equipment;
                            iv.Issue = item.Issue;
                            iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                            iv.TicketNumber = item.TicketNumber;
                            iv.User = item.TroubleUser;


                            tcvm.indexview.Add(iv);
                        }
                    if (db.Schedules.Any(x => x.TechID == tech.ID))
                    {
                        MySchools ms = new MySchools();
                        ms.School = "Today";
                        if (db.Schedules.SingleOrDefault(x=>x.School == "Nutrition").TechID == tech.ID)
                        {
                            var Nutrition = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition")).Count();
                            ms.TicketCount = test.Count() + Nutrition;
                        }
                        else
                        {
                            ms.TicketCount = test.Count();
                        }
                        
                        tcvm.myschools.Add(ms);
                        tcvm.myschools = tcvm.myschools.ToList();
                    }
                }
                
                var myschools = db.Schedules.Where(x => x.TechID == tech.ID).OrderBy(x=>x.School);

                
                foreach (var item in myschools)
                {
                    if (item.School == "Nutrition")
                    {
                        MySchools ms = new MySchools();
                        var ticketcount = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition")).Count();

                        ms.School = item.School;
                        ms.TicketCount = ticketcount;

                        tcvm.myschools.Add(ms);
                    }
                    else
                    {
                        MySchools ms = new MySchools();
                        var ticketcount = db.ScheduledSchoolsTickets.Where(x => x.Site == item.School && x.TechID == tech.ID ).Count();

                        ms.School = item.School;
                        ms.TicketCount = ticketcount;
                        ms.TechID = item.TechID;

                        tcvm.myschools.Add(ms);
                    }
                    
                }
                if (db.Schedules.Any(x=>x.TechID == tech.ID))
                {
                    for (var i = 0; i < 1; i++)
                    {
                        MySchools all = new MySchools();
                        var ticketcount = db.ScheduledSchoolsTickets.Where(x => x.TechID == tech.ID).Count();

                        all.School = "Assigned";
                        all.TicketCount = ticketcount;
                        tcvm.myschools.Add(all);
                    }
                }
                
                foreach (var item in db.Schedules.OrderBy(x => x.School))
                {
                    if (item.School == "Nutrition")
                    {
                        AllSchools all = new AllSchools();
                        var ticketcount = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition")).Count();

                        all.School = item.School;
                        all.TicketCount = ticketcount;
                        tcvm.allschools.Add(all);
                    }
                    else
                    {
                        AllSchools all = new AllSchools();
                        var ticketcount = db.ScheduledSchoolsTickets.Where(x => x.Site == item.School).Count();

                        all.School = item.School;
                        all.TicketCount = ticketcount;
                        tcvm.allschools.Add(all);
                    }
                }
                for (var i = 0; i < 1; i++)
                {
                    AllSchools all = new AllSchools();
                    var ticketcount = db.ScheduledSchoolsTickets.Count();

                    all.School = "All Tickets";
                    all.TicketCount = ticketcount;
                    tcvm.allschools.Add(all);
                }

            }
            else
            {
                var NotSchool = test.Where(x => x.Site == "Panama" 
                                            || x.Site == "Stine"
                                            || x.Site == "Seibert"
                                            || x.Site == "Van Horn"
                                            || x.Site == "Castle"
                                            || x.Site == "Stockdale"
                                            || x.Site == "Sandrini"
                                            || x.Site == "Sing Lum"
                                            || x.Site == "Laurelglen"
                                            || x.Site == "Hart"
                                            || x.Site == "Loudon"
                                            || x.Site == "Buena Vista"
                                            || x.Site == "McAuliffe"
                                            || x.Site == "Williams"
                                            || x.Site == "Reagan"
                                            || x.Site == "Berkshire"
                                            || x.Site == "Old River"
                                            || x.Site == "Doug Miller"
                                            || x.Site == "Thompson"
                                            || x.Site == "Actis"
                                            || x.Site == "Tevis"
                                            || x.Site == "Warren"
                                            || x.Site == "Stonecreek"
                                            || x.Site == "Special Services");
                if (site == "Panama")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "Stine")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "SEIBERT")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "Van Horn")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "Castle")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "Stockdale")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "Sandrini")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "Sing Lum")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "Laurelglen")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "Loudon")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "Buena Vista")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "McAuliffe")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "Williams")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "Reagan")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "Berkshire")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "Old River")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "Doug Miller")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "Thompson")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "Actis")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "Tevis")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "Warren")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "Stonecreek")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (site == "Hart")
                {
                    test = test.Where(x => x.Site == site).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else
                {
                    test = test.Except(NotSchool).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
            }


            tcvm.allschools = tcvm.allschools.ToList();
            tcvm.myschools = tcvm.myschools.ToList();
            tcvm.indexview = tcvm.indexview.ToList();
            return View(tcvm);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            Create tcvm = new Create();
            IdentifySiteModel ism = new IdentifySiteModel();
            var clientIP = Request.UserHostAddress;
            var site = ism.IdentifySite(clientIP);

            var Schools = db.Schedules.Select(x => x.School).OrderBy(x=>x).ToList();
            if(site == "District Office")
            {
                var MySite = Schools.Where(x => x == site).ToList();
                foreach (var item in MySite)
                {
                    School s = new School();
                    s.Site = item;
                    tcvm.school.Add(s);
                }
                foreach (var item in Schools.Except(MySite))
                {
                    School s = new School();
                    s.Site = item;
                    tcvm.school.Add(s);
                }
            }
            else
            {
                var MySite = Schools.Where(x => x == site).ToList();
                foreach (var item in MySite)
                {
                    School s = new School();
                    s.Site = item;
                    tcvm.school.Add(s);
                }
                foreach (var item in Schools.Except(MySite))
                {
                    School s = new School();
                    s.Site = item;
                    tcvm.school.Add(s);
                }
            }
            
            foreach(var item in db.Equipments.OrderBy(x=>x.Equipment1))
            {
                CreateEquipment e = new CreateEquipment();
                e.Equipment = item.Equipment1;
                tcvm.createequipment.Add(e);
            }

            tcvm.school = tcvm.school.ToList();
            tcvm.createequipment = tcvm.createequipment.ToList();
            return View(tcvm);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Site,User,Location,Equipment,Issue,Nutrition")] Create ticket)
        {

            if (ModelState.IsValid)
            {
                Ticket t = new Ticket();

                //var user = db.StaffToSites.FirstOrDefault(x => x.BadgeNumber == ticket.User);
                //t.Site = ticket.Site;
                //t.TroubleUser = user.LastName + ", " + user.FirstName;
                //t.Location = ticket.Location;
                //if(ticket.Nutrition == true)
                //{
                //    t.Nutrition = true;
                //}
                //else if(ticket.Issue.Contains("Nutrition"))
                //{
                //    t.Nutrition = true;
                //}
                //else
                //{
                //    t.Nutrition = false;
                //}
                //t.Equipment = ticket.Equipment;
                //t.Issue = ticket.Issue;
                //t.UserEmail = user.Email;
                //t.CreateTime = DateTime.Now;
                //if(db.Schedules.Any(x=>x.School == user.Site))
                //{
                //    t.TechID = db.Schedules.SingleOrDefault(x => x.School == user.Site).TechID;
                //}
                //if(ticket.Nutrition == true || ticket.Issue.Contains("Nutrition"))
                //{
                //    t.TechID = db.Schedules.SingleOrDefault(x => x.School == "Nutrition").TechID;
                //}
                
                //t.IsArticle = false;
                //db.Tickets.Add(t);
                //db.SaveChanges();


                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var myFile = Request.Files[i];
                    if (myFile.ContentLength > 0)
                    {
                        Ticket ti = db.Tickets.OrderByDescending(x => x.TicketNumber).First();
                        Tickets.EF.Attachment a = new Tickets.EF.Attachment();
                        var fileName = ti.TicketNumber + "_" + DateTime.Now.ToString("yyyymmdd") + "_" + Path.GetFileName(myFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Attachments"), fileName);
                        myFile.SaveAs(path);
                        a.TicketNumber = ti.TicketNumber;
                        a.FileName = fileName;
                        a.FileLocation = "/Attachments/" + fileName;
                        db.Attachments.Add(a);
                        db.SaveChanges();
                    }

                }
                try
                {
                    SmtpClient client = new SmtpClient("exchange.pbvusd.net");
                    var newticket = db.Tickets.OrderByDescending(x => x.TicketNumber).First();
                    //If you need to authenticate
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("noreply@pbvusd.net");
                    if (newticket.UserEmail != null)
                    {
                        mailMessage.To.Add(newticket.UserEmail);
                    }

                    if (db.MailLists.Any(x => x.School == newticket.Site))
                    {
                        var school = db.MailLists.SingleOrDefault(x => x.School == newticket.Site);

                        mailMessage.CC.Add(school.Principal);
                        mailMessage.CC.Add(school.Librarian);
                        mailMessage.CC.Add(school.Clerk);
                    }
                    else
                    {
                        mailMessage.To.Add("dwhite@pbvusd.net");
                    }

                    mailMessage.Subject = "Ticket Creation - " + newticket.Location + " for their " + newticket.Equipment;
                    mailMessage.Body = "A ticket was created for " + newticket.TroubleUser + "\nThe issue is listed as:\n" + newticket.Issue;
                    mailMessage.IsBodyHtml = true;

                    client.Send(mailMessage);
                }
                catch (Exception)
                {


                }



                //try
                //{
                //    SmtpClient client = new SmtpClient("exchange.pbvusd.net");
                //    //If you need to authenticate
                //    MailMessage mailMessage = new MailMessage();
                //    mailMessage.From = new MailAddress("noreply@pbvusd.net");
                //    if (user.Email != null)
                //    {
                //        mailMessage.To.Add(user.Email);
                //    }

                //    if (db.MailLists.Any(x => x.School == t.Site))
                //    {
                //        var school = db.MailLists.SingleOrDefault(x => x.School == t.Site);

                //        mailMessage.CC.Add(school.Principal);
                //        mailMessage.CC.Add(school.Librarian);
                //        mailMessage.CC.Add(school.Clerk);
                //    }
                //    else
                //    {
                //        mailMessage.To.Add("jerk@pbvusd.net");
                //    }

                //    mailMessage.Subject = "Ticket Creation - " + ticket.Location + " for their " + ticket.Equipment;
                //    mailMessage.Body = "A ticket was created for " + user.FirstName + " " + user.LastName + "\nThe issue is listed as:\n" + ticket.Issue;
                //    mailMessage.IsBodyHtml = true;

                //    client.Send(mailMessage);
                //}
                //catch (Exception)
                //{


                //}



                return RedirectToAction("Index");
            }

            

            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket TechName = FormsAuthentication.Decrypt(authCookie.Value);
            var name = TechName.Name;
            var tech = db.TechLogins.SingleOrDefault(x => x.Username == name);
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            else
            {
                var Schools = db.StaffToSites.Select(x => x.Site).Distinct().OrderBy(x => x).ToList();
                var files = db.Attachments.Where(x => x.TicketNumber == id).ToList();

                foreach (var item in Schools)
                {
                    School s = new School();
                    s.Site = item;
                    tcvm.school.Add(s);
                }
                foreach(var item in db.TechLogins.Where(x=>x.IsActive == true).OrderBy(x=>x.Username))
                {
                    AssignedTech t = new AssignedTech();
                    t.TechId = item.ID;
                    t.TechName = item.LastName + ", " + item.FirstName;

                    tcvm.assignedtech.Add(t);
                }
                foreach (var item in db.Equipments.OrderBy(x => x.Equipment1))
                {
                    CreateEquipment e = new CreateEquipment();
                    e.Equipment = item.Equipment1;
                    tcvm.createequipment.Add(e);
                }
                foreach(var item in files)
                {
                    DownloadFiles df = new DownloadFiles();

                    df.Name = item.FileName;
                    df.FileLocation = item.FileLocation;

                    tcvm.downloadfiles.Add(df);
                }
                if (db.Comments.Any(x=>x.TicketNumber == id))
                {
                    var commentary = db.Comments.Where(x => x.TicketNumber == id).OrderByDescending(x=>x.TimeStamp);
                    foreach (var item in commentary)
                    {
                        CreateComments c = new CreateComments();
                        c.NewComment = item.Comment1;
                        c.TimeStamp = item.TimeStamp;
                        if(db.TechLogins.Any(x => x.ID == item.TechID))
                        {
                            var Name = db.TechLogins.SingleOrDefault(x => x.ID == item.TechID);
                            c.Tech = Name.FirstName + " " + Name.LastName;
                        }
                        
                        tcvm.createcomments.Add(c);
                    }

                }
                else
                {
                    CreateComments c = new CreateComments();
                    c.NewComment = "No Comments";
                    tcvm.createcomments.Add(c);
                }

                
                tcvm.TicketNumber = ticket.TicketNumber;
                tcvm.CreateTime = ticket.CreateTime;
                tcvm.CloseTime = ticket.CloseTime;
                tcvm.Email = ticket.UserEmail;
                tcvm.Equipment = ticket.Equipment;
                tcvm.Tech = ticket.TechID;
                tcvm.Issue = ticket.Issue;
                if(ticket.Nutrition == true)
                {
                    tcvm.Nutrition = true;
                }
                else
                {
                    tcvm.Nutrition = false;
                }
                tcvm.Location = ticket.Location;
                tcvm.Site = ticket.Site;
                tcvm.User = ticket.TroubleUser;
                tcvm.TechName = tech.Username;

                tcvm.downloadfiles = tcvm.downloadfiles.ToList();
                tcvm.createcomments = tcvm.createcomments.ToList();
                tcvm.assignedtech = tcvm.assignedtech.ToList();
                tcvm.school = tcvm.school.ToList();
                tcvm.createequipment = tcvm.createequipment.ToList();
            }
            return View(tcvm);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketNumber,Site,User,Location,Equipment,Issue,CreateTime,CloseTime,Email,Nutrition,IsArticle,Tech,TechID,NewComments,CloseTicket,OpenTicket")] TicketsCreateViewModel e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket TechName = FormsAuthentication.Decrypt(authCookie.Value);
            var name = TechName.Name;
            var tech = db.TechLogins.SingleOrDefault(x => x.Username == name);
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();
            if (ModelState.IsValid)
            {
                Comment c = new Comment();
                Ticket ticket = db.Tickets.FirstOrDefault(x => x.TicketNumber == e.TicketNumber);
                ticket.TicketNumber = e.TicketNumber;
                ticket.TechID = e.Tech;
                ticket.Site = e.Site;
                ticket.CreateTime = ticket.CreateTime;
                
                if(e.CloseTicket == true)
                {
                    ticket.CloseTime = DateTime.Now;
                }
                if(e.OpenTicket == true)
                {
                    ticket.CloseTime = null;
                }
                ticket.Location = e.Location;
                ticket.Issue = ticket.Issue;
                ticket.IsArticle = e.IsArticle;
                ticket.TroubleUser = e.User;
                ticket.Equipment = e.Equipment;
                if (e.Nutrition == true)
                {
                    ticket.Nutrition = true;
                }
                else
                {
                    ticket.Nutrition = false;
                }

                if(e.NewComments != null)
                {
                    c.TicketNumber = e.TicketNumber;
                    c.TimeStamp = DateTime.Now;
                    c.TechID = tech.ID;
                    c.Comment1 = e.NewComments;

                    db.Comments.Add(c);
                }
                
                db.Entry(ticket).State = EntityState.Modified;
                if (e.CloseTicket == true)
                {
                    try
                    {
                        SmtpClient client = new SmtpClient("exchange.pbvusd.net");
                        //If you need to authenticate
                        MailMessage mailMessage = new MailMessage();
                        mailMessage.From = new MailAddress("noreply@pbvusd.net");
                        if (ticket.UserEmail != null)
                        {
                            mailMessage.To.Add(ticket.UserEmail);
                        }
                        if (db.MailLists.Any(x => x.School == ticket.Site))
                        {
                            var school = db.MailLists.SingleOrDefault(x => x.School == ticket.Site);

                            mailMessage.CC.Add(school.Principal + "@pbvusd.net");
                            mailMessage.CC.Add(school.Librarian + "@pbvusd.net");
                            mailMessage.CC.Add(school.Clerk + "@pbvusd.net");
                        }
                        else
                        {
                            mailMessage.To.Add("dwhite@pbvusd.net");
                        }

                        var comments = "";
                        foreach (var item in db.Comments.Where(x => x.TicketNumber == ticket.TicketNumber).OrderBy(x => x.TimeStamp))
                        {
                            comments = comments + item.TimeStamp + "\n" + item.Comment1 + "\n";
                        }
                        if (e.NewComments != null)
                        {
                            comments = comments + DateTime.Now + "\n" + e.NewComments;
                        }
                        mailMessage.Subject = "Ticket Closed";
                        mailMessage.Body = "A ticket was closed for " + ticket.TroubleUser + ".\nThe issue is listed as:\n" + ticket.Issue + "\nHere are the comments:\n" + comments;

                        client.Send(mailMessage);
                    }
                    catch (Exception)
                    {

                    }
                    
                }

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var myFile = Request.Files[i];
                    if (myFile.ContentLength > 0)
                    {
                        Tickets.EF.Attachment a = new Tickets.EF.Attachment();
                        var fileName = ticket.TicketNumber + "_" + DateTime.Now.ToString("yyyymmdd") + "_" + Path.GetFileName(myFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Attachments"), fileName);
                        myFile.SaveAs(path);
                        a.TicketNumber = ticket.TicketNumber;
                        a.FileName = fileName;
                        a.FileLocation = "/Attachments/" + fileName;
                        db.Attachments.Add(a);
                    }

                }

                db.SaveChanges();
                return Redirect(Request.UrlReferrer.PathAndQuery);
            }
            return View(tcvm);
        }
        public ActionResult _getTeachers(string selectedSite)
        {
            Create tcvm = new Create();

            var selectedTeachers = db.StaffToSites.Where(i => i.Site == selectedSite).OrderBy(x=>x.LastName).ToList();

            foreach (var item in selectedTeachers)
            {
                if(tcvm.teacher.Any(x=>x.ID == item.BadgeNumber))
                {

                }
                else
                {
                    Teacher t = new Teacher();
                    t.User = item.LastName + ", " + item.FirstName;
                    t.ID = item.BadgeNumber;
                    tcvm.teacher.Add(t);
                }
                
            }
            tcvm.teacher = tcvm.teacher.Distinct().ToList();
            return PartialView(tcvm);
        }
        public ActionResult _getRoom(int? selectedbadge, string selectedSite)
        {
            Create tcvm = new Create();
            var Library = db.TeacherToRooms.Where(x => x.Room.Contains("Lib"));

            
            if (selectedbadge != null)
            {
                var site = db.StaffToSites.FirstOrDefault(x => x.BadgeNumber == selectedbadge).Site;
                if (db.TeacherToRooms.Except(Library).Any(i => i.BadgeNumber == selectedbadge))
                {
                    var selectedRoom = db.TeacherToRooms.FirstOrDefault(i => i.BadgeNumber == selectedbadge);

                    Room r = new Room();
                    r.Location = selectedRoom.Room;
                    tcvm.room.Add(r);
                }
                for (var i = 0; i < 7; i++)
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

                    else if (i == 3)
                    {
                        Room r = new Room();
                        r.Location = "Stage";
                        tcvm.room.Add(r);
                    }
                    else if (i == 4)
                    {
                        Room r = new Room();
                        r.Location = "Custodian";
                        tcvm.room.Add(r);
                    }
                    else if (i == 5)
                    {
                        Room r = new Room();
                        r.Location = "Computer Lab";
                        tcvm.room.Add(r);
                    }
                    else
                    {
                        Room r = new Room();
                        r.Location = "Music Room";
                        tcvm.room.Add(r);
                    }

                }
                if (site == "Buena Vista")
                {
                    site = "Buena Vista";
                }
                if (site == "Doug Miller")
                {
                    site = "Miller";
                }
                if (site == "Sing Lum")
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
                tcvm.Site = site;
            }
            else
            {
                if (selectedSite == "Buena Vista")
                {
                    selectedSite = "Buena Vista";
                }
                if (selectedSite == "Doug Miller")
                {
                    selectedSite = "Miller";
                }
                if (selectedSite == "Sing Lum")
                {
                    selectedSite = "Lum";
                }
                var rooms = db.TeacherToRooms.Where(x => x.Site.Contains(selectedSite)).Except(Library).Select(x => x.Room).OrderBy(x => x).GroupBy(x => x).ToList();
                foreach (var item in rooms)
                {
                    Room r = new Room();
                    r.Location = item.Key;

                    tcvm.room.Add(r);

                }
                for (var i = 0; i < 7; i++)
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

                    else if (i == 3)
                    {
                        Room r = new Room();
                        r.Location = "Stage";
                        tcvm.room.Add(r);
                    }
                    else if (i == 4)
                    {
                        Room r = new Room();
                        r.Location = "Custodian";
                        tcvm.room.Add(r);
                    }
                    else if (i == 5)
                    {
                        Room r = new Room();
                        r.Location = "Computer Lab";
                        tcvm.room.Add(r);
                    }
                    else
                    {
                        Room r = new Room();
                        r.Location = "Music Room";
                        tcvm.room.Add(r);
                    }

                }
                tcvm.Site = selectedSite;
            }


            


            
                

            

            
            tcvm.room = tcvm.room.ToList();
            return PartialView(tcvm);
        }
        public ActionResult Equipment()
        {
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();
            var equipment = db.Equipments;
            foreach (var item in equipment)
            {
                ExistingEquipment e = new ExistingEquipment();
                e.Equipment = item.Equipment1;
                e.ID = item.ID;
                tcvm.existingequipment.Add(e);
            }
            return View(tcvm);
        }
        public ActionResult EditEquipment(int? ID)
        {
            EditEquipment e = new EditEquipment();
            var equipment = db.Equipments.Find(ID);
            e.Equipment = equipment.Equipment1;
            e.ID = equipment.ID;


            return View(e);
        }
        [HttpPost, ActionName("EditEquipment")]
        [ValidateAntiForgeryToken]
        public ActionResult EditEquipment([Bind(Include = "ID, Equipment")] EditEquipment editequipment)
        {
            Equipment e = db.Equipments.Find(editequipment.ID);
            e.Equipment1 = editequipment.Equipment;
            db.SaveChanges();
            return RedirectToAction("Equipment");
        }
        [HttpPost, ActionName("DeleteEquipment")]
        public ActionResult DeleteEquipment(int? ID)
        {
            Equipment e = db.Equipments.Find(ID);
            db.Equipments.Remove(e);
            db.SaveChanges();

            return Json(new { data = true });
        }
        public ActionResult CreateEquipment()
        {
            
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEquipment([Bind(Include = "Equipment")] CreateEquipment equip)
        {
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();
            if (ModelState.IsValid)
            {
                Equipment t = new Equipment();
                t.Equipment1 = equip.Equipment;

                db.Equipments.Add(t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equip);
        }
        
        public ActionResult ShowTickets()
        {
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();
            var test = db.ScheduledSchoolsTickets.ToList();

            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                var name = ticket.Name;
                var tech = db.TechLogins.SingleOrDefault(x => x.Username == name);



                    test = test.Where(x => x.TechID == tech.ID).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                    if (item.Nutrition == true)
                    {
                        iv.Nutrition = true;
                    }
                    else
                    {
                        iv.Nutrition = false;
                    }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                

                var myschools = db.Schedules.Where(x => x.TechID == tech.ID).OrderBy(x => x.School);
                foreach (var item in myschools)
                {
                    if(myschools.Any(x=>x.School == "Nutrition"))
                    {
                        MySchools ms = new MySchools();
                        var ticketcount = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true).Count();

                        ms.School = item.School;
                        ms.TicketCount = ticketcount;

                        tcvm.myschools.Add(ms);
                    }
                    else
                    {
                        MySchools ms = new MySchools();
                        var ticketcount = db.ScheduledSchoolsTickets.Where(x => x.Site == item.School).Count();

                        ms.School = item.School;
                        ms.TicketCount = ticketcount;

                        tcvm.myschools.Add(ms);
                    }
                    
                }

                foreach (var item in db.Schedules.Except(myschools).OrderBy(x => x.School))
                {
                    if (item.School == "Nutrition")
                    {
                        AllSchools all = new AllSchools();
                        var ticketcount = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true).Count();

                        all.School = item.School;
                        all.TicketCount = ticketcount;
                        tcvm.allschools.Add(all);
                    }
                    else
                    {
                        AllSchools all = new AllSchools();
                        var ticketcount = db.ScheduledSchoolsTickets.Where(x => x.Site == item.School).Count();

                        all.School = item.School;
                        all.TicketCount = ticketcount;
                        tcvm.allschools.Add(all);
                    }
                    
                }
                for (var i = 0; i < 1; i++)
                {
                    AllSchools all = new AllSchools();
                    var ticketcount = db.ScheduledSchoolsTickets.Count();

                    all.School = "All Tickets";
                    all.TicketCount = ticketcount;
                    tcvm.allschools.Add(all);
                }

            }


            tcvm.allschools = tcvm.allschools.ToList();
            tcvm.myschools = tcvm.myschools.ToList();
            tcvm.indexview = tcvm.indexview.ToList();
            return View(tcvm);
        }
        public ActionResult SchoolTickets(string selectedSchool, int? TechID)
        {
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();
            var test = db.ScheduledSchoolsTickets.ToList();

            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                var name = ticket.Name;
                var tech = db.TechLogins.SingleOrDefault(x => x.Username == name);


                if (selectedSchool == "All Tickets")
                {
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (selectedSchool == "Nutrition")
                {
                    test = test.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition")).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else if (selectedSchool == "Today")
                {
                    if (DateTime.Now.ToString("dddd") == "Monday")
                    {
                        if (db.Schedules.SingleOrDefault(x => x.School == "Nutrition").TechID == tech.ID)
                        {
                            var Nutrition = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition")).ToList();
                            foreach (var item in Nutrition)
                            {
                                IndexView iv = new IndexView();

                                iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                                iv.Equipment = item.Equipment;
                                iv.Issue = item.Issue;
                                iv.Location = item.Location;
                                if (item.Nutrition == true)
                                {
                                    iv.Nutrition = true;
                                }
                                else
                                {
                                    iv.Nutrition = false;
                                }
                                iv.Site = item.Site;
                                iv.TicketNumber = item.TicketNumber;
                                iv.User = item.TroubleUser;


                                tcvm.indexview.Add(iv);
                            }
                        }
                        test = test.Where(x => x.TechID == tech.ID && x.Monday == true).ToList();
                        foreach (var item in test)
                        {
                            IndexView iv = new IndexView();

                            iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                            iv.Equipment = item.Equipment;
                            iv.Issue = item.Issue;
                            iv.Location = item.Location;
                            if (item.Nutrition == true)
                            {
                                iv.Nutrition = true;
                            }
                            else
                            {
                                iv.Nutrition = false;
                            }
                            iv.Site = item.Site;
                            iv.TicketNumber = item.TicketNumber;
                            iv.User = item.TroubleUser;


                            tcvm.indexview.Add(iv);
                        }
                    }
                    else if (DateTime.Now.ToString("dddd") == "Tuesday")
                    {
                        if (db.Schedules.SingleOrDefault(x => x.School == "Nutrition").TechID == tech.ID)
                        {
                            var Nutrition = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition")).ToList();
                            foreach (var item in Nutrition)
                            {
                                IndexView iv = new IndexView();

                                iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                                iv.Equipment = item.Equipment;
                                iv.Issue = item.Issue;
                                iv.Location = item.Location;
                                if (item.Nutrition == true)
                                {
                                    iv.Nutrition = true;
                                }
                                else
                                {
                                    iv.Nutrition = false;
                                }
                                iv.Site = item.Site;
                                iv.TicketNumber = item.TicketNumber;
                                iv.User = item.TroubleUser;


                                tcvm.indexview.Add(iv);
                            }
                        }
                        test = test.Where(x => x.TechID == tech.ID && x.Tuesday == true).ToList();
                        foreach (var item in test)
                        {
                            IndexView iv = new IndexView();

                            iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                            iv.Equipment = item.Equipment;
                            iv.Issue = item.Issue;
                            iv.Location = item.Location;
                            if (item.Nutrition == true)
                            {
                                iv.Nutrition = true;
                            }
                            else
                            {
                                iv.Nutrition = false;
                            }
                            iv.Site = item.Site;
                            iv.TicketNumber = item.TicketNumber;
                            iv.User = item.TroubleUser;


                            tcvm.indexview.Add(iv);
                        }
                    }
                    else if (DateTime.Now.ToString("dddd") == "Wednesday")
                    {
                        if (db.Schedules.SingleOrDefault(x => x.School == "Nutrition").TechID == tech.ID)
                        {
                            var Nutrition = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition")).ToList();
                            foreach (var item in Nutrition)
                            {
                                IndexView iv = new IndexView();

                                iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                                iv.Equipment = item.Equipment;
                                iv.Issue = item.Issue;
                                iv.Location = item.Location;
                                if (item.Nutrition == true)
                                {
                                    iv.Nutrition = true;
                                }
                                else
                                {
                                    iv.Nutrition = false;
                                }
                                iv.Site = item.Site;
                                iv.TicketNumber = item.TicketNumber;
                                iv.User = item.TroubleUser;


                                tcvm.indexview.Add(iv);
                            }
                        }
                        test = test.Where(x => x.TechID == tech.ID && x.Wednesday == true).ToList();
                        foreach (var item in test)
                        {
                            IndexView iv = new IndexView();

                            iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                            iv.Equipment = item.Equipment;
                            iv.Issue = item.Issue;
                            iv.Location = item.Location;
                            if (item.Nutrition == true)
                            {
                                iv.Nutrition = true;
                            }
                            else
                            {
                                iv.Nutrition = false;
                            }
                            iv.Site = item.Site;
                            iv.TicketNumber = item.TicketNumber;
                            iv.User = item.TroubleUser;


                            tcvm.indexview.Add(iv);
                        }
                    }
                    else if (DateTime.Now.ToString("dddd") == "Thursday")
                    {
                        if (db.Schedules.SingleOrDefault(x => x.School == "Nutrition").TechID == tech.ID)
                        {
                            var Nutrition = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition")).ToList();
                            foreach (var item in Nutrition)
                            {
                                IndexView iv = new IndexView();

                                iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                                iv.Equipment = item.Equipment;
                                iv.Issue = item.Issue;
                                iv.Location = item.Location;
                                if (item.Nutrition == true)
                                {
                                    iv.Nutrition = true;
                                }
                                else
                                {
                                    iv.Nutrition = false;
                                }
                                iv.Site = item.Site;
                                iv.TicketNumber = item.TicketNumber;
                                iv.User = item.TroubleUser;


                                tcvm.indexview.Add(iv);
                            }
                        }
                        test = test.Where(x => x.TechID == tech.ID && x.Thursday == true).ToList();
                        foreach (var item in test)
                        {
                            IndexView iv = new IndexView();

                            iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                            iv.Equipment = item.Equipment;
                            iv.Issue = item.Issue;
                            iv.Location = item.Location;
                            if (item.Nutrition == true)
                            {
                                iv.Nutrition = true;
                            }
                            else
                            {
                                iv.Nutrition = false;
                            }
                            iv.Site = item.Site;
                            iv.TicketNumber = item.TicketNumber;
                            iv.User = item.TroubleUser;


                            tcvm.indexview.Add(iv);
                        }
                    }
                    else if (DateTime.Now.ToString("dddd") == "Friday")
                    {
                        if (db.Schedules.SingleOrDefault(x => x.School == "Nutrition").TechID == tech.ID)
                        {
                            var Nutrition = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition")).ToList();
                            foreach (var item in Nutrition)
                            {
                                IndexView iv = new IndexView();

                                iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                                iv.Equipment = item.Equipment;
                                iv.Issue = item.Issue;
                                iv.Location = item.Location;
                                if (item.Nutrition == true)
                                {
                                    iv.Nutrition = true;
                                }
                                else
                                {
                                    iv.Nutrition = false;
                                }
                                iv.Site = item.Site;
                                iv.TicketNumber = item.TicketNumber;
                                iv.User = item.TroubleUser;


                                tcvm.indexview.Add(iv);
                            }
                        }
                        test = test.Where(x => x.TechID == tech.ID && x.Friday == true).ToList();
                        foreach (var item in test)
                        {
                            IndexView iv = new IndexView();

                            iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                            iv.Equipment = item.Equipment;
                            iv.Issue = item.Issue;
                            iv.Location = item.Location;
                            if (item.Nutrition == true)
                            {
                                iv.Nutrition = true;
                            }
                            else
                            {
                                iv.Nutrition = false;
                            }
                            iv.Site = item.Site;
                            iv.TicketNumber = item.TicketNumber;
                            iv.User = item.TroubleUser;


                            tcvm.indexview.Add(iv);
                        }
                    }
                }
                else if (selectedSchool == "Assigned")
                {
                    test = test.Where(x => x.TechID == tech.ID).ToList();
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }
                else
                {
                    test = test.Where(x => x.Site == selectedSchool).ToList();
                    if(TechID != null)
                    {
                        test = test.Where(x => x.TechID == TechID).ToList();
                    }
                    foreach (var item in test)
                    {
                        IndexView iv = new IndexView();

                        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                        iv.Equipment = item.Equipment;
                        iv.Issue = item.Issue;
                        iv.Location = item.Location;
                        if (item.Nutrition == true)
                        {
                            iv.Nutrition = true;
                        }
                        else
                        {
                            iv.Nutrition = false;
                        }
                        iv.Site = item.Site;
                        iv.TicketNumber = item.TicketNumber;
                        iv.User = item.TroubleUser;


                        tcvm.indexview.Add(iv);
                    }
                }

                //else
                //{
                //    char[] delimiterChars = { ' ' };
                //    string[] twowords = selectedSchool.Split(delimiterChars);
                //    var s = twowords[0].ToString();
                //    s = s.Substring(0, 1) + s.Substring(1).ToLower();
                //    var t = s;
                //    if(twowords[1] != null)
                //    {
                //        var q = twowords[1].ToString();
                //        q = q.Substring(0, 1) + s.Substring(1).ToLower();
                //        t = s + " " + q;
                //        test = test.Where(x => x.Site == selectedSchool || x.Site == s || x.Site == t).ToList();
                //    }
                //    else
                //    {
                //        test = test.Where(x => x.Site == selectedSchool || x.Site == s).ToList();
                //    }



                //    foreach (var item in test)
                //    {
                //        IndexView iv = new IndexView();

                //        iv.CreateTime = item.CreateTime.Value.ToShortDateString();
                //        iv.Equipment = item.Equipment;
                //        iv.Issue = item.Issue;
                //        iv.Location = item.Location;
                //        iv.Nutrition = item.Nutrition;
                //        iv.Site = item.Site;
                //        iv.TicketNumber = item.TicketNumber;
                //        iv.User = item.TroubleUser;


                //        tcvm.indexview.Add(iv);
                //    }
                //}


                if (db.Schedules.Any(x => x.TechID == tech.ID))
                {
                    if (DateTime.Now.ToString("dddd") == "Monday")
                    {

                        test = test.Where(x => x.TechID == tech.ID && x.Monday == true).ToList();

                        MySchools ms = new MySchools();
                        ms.School = "Today";
                        if (db.Schedules.SingleOrDefault(x => x.School == "Nutrition").TechID == tech.ID)
                        {
                            var Nutrition = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition")).Count();
                            ms.TicketCount = test.Count() + Nutrition;
                        }
                        else
                        {
                            ms.TicketCount = test.Count();
                        }
                        tcvm.myschools.Add(ms);
                        tcvm.myschools = tcvm.myschools.ToList();
                    }
                    else if (DateTime.Now.ToString("dddd") == "Tuesday")
                    {
                        test = test.Where(x => x.TechID == tech.ID && x.Tuesday == true).ToList();

                        MySchools ms = new MySchools();
                        ms.School = "Today";
                        if (db.Schedules.SingleOrDefault(x => x.School == "Nutrition").TechID == tech.ID)
                        {
                            var Nutrition = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition")).Count();
                            ms.TicketCount = test.Count() + Nutrition;
                        }
                        else
                        {
                            ms.TicketCount = test.Count();
                        }
                        tcvm.myschools.Add(ms);
                        tcvm.myschools = tcvm.myschools.ToList();
                    }
                    else if (DateTime.Now.ToString("dddd") == "Wednesday")
                    {
                        test = test.Where(x => x.TechID == tech.ID && x.Wednesday == true).ToList();

                        MySchools ms = new MySchools();
                        ms.School = "Today";
                        if (db.Schedules.SingleOrDefault(x => x.School == "Nutrition").TechID == tech.ID)
                        {
                            var Nutrition = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition")).Count();
                            ms.TicketCount = test.Count() + Nutrition;
                        }
                        else
                        {
                            ms.TicketCount = test.Count();
                        }
                        tcvm.myschools.Add(ms);
                        tcvm.myschools = tcvm.myschools.ToList();
                    }
                    else if (DateTime.Now.ToString("dddd") == "Thursday")
                    {
                        test = test.Where(x => x.TechID == tech.ID && x.Thursday == true).ToList();

                        MySchools ms = new MySchools();
                        ms.School = "Today";
                        if (db.Schedules.SingleOrDefault(x => x.School == "Nutrition").TechID == tech.ID)
                        {
                            var Nutrition = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition")).Count();
                            ms.TicketCount = test.Count() + Nutrition;
                        }
                        else
                        {
                            ms.TicketCount = test.Count();
                        }
                        tcvm.myschools.Add(ms);
                        tcvm.myschools = tcvm.myschools.ToList();
                    }
                    else if (DateTime.Now.ToString("dddd") == "Friday")
                    {
                        test = test.Where(x => x.TechID == tech.ID && x.Friday == true).ToList();

                        MySchools ms = new MySchools();
                        ms.School = "Today";
                        if (db.Schedules.SingleOrDefault(x => x.School == "Nutrition").TechID == tech.ID)
                        {
                            var Nutrition = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition")).Count();
                            ms.TicketCount = test.Count() + Nutrition;
                        }
                        else
                        {
                            ms.TicketCount = test.Count();
                        }
                        tcvm.myschools.Add(ms);
                        tcvm.myschools = tcvm.myschools.ToList();
                    }

                    var myschools = db.Schedules.Where(x => x.TechID == tech.ID).OrderBy(x => x.School);


                    foreach (var item in myschools)
                    {
                        if (item.School == "Nutrition")
                        {
                            MySchools ms = new MySchools();
                            var ticketcount = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition")).Count();

                            ms.School = item.School;
                            ms.TicketCount = ticketcount;

                            tcvm.myschools.Add(ms);
                        }
                        else
                        {
                            MySchools ms = new MySchools();
                            var ticketcount = db.ScheduledSchoolsTickets.Where(x => x.Site == item.School).Count();

                            ms.School = item.School;
                            ms.TicketCount = ticketcount;

                            tcvm.myschools.Add(ms);
                        }

                    }
                    if (db.Schedules.Any(x => x.TechID == tech.ID))
                    {
                        for (var i = 0; i < 1; i++)
                        {
                            MySchools all = new MySchools();
                            var ticketcount = db.ScheduledSchoolsTickets.Where(x => x.TechID == tech.ID).Count();

                            all.School = "Assigned";
                            all.TicketCount = ticketcount;
                            tcvm.myschools.Add(all);
                        }
                    }
                }

                    foreach (var item in db.Schedules.OrderBy(x => x.School))
                    {
                        if (item.School == "Nutrition")
                        {
                            AllSchools all = new AllSchools();
                            var ticketcount = db.ScheduledSchoolsTickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition")).Count();

                            all.School = item.School;
                            all.TicketCount = ticketcount;
                            tcvm.allschools.Add(all);
                        }
                        else
                        {
                            AllSchools all = new AllSchools();
                            var ticketcount = db.ScheduledSchoolsTickets.Where(x => x.Site == item.School).Count();

                            all.School = item.School;
                            all.TicketCount = ticketcount;
                            tcvm.allschools.Add(all);
                        }
                    }
                    for (var i = 0; i < 1; i++)
                    {
                        AllSchools all = new AllSchools();
                        var ticketcount = db.ScheduledSchoolsTickets.Count();

                        all.School = "All Tickets";
                        all.TicketCount = ticketcount;
                        tcvm.allschools.Add(all);
                    }

                
            }


            tcvm.allschools = tcvm.allschools.ToList();
            tcvm.myschools = tcvm.myschools.ToList();
            tcvm.Site = selectedSchool;
            tcvm.indexview = tcvm.indexview.ToList();
            return View(tcvm);
        }
        public ActionResult SiteView(int? id)
        {
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            else
            {
                var Schools = db.StaffToSites.Select(x => x.Site).Distinct().OrderBy(x => x).ToList();
                var files = db.Attachments.Where(x => x.TicketNumber == id).ToList();

                foreach (var item in Schools)
                {
                    School s = new School();
                    s.Site = item;
                    tcvm.school.Add(s);
                }
                foreach (var item in files)
                {
                    DownloadFiles df = new DownloadFiles();

                    df.Name = item.FileName;
                    df.FileLocation = item.FileLocation;

                    tcvm.downloadfiles.Add(df);
                }
                foreach (var item in db.TechLogins.Where(x => x.IsActive == true).OrderBy(x => x.Username))
                {
                    AssignedTech t = new AssignedTech();
                    t.TechId = item.ID;
                    t.TechName = item.LastName + ", " + item.FirstName;

                    tcvm.assignedtech.Add(t);
                }
                foreach (var item in db.Equipments.OrderBy(x => x.Equipment1))
                {
                    CreateEquipment e = new CreateEquipment();
                    e.Equipment = item.Equipment1;
                    tcvm.createequipment.Add(e);
                }
                if (db.Comments.Any(x => x.TicketNumber == id))
                {
                    var commentary = db.Comments.Where(x => x.TicketNumber == id).OrderByDescending(x => x.TimeStamp);
                    foreach (var item in commentary)
                    {
                        CreateComments c = new CreateComments();
                        c.NewComment = item.Comment1;
                        c.TimeStamp = item.TimeStamp;
                        tcvm.createcomments.Add(c);
                    }

                }
                else
                {
                    CreateComments c = new CreateComments();
                    c.NewComment = "No Comments";
                    tcvm.createcomments.Add(c);
                }
                var techName = db.TechLogins.SingleOrDefault(x => x.ID == ticket.TechID);
                tcvm.TicketNumber = ticket.TicketNumber;
                tcvm.CreateTime = ticket.CreateTime;
                tcvm.CloseTime = ticket.CloseTime;
                tcvm.Email = ticket.UserEmail;
                tcvm.Equipment = ticket.Equipment;
                tcvm.TechName = techName.LastName + ", " + techName.FirstName;
                tcvm.Issue = ticket.Issue;
                if (ticket.Nutrition == true)
                {
                    tcvm.Nutrition = true;
                }
                else
                {
                    tcvm.Nutrition = false;
                }
                tcvm.Location = ticket.Location;
                tcvm.Site = ticket.Site;
                tcvm.User = ticket.TroubleUser;

                tcvm.createcomments = tcvm.createcomments.ToList();
                tcvm.assignedtech = tcvm.assignedtech.ToList();
                tcvm.school = tcvm.school.ToList();
                tcvm.createequipment = tcvm.createequipment.ToList();
            }
            return View(tcvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SiteView([Bind(Include = "TicketNumber,Site,User,Location,Equipment,Issue,CreateTime,CloseTime,Email,Nutrition,IsArticle,Tech,TechID,NewComments,CloseTicket,OpenTicket")] TicketsCreateViewModel e)
        {
            TicketsCreateViewModel tcvm = new TicketsCreateViewModel();
            if (ModelState.IsValid)
            {
                Ticket ticket = db.Tickets.FirstOrDefault(x => x.TicketNumber == e.TicketNumber);
                ticket.TicketNumber = ticket.TicketNumber;
                ticket.TechID = ticket.TechID;
                ticket.Site = ticket.Site;
                ticket.CreateTime = ticket.CreateTime;
                ticket.Location = ticket.Location;
                ticket.Issue = e.Issue;
                ticket.IsArticle = ticket.IsArticle;
                ticket.TroubleUser = ticket.TroubleUser;
                ticket.Equipment = ticket.Equipment;
                ticket.Nutrition = ticket.Nutrition;

                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var myFile = Request.Files[i];
                    if (myFile.ContentLength > 0)
                    {
                        Ticket ti = db.Tickets.Find(ticket.TicketNumber);
                        Tickets.EF.Attachment a = new Tickets.EF.Attachment();
                        var fileName = ti.TicketNumber + "_" + DateTime.Now.ToString("yyyymmdd") + "_" + Path.GetFileName(myFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Attachments"), fileName);
                        myFile.SaveAs(path);
                        a.TicketNumber = ti.TicketNumber;
                        a.FileName = fileName;
                        a.FileLocation = "/Attachments/" + fileName;
                        db.Attachments.Add(a);
                        db.SaveChanges();
                    }

                }

                return Redirect(Request.UrlReferrer.PathAndQuery);
            }
            return View(tcvm);
        }
        public ActionResult _getDO()
        {
            Create tcvm = new Create();
            return PartialView(tcvm);
        }
    }
}
