using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Fiefs.Commands.UpdateFief
{
    public class UpdateFiefCommand : IRequest<bool>
    {
        public string FiefId { get; set; }
#nullable enable
        public string? StewardId { get; set; }
        public string? Name { get; set; }
        public int? Acres { get; set; }
        public int? FarmlandAcres { get; set; }
        public int? PastureAcres { get; set; }
        public int? WoodlandAcres { get; set; }
        public int? UnusableAcres { get; set; }
        public int? AnimalHusbandryQuality { get; set; }
        public int? AgriculturalQuality { get; set; }
        public int? FishingQuality { get; set; }
        public int? OreQuality { get; set; }
        public int? AnimalHusbandryDevelopmentLevel { get; set; }
        public int? AgriculturalDevelopmentLevel { get; set; }
        public int? FishingDevelopmentLevel { get; set; }
        public int? WoodlandDevelopmentLevel { get; set; }
        public int? OreDevelopmentLevel { get; set; }
        public int? EducationDevelopmentLevel { get; set; }
        public int? HealthcareDevelopmentLevel { get; set; }
        public int? MilitaryDevelopmentLevel { get; set; }
#nullable disable

        public class Handler : IRequestHandler<UpdateFiefCommand, bool>
        {
            private readonly IFiefAppDbContext _context;
            private readonly IMediator _mediator;
            private readonly string _user;

            public Handler(IFiefAppDbContext context, IMediator mediator, ICurrentUserService userService)
            {
                _context = context;
                _mediator = mediator;
                _user = userService.GetCurrentUsername();
            }

            public async Task<bool> Handle(UpdateFiefCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.FiefId, out Guid id))
                {
                    var fief = await _context.Fiefs.FindAsync(id);

                    if (fief != null)
                    {
                        if (fief.Name != request.Name && request.Name != null)
                        {
                            fief.Name = request.Name;
                        }

                        if (fief.Acres != request.Acres && request.Acres != null)
                        {
                            fief.Acres = (int)request.Acres;
                        }

                        if (fief.FarmlandAcres != request.FarmlandAcres && request.FarmlandAcres != null)
                        {
                            fief.FarmlandAcres = (int)request.FarmlandAcres;
                        }

                        if (fief.PastureAcres != request.PastureAcres && request.PastureAcres != null)
                        {
                            fief.PastureAcres = (int)request.PastureAcres;
                        }

                        if (fief.WoodlandAcres != request.WoodlandAcres && request.WoodlandAcres != null)
                        {
                            fief.WoodlandAcres = (int)request.WoodlandAcres;
                        }

                        if (fief.UnusableAcres != request.UnusableAcres && request.UnusableAcres != null)
                        {
                            fief.UnusableAcres = (int)request.UnusableAcres;
                        }

                        if (fief.AnimalHusbandryQuality != request.AnimalHusbandryQuality && request.AnimalHusbandryQuality != null)
                        {
                            fief.AnimalHusbandryQuality = (int)request.AnimalHusbandryQuality;
                        }

                        if (fief.AgriculturalQuality != request.AgriculturalQuality && request.AgriculturalQuality != null)
                        {
                            fief.AgriculturalQuality = (int)request.AgriculturalQuality;
                        }

                        if (fief.FishingQuality != request.FishingQuality && request.FishingQuality != null)
                        {
                            fief.FishingQuality = (int)request.FishingQuality;
                        }

                        if (fief.OreQuality != request.OreQuality && request.OreQuality != null)
                        {
                            fief.OreQuality = (int)request.OreQuality;
                        }

                        if (fief.AnimalHusbandryDevelopmentLevel != request.AnimalHusbandryDevelopmentLevel && request.AnimalHusbandryDevelopmentLevel != null)
                        {
                            fief.AnimalHusbandryDevelopmentLevel = (int)request.AnimalHusbandryDevelopmentLevel;
                        }

                        if (fief.AgriculturalDevelopmentLevel != request.AgriculturalDevelopmentLevel && request.AgriculturalDevelopmentLevel != null)
                        {
                            fief.AgriculturalDevelopmentLevel = (int)request.AgriculturalDevelopmentLevel;
                        }

                        if (fief.FishingDevelopmentLevel != request.FishingDevelopmentLevel && request.FishingDevelopmentLevel != null)
                        {
                            fief.FishingDevelopmentLevel = (int)request.FishingDevelopmentLevel;
                        }

                        if (fief.WoodlandDevelopmentLevel != request.WoodlandDevelopmentLevel && request.WoodlandDevelopmentLevel != null)
                        {
                            fief.WoodlandDevelopmentLevel = (int)request.WoodlandDevelopmentLevel;
                        }

                        if (fief.OreDevelopmentLevel != request.OreDevelopmentLevel && request.OreDevelopmentLevel != null)
                        {
                            fief.OreDevelopmentLevel = (int)request.OreDevelopmentLevel;
                        }

                        if (fief.EducationDevelopmentLevel != request.EducationDevelopmentLevel && request.EducationDevelopmentLevel != null)
                        {
                            fief.EducationDevelopmentLevel = (int)request.EducationDevelopmentLevel;
                        }

                        if (fief.HealthcareDevelopmentLevel != request.HealthcareDevelopmentLevel && request.HealthcareDevelopmentLevel != null)
                        {
                            fief.HealthcareDevelopmentLevel = (int)request.HealthcareDevelopmentLevel;
                        }

                        if (fief.MilitaryDevelopmentLevel != request.MilitaryDevelopmentLevel && request.MilitaryDevelopmentLevel != null)
                        {
                            fief.MilitaryDevelopmentLevel = (int)request.MilitaryDevelopmentLevel;
                        }

                        var steward = await _context.Stewards.Where(o => o.StewardId.ToString() == request.StewardId).FirstAsync();

                        await _context.SaveChangesAsync(cancellationToken);

                        return true;
                    }

                    return false;
                }

                return false;
            }
        }
    }
}