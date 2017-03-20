using Tickets.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Tickets.Dtos;
using System.Web;
using System.Web.Security;

namespace Tickets.Controllers.Api
{
    public class TicketsForSchoolsController : ApiController
    {
        TicketsEntities db = new TicketsEntities();
        public IEnumerable<TicketsDto> GetSchoolTickets(string school)
        {
            if(school == "Nutrition")
            {
                var tickets = db.Tickets.Where(x => x.CloseTime == null);
                return tickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition") || x.Location == "Nutrition").ToList().Select(Mapper.Map<Ticket, TicketsDto>);
            }
            else if (school == "All Tickets")
            {
                return db.Tickets.Where(x => x.CloseTime == null).ToList().Select(Mapper.Map<Ticket, TicketsDto>);
            }
            else
            {
                var NoNutrition = db.Tickets.Where(x => x.Nutrition == true || x.Issue.Contains("Nutrition") || x.Location == "Nutrition");
                return db.Tickets.Where(x => x.Site == school && x.CloseTime == null).Except(NoNutrition).ToList().Select(Mapper.Map<Ticket, TicketsDto>);
            }
            
        }
        public IEnumerable<TicketsDto> Get(string school, int ID)
        {
            if(school == "Assigned Tickets")
            {
                return db.Tickets.Where(x => x.TechID == ID && x.CloseTime == null).ToList().Select(Mapper.Map<Ticket, TicketsDto>);
            }
            else
            {
                return db.Tickets.Where(x => x.Site == school && x.TechID == ID && x.CloseTime == null).ToList().Select(Mapper.Map<Ticket, TicketsDto>);
            }
        }
    }
}
