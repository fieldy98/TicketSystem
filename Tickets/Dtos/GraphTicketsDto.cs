using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tickets.Dtos
{
    public class GraphTicketsDto
    {
        public int? Year { get; set; }
        public string Month { get; set; }
        public int? Opened { get; set; }
        public int? Closed { get; set; }
    }
}