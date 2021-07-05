using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TemplateWebAPI.Application.Commands;
using TemplateWebAPI.Application.ViewModels;
using TemplateWebAPI.Domain.Communication.Mediator;

namespace $safeprojectname$.V1
{
    [ApiVersion("1.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IMediatorHandler _mediatr;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public ProdutosController(IMediatorHandler mediatr, IMapper mapper, ILogger<ProdutosController> logger)
        {
            _mediatr = mediatr;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(AcidionarProdutoViewModel pedidoViewModel)
        {
            _logger.LogWarning("teste....");
            var sucesso = await _mediatr.EnviarComando(_mapper.Map<AdicionarProdutoCommand>(pedidoViewModel));

            if (!sucesso) return BadRequest();

            return Ok();
        }
    }
}
