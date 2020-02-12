using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Models
{
    public class LivingconditionLookupDto : IMapFrom<Livingcondition> 
    {
        public string LivingconditionId { get; set; }
        public string Type { get; set; }
        public int LuxuryCost { get; set; }
        public int BaseCost { get; set; }
        public int FocusGain { get; set; }
        public string Description { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Livingcondition, LivingconditionLookupDto>()
                .ForMember(d => d.LivingconditionId, opt => opt.MapFrom(s => s.LivingconditionId.ToString()))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.LivingconditionType.Type))
                .ForMember(d => d.LuxuryCost, opt => opt.MapFrom(s => s.LivingconditionType.LuxuryCost))
                .ForMember(d => d.BaseCost, opt => opt.MapFrom(s => s.LivingconditionType.BaseCost))
                .ForMember(d => d.FocusGain, opt => opt.MapFrom(s => s.LivingconditionType.FocusGain))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.LivingconditionType.Description));
        }
    }
}