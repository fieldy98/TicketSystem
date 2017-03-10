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
        public IEnumerable<TodaysOpenTicketsDto> GetSchoolTickets(string school)
        {
            return db.TicketsForTodays.Where(x => x.Site == school).ToList().Select(Mapper.Map<TicketsForToday, TodaysOpenTicketsDto>);
        }
    }
}
