using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.Industries;

namespace Application.Common.Models
{
    public class TaxLookupDto : IMapFrom<Tax> 
    {
        public int NumberOfBailiffs { get; set; }
        public int Silver { get; set; }
        public int Base { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tax, TaxLookupDto>()
                .ForMember(d => d.NumberOfBailiffs, opt => opt.MapFrom(s => s.NumberOfBailiffs))
                .ForMember(d => d.Silver, opt => opt.MapFrom(s => s.Silver))
                .ForMember(d => d.Base, opt => opt.MapFrom(s => s.Base));
        }
    }
}