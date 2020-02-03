using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Villages.Commands.UpdateVillage
{
    public class UpdateVillageCommand : IRequest<bool>
    {
        public string VillageId { get; set; }
#nullable enable
        public string? Name { get; set; }
        public int? Serfdoms { get; set; }
        public int? Farmers { get; set; }
        public int? Burgess { get; set; }
        public int? Boatbuilders { get; set; }
        public int? Tanners { get; set; }
        public int? Millers { get; set; }
        public int? Furriers { get; set; }
        public int? Tailors { get; set; }
        public int? Blacksmiths { get; set; }
        public int? Carpenters { get; set; }
        public int? Innkeepers { get; set; }
#nullable disable

        public class Handler : IRequestHandler<UpdateVillageCommand, bool>
        {
            private readonly IFiefAppDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IFiefAppDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<bool> Handle(UpdateVillageCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.VillageId, out Guid id))
                {
                    var village = await _context.Villages.FindAsync(id);

                    if (village.Name != request.Name && request.Name != null)
                    {
                        village.Name = request.Name;
                    }

                    if (village.Serfdoms != request.Serfdoms && request.Serfdoms != null)
                    {
                        village.Serfdoms = (int)request.Serfdoms;
                    }

                    if (village.Farmers != request.Farmers && request.Farmers != null)
                    {
                        village.Farmers = (int)request.Farmers;
                    }

                    if (village.Burgess != request.Burgess && request.Burgess != null)
                    {
                        village.Burgess = (int)request.Burgess;
                    }

                    if (village.Boatbuilders != request.Boatbuilders && request.Boatbuilders != null)
                    {
                        village.Boatbuilders = (int)request.Boatbuilders;
                    }

                    if (village.Tanners != request.Tanners && request.Tanners != null)
                    {
                        village.Tanners = (int)request.Tanners;
                    }

                    if (village.Millers != request.Millers && request.Millers != null)
                    {
                        village.Millers = (int)request.Millers;
                    }

                    if (village.Furriers != request.Furriers && request.Furriers != null)
                    {
                        village.Furriers = (int)request.Furriers;
                    }

                    if (village.Tailors != request.Tailors && request.Tailors != null)
                    {
                        village.Tailors = (int)request.Tailors;
                    }

                    if (village.Blacksmiths != request.Blacksmiths && request.Blacksmiths != null)
                    {
                        village.Blacksmiths = (int)request.Blacksmiths;
                    }

                    if (village.Carpenters != request.Carpenters && request.Carpenters != null)
                    {
                        village.Carpenters = (int)request.Carpenters;
                    }

                    if (village.Innkeepers != request.Innkeepers && request.Innkeepers != null)
                    {
                        village.Innkeepers = (int)request.Innkeepers;
                    }

                    await _context.SaveChangesAsync(cancellationToken);

                    return true;
                }

                return false;
            }
        }
    }
}