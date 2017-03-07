using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tickets.Dtos
{
    public class TicketsDto
    {
        public int? TicketNumber { get; set; }
        public string Site { get; set; }
        public string TroubleUser { get; set; }
        public int BadgeNumber{ get; set; }
        public string Location { get; set; }
        public string Equipment { get; set; }
        public string Issue { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? CloseTime { get; set; }
        public string UserEmail { get; set; }
        public int? TechID { get; set; }
        public bool? Nutrition { get; set; }
    }
}