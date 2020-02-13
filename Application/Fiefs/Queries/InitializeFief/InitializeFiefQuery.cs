using MediatR;

namespace Application.Fiefs.Queries.InitializeFief
{
    public class InitializeFiefQuery : IRequest<InitializeFiefVm>
    {
        public string GameSessionId { get; set; }
    }
}