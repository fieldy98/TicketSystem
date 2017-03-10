using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tickets.Dtos
{
    public class TechOpenTicketsDto
    {
        public string School { get; set; }
        public int? TechID { get; set; }
        public int? OpenTickets { get; set; }
    }
}