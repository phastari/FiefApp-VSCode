using System.Collections.Generic;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.Industries;

namespace Application.Common.Models
{
    public class MineLookupDto : IMapFrom<Mine> 
    {
        public List<SoldierLookupDto> Soldiers { get; set; }
        public string Type { get; set; }
        public int Silver { get; set; }
        public int Luxury { get; set; }
        public int Iron { get; set; }
        public int YearsLeft { get; set; }
        public int Guards { get; set; }
        public bool FirstYear { get; set; }
        public bool IsBeingDeveloped { get; set; }
        public string DisplayName { get; set; }
        public int SilverProduction { get; set; }
        public int IronProduction { get; set; }
        public int LuxuryProduction { get; set; }
        public int Crime { get; set; }
        public int PopulationModifier { get; set; }
    #nullable enable
        public string? DevelopmentId { get; set; }
    #nullable disable

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Mine, MineLookupDto>()
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(d => d.Silver, opt => opt.MapFrom(s => s.Silver))
                .ForMember(d => d.Luxury, opt => opt.MapFrom(s => s.Luxury))
                .ForMember(d => d.Iron, opt => opt.MapFrom(s => s.Iron))
                .ForMember(d => d.YearsLeft, opt => opt.MapFrom(s => s.YearsLeft))
                .ForMember(d => d.Guards, opt => opt.MapFrom(s => s.Guards))
                .ForMember(d => d.FirstYear, opt => opt.MapFrom(s => s.FirstYear))
                .ForMember(d => d.IsBeingDeveloped, opt => opt.MapFrom(s => s.IsBeingDeveloped))
                .ForMember(d => d.DevelopmentId, opt => opt.MapFrom(s => s.DevelopmentId.ToString()))
                .ForMember(d => d.DisplayName, opt => opt.MapFrom(s => s.MineType.DisplayName))
                .ForMember(d => d.SilverProduction, opt => opt.MapFrom(s => s.MineType.SilverProduction))
                .ForMember(d => d.IronProduction, opt => opt.MapFrom(s => s.MineType.IronProduction))
                .ForMember(d => d.LuxuryProduction, opt => opt.MapFrom(s => s.MineType.LuxuryProduction))
                .ForMember(d => d.Crime, opt => opt.MapFrom(s => s.MineType.Crime))
                .ForMember(d => d.PopulationModifier, opt => opt.MapFrom(s => s.MineType.PopulationModifier));
        }
    }
}