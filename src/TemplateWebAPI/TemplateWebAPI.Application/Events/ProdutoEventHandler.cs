using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TemplateWebAPI.Domain.Communication.Mediator;

namespace $safeprojectname$.Events
{
    public class ProdutoEventHandler : INotificationHandler<ProdutoAdiconadoEvent>
    {

        private readonly IMediatorHandler _mediatr;

        public ProdutoEventHandler(IMediatorHandler mediatr)
        {
            _mediatr = mediatr;
        }

        public async Task Handle(ProdutoAdiconadoEvent message, CancellationToken cancellationToken)
        {
            Thread.Sleep(1000);
        }

       
    }
}
