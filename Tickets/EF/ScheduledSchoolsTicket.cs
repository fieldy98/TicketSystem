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
    
    public partial class ScheduledSchoolsTicket
    {
        public int TicketNumber { get; set; }
        public string Site { get; set; }
        public string TroubleUser { get; set; }
        public string Location { get; set; }
        public string Equipment { get; set; }
        public string Issue { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> CloseTime { get; set; }
        public string UserEmail { get; set; }
        public Nullable<int> TechID { get; set; }
        public Nullable<bool> Nutrition { get; set; }
        public Nullable<bool> Monday { get; set; }
        public Nullable<bool> Tuesday { get; set; }
        public Nullable<bool> Wednesday { get; set; }
        public Nullable<bool> Thursday { get; set; }
        public Nullable<bool> Friday { get; set; }
    }
}