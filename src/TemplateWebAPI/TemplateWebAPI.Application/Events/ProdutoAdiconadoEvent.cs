using System;
using TemplateWebAPI.Domain.Messages;

namespace $safeprojectname$.Events
{
    public class ProdutoAdiconadoEvent : Event
    {
        public ProdutoAdiconadoEvent(Guid entityId, string descricao, decimal valor): base(entityId)
        {
            EntityId = entityId;
            Descricao = descricao;
            Valor = valor;
        }

        public string Descricao { get;private set; }
        public decimal Valor { get; private set; }
    }
}
