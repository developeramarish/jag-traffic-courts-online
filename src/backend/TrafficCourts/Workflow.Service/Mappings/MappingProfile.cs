using AutoMapper;

namespace TrafficCourts.Workflow.Service.Mappings;

public class MessageContractToDisputeMappingProfile : Profile
{
    public MessageContractToDisputeMappingProfile()
    {
        CreateMap<Messaging.MessageContracts.SubmitNoticeOfDispute, Common.OpenAPIs.OracleDataApi.v1_0.Dispute>()
            .ForMember(dest => dest.NoticeOfDisputeGuid, opt => opt.MapFrom(src => src.NoticeOfDisputeGuid.ToString("d")))
            .ForMember(dest => dest.DriversLicenceIssuedCountryId, opt => opt.MapFrom(src => src.DriversLicenceCountryId))
            .ForMember(dest => dest.DriversLicenceIssuedProvinceSeqNo, opt => opt.MapFrom(src => src.DriversLicenceProvinceSeqNo));
        
        CreateMap<Messaging.MessageContracts.DisputeCount, Common.OpenAPIs.OracleDataApi.v1_0.DisputeCount>();
        
        CreateMap<Messaging.MessageContracts.ViolationTicket, Common.OpenAPIs.OracleDataApi.v1_0.ViolationTicket>()
            // Automapper can't map from DateOnly -> DateTimeOffset
            .ForMember(dest => dest.DisputantBirthdate, opt => opt.MapFrom(src => new DateTimeOffset(new DateTime(src.DisputantBirthdate.Year, src.DisputantBirthdate.Month, src.DisputantBirthdate.Day))));
        
        CreateMap<Messaging.MessageContracts.TicketCount, Common.OpenAPIs.OracleDataApi.v1_0.ViolationTicketCount>();
        
        CreateMap<Messaging.MessageContracts.SaveFileHistoryRecord, Common.OpenAPIs.OracleDataApi.v1_0.FileHistory>();

        CreateMap<Common.OpenAPIs.OracleDataApi.v1_0.Dispute, Messaging.MessageContracts.SubmitNoticeOfDispute>()
            .ForMember(dest => dest.NoticeOfDisputeGuid, opt => opt.MapFrom(src => Guid.Parse(src.NoticeOfDisputeGuid)))
            .ForMember(dest => dest.DriversLicenceCountryId, opt => opt.MapFrom(src => src.DriversLicenceIssuedCountryId))
            .ForMember(dest => dest.DriversLicenceProvinceSeqNo, opt => opt.MapFrom(src => src.DriversLicenceIssuedProvinceSeqNo));

        CreateMap<Common.OpenAPIs.OracleDataApi.v1_0.DisputeCount, Messaging.MessageContracts.DisputeCount>();
        
        CreateMap<Common.OpenAPIs.OracleDataApi.v1_0.ViolationTicket, Messaging.MessageContracts.ViolationTicket>()
            .ForMember(dest => dest.ViolationTicketCounts, opt => opt.MapFrom(src => src.ViolationTicketCounts));

        CreateMap<DateOnly, DateTime>();
    }
}
