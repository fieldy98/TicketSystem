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
    public class TechClosesController : ApiController
    {
        TicketsEntities db = new TicketsEntities();
        public IEnumerable<TechCloseDto> GetTechCloses()
        {
            return db.TechCloseds.ToList().Select(Mapper.Map<TechClosed,TechCloseDto>);
        }
    }
}
