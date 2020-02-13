using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.Persons;

namespace Application.Common.Models
{
    public class StewardLookupDto : IMapFrom<Steward> 
    {
        public string StewardId { get; set; }
        public string Name { get; set; }
        public int Skill { get; set; }
        public int Resources { get; set; }
        public int Loyalty { get; set; }
        public int Age { get; set; }
    #nullable enable
        public string? IndustryId { get; set; }
        public string? DevelopmentId { get; set; }
        public string? FiefId { get; set; }
        public string? MarketId { get; set; }
        public string? PortId { get; set; }
        public string? ShipyardId { get; set; }
    #nullable disable

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Steward, StewardLookupDto>()
                .ForMember(d => d.StewardId, opt => opt.MapFrom(s => s.StewardId.ToString()))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Skill, opt => opt.MapFrom(s => s.Skill))
                .ForMember(d => d.Resources, opt => opt.MapFrom(s => s.Resources))
                .ForMember(d => d.Loyalty, opt => opt.MapFrom(s => s.Loyalty))
                .ForMember(d => d.Age, opt => opt.MapFrom(s => s.Age))
                .ForMember(d => d.IndustryId, opt => opt.MapFrom(s => s.Assignment.Industry.IndustryId))
                .ForMember(d => d.DevelopmentId, opt => opt.MapFrom(s => s.Assignment.Development.DevelopmentId))
                .ForMember(d => d.FiefId, opt => opt.MapFrom(s => s.Assignment.Fief.FiefId))
                .ForMember(d => d.MarketId, opt => opt.MapFrom(s => s.Assignment.Market.MarketId))
                .ForMember(d => d.PortId, opt => opt.MapFrom(s => s.Assignment.Port.PortId))
                .ForMember(d => d.ShipyardId, opt => opt.MapFrom(s => s.Assignment.Shipyard.ShipyardId));
        }
    }
}