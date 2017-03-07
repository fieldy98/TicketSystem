using System;
using Tickets.EF;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Tickets.Dtos;

namespace Tickets.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<TechClosed, TechCloseDto>();
            Mapper.CreateMap<TechCloseDto, TechClosed>();
            Mapper.CreateMap<TechOpen, TechOpenDto>();
            Mapper.CreateMap<TechOpenDto, TechOpen>();
            Mapper.CreateMap<ProjectorIssue, ProjectorDto>();
            Mapper.CreateMap<ProjectorDto, ProjectorIssue>();
            Mapper.CreateMap<LastYearTicket, LastYearTicketDto>();
            Mapper.CreateMap<LastYearTicketDto, LastYearTicket>();
            Mapper.CreateMap<GraphLastYear, GraphTicketsDto>();
            Mapper.CreateMap<GraphTicketsDto, GraphLastYear>();
            Mapper.CreateMap<EquipmentCount, EquipmentTicketsDto>();
            Mapper.CreateMap<EquipmentTicketsDto, EquipmentCount>();
            Mapper.CreateMap<Ticket, TicketsDto>();
            Mapper.CreateMap<TicketsDto, Ticket>();
            Mapper.CreateMap<Attachment, AttachmentsDto>();
            Mapper.CreateMap<AttachmentsDto, Attachment>();
        }
    }
}