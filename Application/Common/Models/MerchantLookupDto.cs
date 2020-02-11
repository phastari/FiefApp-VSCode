using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.Persons;

namespace Application.Common.Models
{
    public class MerchantLookupDto : IMapFrom<Merchant> 
    {
        public string MerchantId { get; set; }
        public string Name { get; set; }
        public string PortId { get; set; }
        public string Status { get; set; }
        public int Skill { get; set; }
        public int Resources { get; set; }
        public int Loyalty { get; set; }
        public int Age { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Merchant, MerchantLookupDto>()
                .ForMember(d => d.MerchantId, opt => opt.MapFrom(s => s.MerchantId.ToString()))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.PortId, opt => opt.MapFrom(s => s.Port.PortId))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status))
                .ForMember(d => d.Skill, opt => opt.MapFrom(s => s.Skill))
                .ForMember(d => d.Resources, opt => opt.MapFrom(s => s.Resources))
                .ForMember(d => d.Loyalty, opt => opt.MapFrom(s => s.Loyalty))
                .ForMember(d => d.Age, opt => opt.MapFrom(s => s.Age));
        }
    }
}