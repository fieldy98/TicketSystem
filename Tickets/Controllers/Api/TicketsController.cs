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
using System.Net.Mail;

namespace Tickets.Controllers.Api
{
    public class TicketsController : ApiController
    {
        TicketsEntities db = new TicketsEntities();
        public IEnumerable<TicketsDto> GetTickets()
        {
            return db.Tickets.ToList().Select(Mapper.Map<Ticket, TicketsDto>);
        }
        public TicketsDto GetTicket(int id)
        {
            var ticket = db.Tickets.SingleOrDefault(x => x.TicketNumber == id);
            if (ticket == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Ticket, TicketsDto>(ticket);
        }
        public TicketsDto CreateTicket(TicketsDto ticketsDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var teacher = db.StaffToSites.SingleOrDefault(x => x.BadgeNumber == ticketsDto.BadgeNumber);
            var LastName = teacher.LastName.Trim();
            var FirstName = teacher.FirstName.Trim();
            var ticket = Mapper.Map<TicketsDto, Ticket>(ticketsDto);
            ticket.CreateTime = DateTime.Now;
            ticket.TroubleUser = LastName + ", " + FirstName;
            ticket.UserEmail = teacher.Email;
            if (ticketsDto.Nutrition == true || ticketsDto.Issue.Contains("Nutrition") || ticketsDto.Location == "Nutrition")
                ticket.TechID = db.Schedules.FirstOrDefault(x => x.School == "Nutrition").TechID;
            else
                ticket.TechID = db.Schedules.FirstOrDefault(x => x.School == ticketsDto.Site).TechID;
            db.Tickets.Add(ticket);
            db.SaveChanges();

            return ticketsDto;

        }
    }
    
}
