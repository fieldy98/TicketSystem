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
            return db.TechOpenTicketsCounts.ToList().Select(Mapper.Map<TechOpenTicketsCount, TechOpenTicketsDto>);
        }
        public IEnumerable<TechOpenTicketsDto> GetTechTicketsCount(int id)
        {
            return db.TechOpenTicketsCounts.Where(x=>x.TechID == id).ToList().Select(Mapper.Map<TechOpenTicketsCount, TechOpenTicketsDto>);
        }
    }
}
