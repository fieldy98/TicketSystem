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
            ticket.TechID = db.Schedules.FirstOrDefault(x => x.School == ticketsDto.Site).TechID;
            db.Tickets.Add(ticket);
            db.SaveChanges();


            try
            {
                SmtpClient client = new SmtpClient("exchange.pbvusd.net");
                //If you need to authenticate
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("noreply@pbvusd.net");
                if (ticket.UserEmail!= null)
                {
                    mailMessage.To.Add(ticket.UserEmail);
                }

                if (db.MailLists.Any(x => x.School == ticket.Site))
                {
                    var school = db.MailLists.SingleOrDefault(x => x.School == ticket.Site);

                    mailMessage.CC.Add(school.Principal);
                    mailMessage.CC.Add(school.Librarian);
                    mailMessage.CC.Add(school.Clerk);
                }
                else
                {
                    mailMessage.To.Add("jerk@pbvusd.net");
                }

                mailMessage.Subject = "Ticket Creation - " + ticket.Location + " for their " + ticket.Equipment;
                mailMessage.Body = "A ticket was created for " + ticket.TroubleUser + "\nThe issue is listed as:\n" + ticket.Issue;
                mailMessage.IsBodyHtml = true;

                client.Send(mailMessage);
            }
            catch (Exception)
            {


            }

            return ticketsDto;

        }
    }
    
}
