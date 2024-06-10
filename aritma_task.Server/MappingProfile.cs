using aritma_task.Server.Dto.Request;
using aritma_task.Server.Dto.Response;
using aritma_task.Server.Models;
using AutoMapper;

namespace aritma_task.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Loan, LoanResponse>().ReverseMap();
        CreateMap<LoanRequest, Loan>().ForMember(
            dest => dest.StartDate, 
            src => src.MapFrom(x => DateTime.Now));
        CreateMap<LoanType, LoanTypeResponse>().ReverseMap();
    }
}