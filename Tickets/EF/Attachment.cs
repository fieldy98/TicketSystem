//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tickets.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Attachment
    {
        public int ID { get; set; }
        public int TicketNumber { get; set; }
        public string FileLocation { get; set; }
        public string FileName { get; set; }
    }
}
