using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.Industries;

namespace Application.Common.Models
{
    public class IncomeLookupDto : IMapFrom<Income> 
    {
        public bool NeedSteward { get; set; }
        public bool ShowInIncomes { get; set; }
        public bool IsBeingDeveloped { get; set; }
        public int Silver { get; set; }
        public int Base { get; set; }
        public int Luxury { get; set; }
        public int Wood { get; set; }
        public double SpringModifier { get; set; }
        public double SummerModifier { get; set; }
        public double FallModifier { get; set; }
        public double WinterModifier { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Income, IncomeLookupDto>()
                .ForMember(d => d.NeedSteward, opt => opt.MapFrom(s => s.NeedSteward))
                .ForMember(d => d.ShowInIncomes, opt => opt.MapFrom(s => s.ShowInIncomes))
                .ForMember(d => d.IsBeingDeveloped, opt => opt.MapFrom(s => s.IsBeingDeveloped))
                .ForMember(d => d.Silver, opt => opt.MapFrom(s => s.Silver))
                .ForMember(d => d.Base, opt => opt.MapFrom(s => s.Base))
                .ForMember(d => d.Luxury, opt => opt.MapFrom(s => s.Luxury))
                .ForMember(d => d.Wood, opt => opt.MapFrom(s => s.Wood))
                .ForMember(d => d.SpringModifier, opt => opt.MapFrom(s => s.SpringModifier))
                .ForMember(d => d.SummerModifier, opt => opt.MapFrom(s => s.SummerModifier))
                .ForMember(d => d.FallModifier, opt => opt.MapFrom(s => s.FallModifier))
                .ForMember(d => d.WinterModifier, opt => opt.MapFrom(s => s.WinterModifier));
        }
    }
}