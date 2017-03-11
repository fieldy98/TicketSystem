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
            return db.Tickets.Where(x => x.Site == school && x.CloseTime == null).ToList().Select(Mapper.Map<Ticket, TicketsDto>);
        }
    }
}
