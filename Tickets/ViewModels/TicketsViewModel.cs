using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tickets.ViewModels
{
    public class TicketsCreateViewModel
    {

        public int TicketNumber { get; set; }
        public string Site { get; set; }
        public string User { get; set; }
        public int? UserID { get; set; }
        public string Location { get; set; }
        public string Equipment { get; set; }
        public string Issue { get; set; }
        public string TechName { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? CloseTime { get; set; }
        public string NewComments { get; set; }
        public string Email { get; set; }
        public bool Nutrition { get; set; }
        public bool? IsArticle { get; set; }
        public int? Tech { get; set; }
        public int? TechID { get; set; }
        public bool CloseTicket { get; set; }
        public bool OpenTicket { get; set; }
        public bool? IsAdmin { get; set; }
        public int? NumberOfTickets { get; set; }
        public List<Create> create { get; set; }
        public List<School> school { get; set; }
        public List<Teacher> teacher { get; set; }
        public List<Room> room { get; set; }
        public List<CreateEquipment> createequipment { get; set; }
        public List<CreateComments> createcomments { get; set; }
        public List<AssignedTech> assignedtech { get; set; }
        public List<ChangePassword> changepassword { get; set; }
        public List<SchoolAssigments> schoolassignments { get; set; }
        public List<IndexView> indexview { get; set; }
        public List<StaffToEmail> stafftoemail { get; set; }
        public List<AllTickets> alltickets { get; set; }
        public List<MySchools> myschools { get; set; }
        public List<AllSchools> allschools { get; set; }
        public List<Techs> techs { get; set; }
        public List<InactiveTechs> inactivetechs { get; set; }
        public List<OpenedTickets> openedtickets { get; set; }
        public List<ClosedTickets> closedtickets { get; set; }
        public List<Opened> opened{ get; set; }
        public List<Closed> closed{ get; set; }
        public List<Chart> chart { get; set; }
        public List<TechOpened> techopened { get; set; }
        public List<TechClose> techclose { get; set; }
        public List<Projector> projector { get; set; }
        public List<PerSchool> perschool { get; set; }
        public List<DownloadFiles> downloadfiles { get; set; }
        public List<ExistingEquipment> existingequipment { get; set; }
        public TicketsCreateViewModel()
        {
            school = new List<School>();
            teacher = new List<Teacher>();
            create = new List<Create>();
            room = new List<Room>();
            createequipment = new List<CreateEquipment>();
            createcomments = new List<CreateComments>();
            assignedtech = new List<AssignedTech>();
            changepassword = new List<ChangePassword>();
            schoolassignments = new List<SchoolAssigments>();
            indexview = new List<IndexView>();
            stafftoemail = new List<StaffToEmail>();
            alltickets = new List<AllTickets>();
            myschools = new List<MySchools>();
            allschools = new List<AllSchools>();
            techs = new List<Techs>();
            inactivetechs = new List<InactiveTechs>();
            openedtickets = new List<OpenedTickets>();
            closedtickets = new List<ClosedTickets>();
            opened= new List<Opened>();
            closed= new List<Closed>();
            chart = new List<Chart>();
            techopened = new List<TechOpened>();
            techclose = new List<TechClose>();
            projector = new List<Projector>();
            perschool = new List<PerSchool>();
            downloadfiles = new List<DownloadFiles>();
            existingequipment = new List<ExistingEquipment>();
        }
    }
    public class Create
    {
        public int TicketNumber { get; set; }
        [Required]
        public string Site { get; set; }
        [Required]
        public int? User { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Equipment { get; set; }
        [Required]
        public string Issue { get; set; }
        public string TroubleUser { get; set; }
        public string Time { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Email { get; set; }
        public bool Nutrition { get; set; }
        public List<CreateEquipment> createequipment { get; set; }
        public List<School> school { get; set; }
        public List<Teacher> teacher { get; set; }
        public List<Room> room { get; set; }
        public Create()
        {
            school = new List<School>();
            createequipment = new List<CreateEquipment>();
            teacher = new List<Teacher>();
            room = new List<Room>();
        }
    }
    public class School
    {
        public string Site { get; set; }
    }
    public class Teacher
    {
        public string User { get; set; }
        public int? ID { get; set; }
    }
    public class Room
    {
        public string Location { get; set; }
    }
    public class CreateEquipment
    {
        [Required]
        public string Equipment { get; set; }
    }
    public class CreateComments
    {
        public string NewComment { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string Tech { get; set; }
    }
    public class AssignedTech
    {
        public string TechName { get; set; }
        public int? TechId { get; set; }
    }
    public class ChangePassword
    {
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        public int ID { get; set; }
        [Required]
        public string OldPassword { get; set; }
    }
    public class SchoolAssigments
    {
        public string School { get; set; }
        public string Day1 { get; set; }
        public string Day2 { get; set; }
        public string TechName { get; set; }
        public string Poc1 { get; set; }
        public string Poc2 { get; set; }
        public string Poc3 { get; set; }
    }
    public class Assignments
    {
        public string School { get; set; }
        public int? TechID { get; set; }
        public bool? Monday { get; set; }
        public bool? Tuesday { get; set; }
        public bool? Wednesday { get; set; }
        public bool? Thursday { get; set; }
        public bool? Friday { get; set; }
        public List<SchoolTech> schooltech { get; set; }
        public Assignments()
        {
            schooltech = new List<SchoolTech>();
        }
    }
    public class SchoolTech
    {
        public int? TechID { get; set; }
        public string TechName { get; set; }
    }
    public class IndexView
    {
        public int? TicketNumber { get; set; }
        public string Site { get; set; }
        public string User { get; set; }
        public string Location { get; set; }
        public string Equipment { get; set; }
        public string Issue { get; set; }
        public string CreateTime { get; set; }
        public bool Nutrition { get; set; }
    }
    public class RegisterUser
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public bool? IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public int ID { get; set; }

    }
    public class EditUser
    {
        public string Username { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool? IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public int ID { get; set; }

    }
    public class AllTickets
    {
        public string Name { get; set; }
        public string Value { get; set;}
    }
   public class StaffToEmail
    {
        public string School { get; set; }
        public string Principal { get; set; }
        public string Clerk { get; set; }
        public string Librarian { get; set; }
    }
    public class MySchools
    {
        public string School { get; set; }
        public int? TicketCount { get; set; }
        public int? TechID { get; set; }
    }
    public class AllSchools
    {
        public string School { get; set; }
        public int? TicketCount { get; set; }
    }
    public class Techs
    {
        public string Tech { get; set; }
        public int? TechID { get; set; }
        public string IsAdmin { get; set; }
    }
    public class InactiveTechs
    {
        public string Tech { get; set; }
        public int? TechID { get; set; }
        public string IsAdmin { get; set; }
    }
    public class Opened
    {
        public DateTime? Date { get; set; }
    }
    public class OpenedTickets
    {
        public string Date { get; set; }
        public int? Count { get; set; }
    }
    public class Closed
    {
        public DateTime? Date { get; set; }
    }
    public class ClosedTickets
    {
        public string Date { get; set; }
        public int? Count { get; set; }
    }
    public class Chart
    {
        public string Equipment { get; set; }
        public int? Count { get; set; }
    }
    public class TechOpened
    {
        public string Name { get; set; }
        public int? Count { get; set; }
    }
    public class TechClose
    {
        public string Name { get; set; }
        public int? Count { get; set; }
    }
    public class Projector
    {
        public string School { get; set; }
        public int? Count { get; set; }
    }
    public class PerSchool
    {
        public string School { get; set; }
        public int? Count { get; set; }
    }
    public class DownloadFiles
    {
        public string Name { get; set; }
        public string FileLocation { get; set; }
    }
    public class ExistingEquipment
    {
        public string Equipment { get; set; }
        public int? ID { get; set; }
    }
    public class EditEquipment
    {
        public string Equipment { get; set; }
        public int? ID { get; set; }
    }
}