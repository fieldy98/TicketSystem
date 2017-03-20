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
    public class AttachmentsController : ApiController
    {
        TicketsEntities db = new TicketsEntities();
        public IEnumerable<AttachmentsDto> GetAttachments()
        {
            return db.Attachments.ToList().Select(Mapper.Map<Attachment, AttachmentsDto>);
        }
        public AttachmentsDto GetTicket(int ID)
        {
            var ticket = db.Attachments.SingleOrDefault(x => x.TicketNumber == ID);
            if (ticket == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Attachment, AttachmentsDto>(ticket);
        }
    }
}
