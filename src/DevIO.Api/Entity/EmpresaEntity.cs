using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Api.Entity
{
    public class EmpresaEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
    }
}
