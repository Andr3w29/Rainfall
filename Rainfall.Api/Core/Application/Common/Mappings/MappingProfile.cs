using AutoMapper;
using Rainfall.Api.Core.Application.Common.Response.Rainfall;

namespace Rainfall.Api.Core.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Rainfall.Api.Core.Application.Common.Response.External.RainfallReading, RainfallReading>()
            .ForMember(dest => dest.DateMeasured, opt => opt.MapFrom(src => src.DateTime))
           .ForMember(dest => dest.AmountMeasured, opt => opt.MapFrom(src => src.Value));
    }


}
