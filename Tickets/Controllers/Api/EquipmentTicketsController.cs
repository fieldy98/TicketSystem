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
    public class EquipmentTicketsController : ApiController
    {
        TicketsEntities db = new TicketsEntities();
        public IEnumerable<EquipmentTicketsDto> GetGraphs()
        {
            return db.EquipmentCounts.ToList().Select(Mapper.Map<EquipmentCount, EquipmentTicketsDto>);
        }
    }
}
