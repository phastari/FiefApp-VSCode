using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Livingconditions.Commands.UpdateLivingcondition
{
    public class UpdateLivingconditionCommand : IRequest<bool>
    {
        public string FiefId { get; set; }
        public string newType { get; set; }
    }

    public class UpdateLivingconditionCommandHandler : IRequestHandler<UpdateLivingconditionCommand, bool>
    {
        private readonly IFiefAppDbContext _context;

        public UpdateLivingconditionCommandHandler(IFiefAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateLivingconditionCommand request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.FiefId, out Guid id))
            {
                var fief = await _context.Fiefs.FindAsync(id);

                if (fief != null)
                {
                    var livingconditionType = await _context.LivingconditionTypes.Where(o => o.Type == request.newType).FirstAsync();
                    fief.Livingcondition.LivingconditionType = livingconditionType;
                    fief.Livingcondition.LivingconditionTypeId = livingconditionType.LivingconditionTypeId;

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