using AutoMapper;
using borker_api.DAL.Entities;

namespace borker_api.Models.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Rate, KeyValuePair<DateTime, RateVis>>()
                .ConstructUsing(x => new KeyValuePair<DateTime, RateVis>(x.Date, new RateVis() { EUR = x.EUR, RUB = x.RUB, GBP = x.GBP, JPY = x.JPY }));

            CreateMap<ApiInteraction.Models.Rate, DAL.Entities.Rate>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.RUB, opt => opt.MapFrom(src => src.Currency.RUB))
                .ForMember(dest => dest.EUR, opt => opt.MapFrom(src => src.Currency.EUR))
                .ForMember(dest => dest.GBP, opt => opt.MapFrom(src => src.Currency.GBP))
                .ForMember(dest => dest.JPY, opt => opt.MapFrom(src => src.Currency.JPY))
                ;
        }
    }
}
