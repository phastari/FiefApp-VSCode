using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Models
{
    public class FiefLookupDto : IMapFrom<Fief>
    {
        public string FiefId { get; set; }
        public string Name { get; set; }
        public int Acres { get; set; }
        public int FarmlandAcres { get; set; }
        public int PastureAcres { get; set; }
        public int WoodlandAcres { get; set; }
        public int FellingAcres { get; set; }
        public int UnusableAcres { get; set; }
        public int AnimalHusbandryQuality { get; set; }
        public int AgriculturalQuality { get; set; }
        public int FishingQuality { get; set; }
        public int OreQuality { get; set; }
        public int AnimalHusbandryDevelopmentLevel { get; set; }
        public int AgriculturalDevelopmentLevel { get; set; }
        public int FishingDevelopmentLevel { get; set; }
        public int WoodlandDevelopmentLevel { get; set; }
        public int OreDevelopmentLevel { get; set; }
        public int EducationDevelopmentLevel { get; set; }
        public int HealthcareDevelopmentLevel { get; set; }
        public int MilitaryDevelopmentLevel { get; set; }
        public int SeafaringDevelopmentLevel { get; set; }
        public MarketLookupDto Market { get; set; }
        public RoadLookupDto Road { get; set; }
        public LivingconditionLookupDto Livingcondition { get; set; }
        public InheritanceLookupDto Inheritance { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Fief, FiefLookupDto>()
                .ForMember(d => d.FiefId, opt => opt.MapFrom(s => s.FiefId.ToString()))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Acres, opt => opt.MapFrom(s => s.Acres))
                .ForMember(d => d.FarmlandAcres, opt => opt.MapFrom(s => s.FarmlandAcres))
                .ForMember(d => d.PastureAcres, opt => opt.MapFrom(s => s.PastureAcres))
                .ForMember(d => d.WoodlandAcres, opt => opt.MapFrom(s => s.WoodlandAcres))
                .ForMember(d => d.FellingAcres, opt => opt.MapFrom(s => s.FellingAcres))
                .ForMember(d => d.UnusableAcres, opt => opt.MapFrom(s => s.UnusableAcres))
                .ForMember(d => d.AnimalHusbandryQuality, opt => opt.MapFrom(s => s.AnimalHusbandryQuality))
                .ForMember(d => d.AgriculturalQuality, opt => opt.MapFrom(s => s.AgriculturalQuality))
                .ForMember(d => d.FishingQuality, opt => opt.MapFrom(s => s.FishingQuality))
                .ForMember(d => d.OreQuality, opt => opt.MapFrom(s => s.OreQuality))
                .ForMember(d => d.AnimalHusbandryDevelopmentLevel, opt => opt.MapFrom(s => s.AnimalHusbandryDevelopmentLevel))
                .ForMember(d => d.AgriculturalDevelopmentLevel, opt => opt.MapFrom(s => s.AgriculturalDevelopmentLevel))
                .ForMember(d => d.FishingDevelopmentLevel, opt => opt.MapFrom(s => s.FishingDevelopmentLevel))
                .ForMember(d => d.WoodlandDevelopmentLevel, opt => opt.MapFrom(s => s.WoodlandDevelopmentLevel))
                .ForMember(d => d.OreDevelopmentLevel, opt => opt.MapFrom(s => s.OreDevelopmentLevel))
                .ForMember(d => d.EducationDevelopmentLevel, opt => opt.MapFrom(s => s.EducationDevelopmentLevel))
                .ForMember(d => d.HealthcareDevelopmentLevel, opt => opt.MapFrom(s => s.HealthcareDevelopmentLevel))
                .ForMember(d => d.MilitaryDevelopmentLevel, opt => opt.MapFrom(s => s.MilitaryDevelopmentLevel))
                .ForMember(d => d.SeafaringDevelopmentLevel, opt => opt.MapFrom(s => s.SeafaringDevelopmentLevel));
        }
    }
}