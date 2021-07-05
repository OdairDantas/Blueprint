using System;
using System.ComponentModel.DataAnnotations.Schema;
using $safeprojectname$.DomainObjects;
using $safeprojectname$.DomainObjects.Interfaces;

namespace $safeprojectname$.Entites
{
    public class Produto : Entity, IAggregateRoot
    {
        public Produto( decimal valor, string descricao)
        {
            Valor = valor;
            Descricao = descricao;
        }
        public string Descricao { get; private set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Valor { get; private set; }

    }
}
