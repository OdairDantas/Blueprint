using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using $safeprojectname$.Events;
using TemplateWebAPI.Domain.Communication.Mediator;
using TemplateWebAPI.Domain.Entites;
using TemplateWebAPI.Domain.Messages;
using TemplateWebAPI.Domain.Repositories;

namespace $safeprojectname$.Commands
{

    public class ProdutoCommandHandler : IRequestHandler<AdicionarProdutoCommand, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoCommandHandler(IMediatorHandler mediatorHandler, IProdutoRepository pedidoRepository, IMapper mapper)
        {
            _mediatorHandler = mediatorHandler;
            _produtoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AdicionarProdutoCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return await Task.FromResult<bool>(false);

            var pedido = _mapper.Map<Produto>(message);
            var evento = _mapper.Map<ProdutoAdiconadoEvent>(message);
            pedido.AdicionarEvento(evento);
            await _produtoRepository.Adicionar(pedido);
            await _produtoRepository.UnitOfWork.Commit();

            return await Task.FromResult<bool>(true);
        }

        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;

            foreach (var error in message.ValidationResult.Errors)
            {
                _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, error.ErrorMessage));
            }

            return false;
        }
    }
}
