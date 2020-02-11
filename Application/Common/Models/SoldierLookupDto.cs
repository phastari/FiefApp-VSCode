using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.Persons;

namespace Application.Common.Models
{
    public class SoldierLookupDto : IMapFrom<Soldier> 
    {
        public string SoldierId { get; set; }
        public string Name { get; set; }
        public int Skill { get; set; }
        public int Resources { get; set; }
        public int Loyalty { get; set; }
        public int Age { get; set; }
        public string Type { get; set; }
        public string DisplayName { get; set; }
        public int SilverCost { get; set; }
        public int BaseCost { get; set; }
        public bool Accommodation { get; set; }
        public bool IsResident { get; set; }
        public int Amount { get; set; }
    #nullable enable
        public string? MerchantId { get; set; }
        public string? BoatId { get; set; }
        public string? MarketId { get; set; }
        public string? PortId { get; set; }
        public string? RoadId { get; set; }
        public string? MineId { get; set; }
        public string? QuarryId { get; set; }
    #nullable disable

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Soldier, SoldierLookupDto>()
                .ForMember(d => d.SoldierId, opt => opt.MapFrom(s => s.SoldierId.ToString()))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Skill, opt => opt.MapFrom(s => s.Skill))
                .ForMember(d => d.Resources, opt => opt.MapFrom(s => s.Resources))
                .ForMember(d => d.Loyalty, opt => opt.MapFrom(s => s.Loyalty))
                .ForMember(d => d.Age, opt => opt.MapFrom(s => s.Age))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.SoldierType.Type))
                .ForMember(d => d.DisplayName, opt => opt.MapFrom(s => s.SoldierType.DisplayName))
                .ForMember(d => d.SilverCost, opt => opt.MapFrom(s => s.SoldierType.SilverCost))
                .ForMember(d => d.BaseCost, opt => opt.MapFrom(s => s.SoldierType.BaseCost))
                .ForMember(d => d.Accommodation, opt => opt.MapFrom(s => s.SoldierType.Accommodation))
                .ForMember(d => d.IsResident, opt => opt.MapFrom(s => s.IsResident))
                .ForMember(d => d.Amount, opt => opt.MapFrom(s => s.Amount))
                .ForMember(d => d.MerchantId, opt => opt.MapFrom(s => s.Merchant.MerchantId))
                .ForMember(d => d.BoatId, opt => opt.MapFrom(s => s.Boat.BoatId))
                .ForMember(d => d.MarketId, opt => opt.MapFrom(s => s.Market.MarketId))
                .ForMember(d => d.PortId, opt => opt.MapFrom(s => s.Port.PortId))
                .ForMember(d => d.RoadId, opt => opt.MapFrom(s => s.Road.RoadId))
                .ForMember(d => d.MineId, opt => opt.MapFrom(s => s.Mine.IndustryId))
                .ForMember(d => d.QuarryId, opt => opt.MapFrom(s => s.Quarry.IndustryId));
        }
    }
}