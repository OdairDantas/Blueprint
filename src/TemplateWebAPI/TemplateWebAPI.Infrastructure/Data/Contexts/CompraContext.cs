using Microsoft.EntityFrameworkCore;
using System.Linq;
using TemplateWebAPI.Domain.Communication.Mediator;
using TemplateWebAPI.Domain.Messages;

namespace $safeprojectname$.Data.Contexts
{
    public class CompraContext : BaseDbContext
    {

        public CompraContext()
        {

        }

        public CompraContext(DbContextOptions<CompraContext> options, IMediatorHandler mediator) : base(options,mediator)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Ignore<Event>();
            builder.HasDefaultSchema("Vitrine");
            builder.ApplyConfigurationsFromAssembly(typeof(CompraContext).Assembly);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            base.OnModelCreating(builder);
        }
        
    }
}
