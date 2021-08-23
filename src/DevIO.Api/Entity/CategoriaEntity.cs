using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Api.Entity
{
    public class CategoriaEntity : BaseEntity
    {
        public string Descricao { get; set; }
        public IEnumerable<ProdutoEntity> Produtos { get; set; }
    }
}
