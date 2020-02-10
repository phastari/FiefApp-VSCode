using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.Industries;
using MediatR;

namespace Application.Incomes.Commands.UpdateIncome
{
    public class UpdateIncomeCommand : IRequest<bool>
    {
        public string IndustryId { get; set; }

#nullable enable
        public bool? NeedSteward { get; set; }
        public bool? ShowInIncomes { get; set; }
        public bool? IsBeingDeveloped { get; set; }
        public int? Silver { get; set; }
        public int? Base { get; set; }
        public int? Luxury { get; set; }
        public int? Wood { get; set; }
        public double? SpringModifier { get; set; }
        public double? SummerModifier { get; set; }
        public double? FallModifier { get; set; }
        public double? WinterModifier { get; set; }
#nullable disable

        public class Handler : IRequestHandler<UpdateIncomeCommand, bool>
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

            public async Task<bool> Handle(UpdateIncomeCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.IndustryId, out Guid id))
                {
                    var income = (Income)await _context.Industries.FindAsync(id);
                    var fief = await _context.Fiefs.FindAsync(income.Fief.FiefId);

                    if (fief.GameSession.User == _user)
                    {
                        if (request.NeedSteward != income.NeedSteward && request.NeedSteward != null)
                        {
                            income.NeedSteward = (bool)request.NeedSteward;
                        }

                        if (request.ShowInIncomes != income.ShowInIncomes && request.ShowInIncomes != null)
                        {
                            income.ShowInIncomes = (bool)request.ShowInIncomes;
                        }

                        if (request.IsBeingDeveloped != income.IsBeingDeveloped && request.IsBeingDeveloped != null)
                        {
                            income.IsBeingDeveloped = (bool)request.IsBeingDeveloped;
                        }

                        if (request.Silver != income.Silver && request.Silver != null)
                        {
                            income.Silver = (int)request.Silver;
                        }

                        if (request.Base != income.Base && request.Base != null)
                        {
                            income.Base = (int)request.Base;
                        }

                        if (request.Luxury != income.Luxury && request.Luxury != null)
                        {
                            income.Luxury = (int)request.Luxury;
                        }

                        if (request.Wood != income.Wood && request.Wood != null)
                        {
                            income.Wood = (int)request.Wood;
                        }

                        if (request.SpringModifier != income.SpringModifier && request.SpringModifier != null)
                        {
                            income.SpringModifier = (double)request.SpringModifier;
                        }

                        if (request.SummerModifier != income.SummerModifier && request.SummerModifier != null)
                        {
                            income.SummerModifier = (double)request.SummerModifier;
                        }

                        if (request.FallModifier != income.FallModifier && request.FallModifier != null)
                        {
                            income.FallModifier = (double)request.FallModifier;
                        }

                        if (request.WinterModifier != income.WinterModifier && request.WinterModifier != null)
                        {
                            income.WinterModifier = (double)request.WinterModifier;
                        }

                        await _context.SaveChangesAsync(cancellationToken);
                        return true;
                    }

                    throw new CustomException($"UpdateIncomeCommand >> Unauthorized!");
                }

                throw new CustomException($"UpdateIncomeCommand >> Could not parse IndustryId({request.IndustryId}).");
            }
        }
    }
}