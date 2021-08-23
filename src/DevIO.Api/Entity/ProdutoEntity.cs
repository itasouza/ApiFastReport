using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Api.Entity
{
    public class ProdutoEntity : BaseEntity
    {
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Ean { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaEntity Categoria { get; set; }
    }
}
