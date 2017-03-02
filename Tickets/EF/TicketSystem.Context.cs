﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TicketsEntities : DbContext
    {
        public TicketsEntities()
            : base("name=TicketsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<MailList> MailLists { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<StaffToSite> StaffToSites { get; set; }
        public virtual DbSet<TeacherToRoom> TeacherToRooms { get; set; }
        public virtual DbSet<TechLogin> TechLogins { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<Main> Mains { get; set; }
        public virtual DbSet<EquipmentCount> EquipmentCounts { get; set; }
        public virtual DbSet<NumberClosed> NumberCloseds { get; set; }
        public virtual DbSet<NumberClosedMonth> NumberClosedMonths { get; set; }
        public virtual DbSet<NumberOpened> NumberOpeneds { get; set; }
        public virtual DbSet<NumberOpenedMonth> NumberOpenedMonths { get; set; }
        public virtual DbSet<ProjectorIssue> ProjectorIssues { get; set; }
        public virtual DbSet<ScheduledSchoolsTicket> ScheduledSchoolsTickets { get; set; }
        public virtual DbSet<SchoolName> SchoolNames { get; set; }
        public virtual DbSet<TechClosed> TechCloseds { get; set; }
        public virtual DbSet<TechOpen> TechOpens { get; set; }
    }
}
