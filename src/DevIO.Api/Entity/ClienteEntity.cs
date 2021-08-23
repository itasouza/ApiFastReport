using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Api.Entity
{
    public class ClienteEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public IEnumerable<VendaEntity> Vendas { get; set; }
    }
}
