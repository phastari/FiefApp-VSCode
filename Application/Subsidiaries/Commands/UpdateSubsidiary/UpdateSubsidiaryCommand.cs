using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.Industries;
using MediatR;

namespace Application.Subsidiaries.Commands.UpdateSubsidiary
{
    public class UpdateSubsidiaryCommand : IRequest<bool>
    {
        public string IndustryId { get; set; }

#nullable enable
        public int? Quality { get; set; }
        public int? DevelopmentLevel { get; set; }
        public int? Silver { get; set; }
        public int? Base { get; set; }
        public int? Luxury { get; set; }
        public int? DaysworkThisYear { get; set; }
        public bool? IsBeingDeveloped { get; set; }
        public double? SpringModifier { get; set; }
        public double? SummerModifier { get; set; }
        public double? FallModifier { get; set; }
        public double? WinterModifier { get; set; }
#nullable disable

        public class Handler : IRequestHandler<UpdateSubsidiaryCommand, bool>
        {
            private readonly IFiefAppDbContext _context;
            private readonly string _user;
            private readonly IMediator _mediator;

            public Handler(IMediator mediator, ICurrentUserService currentUser, IFiefAppDbContext context)
            {
                _mediator = mediator;
                _user = currentUser.GetCurrentUsername();
                _context = context;
            }

            public async Task<bool> Handle(UpdateSubsidiaryCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.IndustryId, out Guid id))
                {
                    var subsidiary = (Subsidiary)await _context.Industries.FindAsync(id);

                    if (subsidiary == null)
                    {
                        throw new CustomException($"UpdateSubsidiaryCommand >> Could not find Subsidiary({id}).");
                    }

                    var fief = await _context.Fiefs.FindAsync(subsidiary.Fief.FiefId);

                    if (fief == null)
                    {
                        throw new CustomException($"UpdateSubsidiaryCommand >> Could not find Fief({subsidiary.Fief.FiefId}).");
                    }

                        if (request.Quality != subsidiary.Quality && request.Quality != null)
                        {
                            subsidiary.Quality = (int)request.Quality;
                        }

                        if (request.DevelopmentLevel != subsidiary.DevelopmentLevel && request.DevelopmentLevel != null)
                        {
                            subsidiary.DevelopmentLevel = (int)request.DevelopmentLevel;
                        }

                        if (request.Silver != subsidiary.Silver && request.Silver != null)
                        {
                            subsidiary.Silver = (int)request.Silver;
                        }

                        if (request.Base != subsidiary.Base && request.Base != null)
                        {
                            subsidiary.Base = (int)request.Base;
                        }

                        if (request.Luxury != subsidiary.Luxury && request.Luxury != null)
                        {
                            subsidiary.Luxury = (int)request.Luxury;
                        }

                        if (request.DaysworkThisYear != subsidiary.DaysworkThisYear && request.DaysworkThisYear != null)
                        {
                            subsidiary.DaysworkThisYear = (int)request.DaysworkThisYear;
                        }

                        if (request.IsBeingDeveloped != subsidiary.IsBeingDeveloped && request.IsBeingDeveloped != null)
                        {
                            subsidiary.IsBeingDeveloped = (bool)request.IsBeingDeveloped;
                        }

                        if (request.SpringModifier != subsidiary.SpringModifier && request.SpringModifier != null)
                        {
                            subsidiary.SpringModifier = (double)request.SpringModifier;
                        }

                        if (request.SummerModifier != subsidiary.SummerModifier && request.SummerModifier != null)
                        {
                            subsidiary.SummerModifier = (double)request.SummerModifier;
                        }

                        if (request.FallModifier != subsidiary.FallModifier && request.FallModifier != null)
                        {
                            subsidiary.FallModifier = (double)request.FallModifier;
                        }

                        if (request.WinterModifier != subsidiary.WinterModifier && request.WinterModifier != null)
                        {
                            subsidiary.WinterModifier = (double)request.WinterModifier;
                        }

                        await _context.SaveChangesAsync(cancellationToken);
                        return true;

                    throw new CustomException($"UpdateSubsidiaryCommand >> Unauthorized!");
                }

                throw new CustomException($"UpdateSubsidiaryCommand >> Could not parse IndustryId({request.IndustryId}).");
            }
        }
    }
}