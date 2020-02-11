using System.Collections.Generic;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Models
{
    public class MarketLookupDto : IMapFrom<Market> 
    {
        public string MarketId { get; set; }
        public string Name { get; set; }
        public int DevelopmentLevel { get; set; }
        public int Merchandise { get; set; }
        public int IncomeSilver { get; set; }
        public int IncomeBase { get; set; }
        public int Taxes { get; set; }
        public int Bailiffs { get; set; }
        public int Crime { get; set; }
        public bool IsBeingDeveloped { get; set; }
    #nullable enable
        public string? StewardId { get; set; }
    #nullable disable
        public List<MerchantLookupDto> Merchants { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Market, MarketLookupDto>()
                .ForMember(d => d.MarketId, opt => opt.MapFrom(s => s.MarketId.ToString()))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.DevelopmentLevel, opt => opt.MapFrom(s => s.DevelopmentLevel))
                .ForMember(d => d.Merchandise, opt => opt.MapFrom(s => s.Merchandise))
                .ForMember(d => d.IncomeSilver, opt => opt.MapFrom(s => s.IncomeSilver))
                .ForMember(d => d.IncomeBase, opt => opt.MapFrom(s => s.IncomeBase))
                .ForMember(d => d.Taxes, opt => opt.MapFrom(s => s.Taxes))
                .ForMember(d => d.Bailiffs, opt => opt.MapFrom(s => s.Bailiffs))
                .ForMember(d => d.Crime, opt => opt.MapFrom(s => s.Crime))
                .ForMember(d => d.IsBeingDeveloped, opt => opt.MapFrom(s => s.IsBeingDeveloped))
                .ForMember(d => d.StewardId, opt => opt.MapFrom(s => s.Assignment.Steward.StewardId.ToString()));
        }
    }
}