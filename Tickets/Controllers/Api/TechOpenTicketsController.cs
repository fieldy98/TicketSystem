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
    public class TechOpenTicketsController : ApiController
    {
        TicketsEntities db = new TicketsEntities();
        public IEnumerable<TechOpenTicketsDto> GetTicketsCount()
        {
            var NotAssignedTickets = db.TechOpenTicketsCounts.Where(x => x.School == "Assigned Tickets");
            return db.TechOpenTicketsCounts.Except(NotAssignedTickets).OrderBy(x => x.rn).ToList().Select(Mapper.Map<TechOpenTicketsCount, TechOpenTicketsDto>);
        }
        public IEnumerable<TechOpenTicketsDto> GetTechTicketsCount(int id)
        {
            var NotAllSites = db.TechOpenTicketsCounts.Where(x => x.School == "All Tickets");
            return db.TechOpenTicketsCounts.Where(x => x.TechID == id).Except(NotAllSites).OrderBy(x=>x.rn).ToList().Select(Mapper.Map<TechOpenTicketsCount, TechOpenTicketsDto>);
        }

    }
}
