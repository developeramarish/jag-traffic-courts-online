﻿using AutoMapper;
using Gov.CitizenApi.Features.Tickets.Commands;
using Gov.CitizenApi.Features.Tickets.DBModel;
using Gov.CitizenApi.Models;
using Gov.TicketSearch;
using DisputeOffence = Gov.CitizenApi.Models.Offence;
using TicketSearchOffence = Gov.TicketSearch.Offence;

namespace Gov.CitizenApi.Features.Tickets.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TicketSearchResponse, TicketDispute>();

            CreateMap<TicketSearchOffence, DisputeOffence>();

            CreateMap<CreateShellTicketCommand, Ticket>()
                .ForMember(dest => dest.Offences, opt => opt.MapFrom<TicketOffencesResolver>())
                ;

            CreateMap<DisputeOffence, Gov.CitizenApi.Features.Tickets.DBModel.Offence>();

            CreateMap<Ticket, TicketSearchResponse>()
                .ForMember(dest => dest.Offences, opt => opt.MapFrom(src=>src.Offences))
                ;

            CreateMap<DBModel.Offence, TicketSearchOffence>();
        }
    }
}