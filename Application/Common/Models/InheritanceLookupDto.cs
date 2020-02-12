using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Models
{
    public class InheritanceLookupDto : IMapFrom<Inheritance> 
    {
        public string InheritanceId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Inheritance, InheritanceLookupDto>()
                .ForMember(d => d.InheritanceId, opt => opt.MapFrom(s => s.InheritanceId.ToString()))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.InheritanceType.Type))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.InheritanceType.Description));
        }
    }
}