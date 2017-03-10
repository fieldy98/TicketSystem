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
    public class TodaysOpenTicketsController : ApiController
    {
        TicketsEntities db = new TicketsEntities();
        public IEnumerable<TodaysOpenTicketsDto> GetTodaysTickets(int id, string day)
        {
            var tickets = db.TicketsForTodays.Where(x => x.TechID == id);
            return tickets.Where(x=>x.TechID == id && x.Day1 == day || x.Day2 == day || x.Day3 == day || x.Day4 == day || x.Day5 == day).ToList().Select(Mapper.Map<TicketsForToday, TodaysOpenTicketsDto>);
        }
    }
}
