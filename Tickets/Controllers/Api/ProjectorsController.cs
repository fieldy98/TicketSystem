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
    public class ProjectorsController : ApiController
    {
        TicketsEntities db = new TicketsEntities();
        public IEnumerable<ProjectorDto> GetProjectors()
        {
            return db.ProjectorIssues.ToList().Select(Mapper.Map<ProjectorIssue, ProjectorDto>);
        }
    }
}
