using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.Industries;

namespace Application.Common.Models
{
    public class SubsidiaryLookupDto : IMapFrom<Subsidiary> 
    {
        public int Quality { get; set; }
        public int DevelopmentLevel { get; set; }
        public int Silver { get; set; }
        public int Base { get; set; }
        public int Luxury { get; set; }
        public int DaysworkThisYear { get; set; }
        public bool IsBeingDeveloped { get; set; }
    #nullable enable
        public string? DevelopmentId { get; set; }
    #nullable disable
        public string Type { get; set; }
        public string DisplayName { get; set; }
        public double IncomeFactor { get; set; }
        public double IncomeInSilver { get; set; }
        public double IncomeInBase { get; set; }
        public double IncomeInLuxury { get; set; }
        public double SpringModification { get; set; }
        public double SummerModification { get; set; }
        public double FallModification { get; set; }
        public double WinterModification { get; set; }
        public int DaysworkBuild { get; set; }
        public int DaysworkUpkeep { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Subsidiary, SubsidiaryLookupDto>()
                .ForMember(d => d.Quality, opt => opt.MapFrom(s => s.Quality))
                .ForMember(d => d.DevelopmentLevel, opt => opt.MapFrom(s => s.DevelopmentLevel))
                .ForMember(d => d.Silver, opt => opt.MapFrom(s => s.Silver))
                .ForMember(d => d.Base, opt => opt.MapFrom(s => s.Base))
                .ForMember(d => d.Luxury, opt => opt.MapFrom(s => s.Luxury))
                .ForMember(d => d.DaysworkThisYear, opt => opt.MapFrom(s => s.DaysworkThisYear))
                .ForMember(d => d.IsBeingDeveloped, opt => opt.MapFrom(s => s.IsBeingDeveloped))
                .ForMember(d => d.DevelopmentId, opt => opt.MapFrom(s => s.DevelopmentId))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.SubsidiaryType.Type))
                .ForMember(d => d.DisplayName, opt => opt.MapFrom(s => s.SubsidiaryType.DisplayName))
                .ForMember(d => d.IncomeFactor, opt => opt.MapFrom(s => s.SubsidiaryType.IncomeFactor))
                .ForMember(d => d.IncomeInSilver, opt => opt.MapFrom(s => s.SubsidiaryType.IncomeInSilver))
                .ForMember(d => d.IncomeInBase, opt => opt.MapFrom(s => s.SubsidiaryType.IncomeInBase))
                .ForMember(d => d.IncomeInLuxury, opt => opt.MapFrom(s => s.SubsidiaryType.IncomeInLuxury))
                .ForMember(d => d.SpringModification, opt => opt.MapFrom(s => s.SubsidiaryType.SpringModification))
                .ForMember(d => d.SummerModification, opt => opt.MapFrom(s => s.SubsidiaryType.SummerModification))
                .ForMember(d => d.FallModification, opt => opt.MapFrom(s => s.SubsidiaryType.FallModification))
                .ForMember(d => d.WinterModification, opt => opt.MapFrom(s => s.SubsidiaryType.WinterModification))
                .ForMember(d => d.DaysworkBuild, opt => opt.MapFrom(s => s.SubsidiaryType.DaysworkBuild))
                .ForMember(d => d.DaysworkUpkeep, opt => opt.MapFrom(s => s.SubsidiaryType.DaysworkUpkeep));
        }
    }
}