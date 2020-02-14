using System;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Models
{
    public class GameSessionLookupDto : IMapFrom<GameSession>
    {
        public Guid GameSessionId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUsed { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GameSession, GameSessionLookupDto>()
                .ForMember(d => d.GameSessionId, opt => opt.MapFrom(s => s.GameSessionId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Created, opt => opt.MapFrom(s => s.Created))
                .ForMember(d => d.LastUsed, opt => opt.MapFrom(s => s.LastUsed));
        }
    }
}