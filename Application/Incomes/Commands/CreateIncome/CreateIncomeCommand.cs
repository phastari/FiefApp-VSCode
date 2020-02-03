using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Domain.Entities.Industries;
using MediatR;

namespace Application.Incomes.Commands.CreateIncome
{
    public class CreateIncomeCommand : IRequest<bool>
    {
        public string FiefId { get; set; }

        public bool NeedSteward { get; set; }
        public bool ShowInIncomes { get; set; }
        public int Silver { get; set; }
        public int Base { get; set; }
        public int Luxury { get; set; }
        public int Wood { get; set; }
        public double SpringModifier { get; set; }
        public double SummerModifier { get; set; }
        public double FallModifier { get; set; }
        public double WinterModifier { get; set; }


        public class Handler : IRequestHandler<CreateIncomeCommand, bool>
        {
            private readonly IFiefAppDbContext _context;
            private readonly IUserManagerService _userManager;
            private readonly IMediator _mediator;
            private readonly string _user;

            public Handler(IFiefAppDbContext context, IMediator mediator, IUserManagerService userManager, ICurrentUserService currentUser)
            {
                _context = context;
                _mediator = mediator;
                _userManager = userManager;
                _user = currentUser.GetCurrentUsername();
            }

            public async Task<bool> Handle(CreateIncomeCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.FiefId, out Guid id))
                {
                    var helper = new GetUserNameFromFiefId(_context);
                    if (await helper.Check(id, _user))
                    {
                        var income = new Income
                        {
                            NeedSteward = request.NeedSteward,
                            ShowInIncomes = request.ShowInIncomes,
                            IsBeingDeveloped = false,
                            Silver = request.Silver,
                            Base = request.Base,
                            Luxury = request.Luxury,
                            Wood = request.Wood,
                            SpringModifier = request.SpringModifier,
                            SummerModifier = request.SummerModifier,
                            FallModifier = request.FallModifier,
                            WinterModifier = request.WinterModifier
                        };

                        var fief = await _context.Fiefs.FindAsync(id);
                        fief.Industries.Add(income);

                        await _context.SaveChangesAsync(cancellationToken);
                    }

                    throw new CustomException($"CreateIncomeCommand >> Unauthorized!");
                }

                throw new CustomException($"CreateIncomeCommand >> Could not parse FiefId({request.FiefId}).");
            }
        }
    }
}