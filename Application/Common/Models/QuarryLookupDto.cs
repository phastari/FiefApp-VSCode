using System.Collections.Generic;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.Industries;

namespace Application.Common.Models
{
    public class QuarryLookupDto : IMapFrom<Quarry> 
    {
        public List<SoldierLookupDto> Soldiers { get; set; }
        public string Type { get; set; }
        public int Stone { get; set; }
        public bool IsFirstYear { get; set; }
        public int YearsLeft { get; set; }
        public int Guards { get; set; }
        public bool IsBeingDeveloped { get; set; }
        public string DisplayName { get; set; }
        public int Crime { get; set; }
        public int PopulationModifier { get; set; }
    #nullable enable
        public string? DevelopmentId { get; set; }
    #nullable disable

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Quarry, QuarryLookupDto>()
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(d => d.Stone, opt => opt.MapFrom(s => s.Stone))
                .ForMember(d => d.IsFirstYear, opt => opt.MapFrom(s => s.IsFirstYear))
                .ForMember(d => d.YearsLeft, opt => opt.MapFrom(s => s.YearsLeft))
                .ForMember(d => d.Guards, opt => opt.MapFrom(s => s.Guards))
                .ForMember(d => d.IsBeingDeveloped, opt => opt.MapFrom(s => s.IsBeingDeveloped))
                .ForMember(d => d.DevelopmentId, opt => opt.MapFrom(s => s.DevelopmentId.ToString()))
                .ForMember(d => d.DisplayName, opt => opt.MapFrom(s => s.QuarryType.DisplayName))
                .ForMember(d => d.Crime, opt => opt.MapFrom(s => s.QuarryType.Crime))
                .ForMember(d => d.PopulationModifier, opt => opt.MapFrom(s => s.QuarryType.PopulationModifier));
        }
    }
}