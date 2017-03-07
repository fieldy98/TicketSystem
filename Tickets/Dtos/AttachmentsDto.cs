using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tickets.Dtos
{
    public class AttachmentsDto
    {
        public int? TicketNumber { get; set; }
        public string FileLocation { get; set; }
        public string FileName { get; set; }
    }
}