using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Roads.Commands.UpdateRoad
{
    public class UpdateRoadCommand : IRequest<bool>
    {
        public string FiefId { get; set; }
        public string newRoad { get; set; }
    }

    public class UpdateRoadCommandHandler : IRequestHandler<UpdateRoadCommand, bool>
    {
        private readonly IFiefAppDbContext _context;
        private readonly string _currentUser;

        public UpdateRoadCommandHandler(IFiefAppDbContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser.GetCurrentUsername();
        }

        public async Task<bool> Handle(UpdateRoadCommand request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.FiefId, out Guid id))
            {
                var fief = await _context.Fiefs.FindAsync(id);

                if (fief != null)
                {
                    var roadType = await _context.RoadTypes.Where(o => o.Type == request.newRoad).FirstAsync();
                    fief.Road.RoadType = roadType;
                    fief.Road.RoadTypeId = roadType.RoadTypeId;

                    await _context.SaveChangesAsync(cancellationToken);

                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
    }
}