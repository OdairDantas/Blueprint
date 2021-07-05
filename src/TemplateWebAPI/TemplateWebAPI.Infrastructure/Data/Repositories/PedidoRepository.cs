using TemplateWebAPI.Domain.Entites;
using TemplateWebAPI.Domain.Repositories;
using $safeprojectname$.Data.Contexts;

namespace $safeprojectname$.Data.Repositories
{
    public class PedidoRepository : Repository<Produto>, IProdutoRepository
    {
        public PedidoRepository(CompraContext context) : base(context)
        {
        }
    }
}
