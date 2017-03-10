using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tickets.Dtos
{
    public class TodaysOpenTicketsDto
    {
        public int TicketNumber { get; set; }
        public string Site { get; set; }
        public string TroubleUser { get; set; }
        public string Location { get; set; }
        public string Equipment { get; set; }
        public string Issue { get; set; }
        public DateTime? CreateTime { get; set; }
        public string UserEmail { get; set; }
    }
}