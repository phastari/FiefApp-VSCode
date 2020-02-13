using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.Industries;

namespace Application.Common.Models
{
    public class FellingLookupDto : IMapFrom<Felling> 
    {
        public int AmountLandclearing { get; set; }
        public int AmountLandclearingOfFelling { get; set; }
        public int AmountFelling { get; set; }
        public int AmountClearUseless { get; set; }
        public bool IsBeingDeveloped { get; set; }
    #nullable enable
        public string? DevelopmentId { get; set; }
    #nullable disable

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Felling, FellingLookupDto>()
                .ForMember(d => d.AmountLandclearing, opt => opt.MapFrom(s => s.AmountLandclearing))
                .ForMember(d => d.AmountLandclearingOfFelling, opt => opt.MapFrom(s => s.AmountLandclearingOfFelling))
                .ForMember(d => d.AmountFelling, opt => opt.MapFrom(s => s.AmountFelling))
                .ForMember(d => d.AmountClearUseless, opt => opt.MapFrom(s => s.AmountClearUseless))
                .ForMember(d => d.IsBeingDeveloped, opt => opt.MapFrom(s => s.IsBeingDeveloped))
                .ForMember(d => d.DevelopmentId, opt => opt.MapFrom(s => s.DevelopmentId.ToString()));
        }
    }
}