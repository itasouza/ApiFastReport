using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Api.Entity
{
    public class VendaEntity : BaseEntity
    {
        public int ClienteId { get; set; }
        public ClienteEntity Cliente { get; set; }
        public DateTime DataVenda { get; set; }
        public Decimal TotalVenda { get; set; }
        public IEnumerable<VendaItemEntity> VendaItem { get; set; }

    }
}
