using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.Industries;

namespace Application.Common.Models
{
    public class IndustryLookupDto : IMapFrom<Industry> 
    {
        public string IndustryId { get; set; }
        public string Name { get; set; }
        public string IndustryType { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Industry, IndustryLookupDto>()
                .IncludeAllDerived()
                .ForMember(d => d.IndustryId, opt => opt.MapFrom(s => s.IndustryId.ToString()))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.IndustryType, opt => opt.MapFrom(s => s.IndustryType));
        }
    }
}