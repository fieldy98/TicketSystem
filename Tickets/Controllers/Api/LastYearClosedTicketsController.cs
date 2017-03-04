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

namespace Tickets.Controllers.Api
{
    public class LastYearClosedTicketsController : ApiController
    {
        TicketsEntities db = new TicketsEntities();
        public IEnumerable<LastYearTicketDto> GetProjectors()
        {
            return db.LastYearTickets.ToList().Select(Mapper.Map<LastYearTicket, LastYearTicketDto>);
        }
    }
}
