using System.Collections.Generic;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Models
{
    public class RoadLookupDto : IMapFrom<Road> 
    {
        public string RoadId { get; set; }
        public List<SoldierLookupDto> Soldiers { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int UpgradeBaseCost { get; set; }
        public int UpgradeStoneCost { get; set; }
        public double ModificationFactor { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Road, RoadLookupDto>()
                .ForMember(d => d.RoadId, opt => opt.MapFrom(s => s.RoadId.ToString()))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.RoadType.Type))
                .ForMember(d => d.UpgradeBaseCost, opt => opt.MapFrom(s => s.RoadType.UpgradeBaseCost))
                .ForMember(d => d.UpgradeStoneCost, opt => opt.MapFrom(s => s.RoadType.UpgradeStoneCost))
                .ForMember(d => d.ModificationFactor, opt => opt.MapFrom(s => s.RoadType.ModificationFactor));
        }
    }
}