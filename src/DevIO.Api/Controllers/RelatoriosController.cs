using DevIO.Api.Data;
using DevIO.Api.Entity;
using DevIO.Api.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;

namespace DevIO.Api.Controllers
{

    public class RelatoriosController : ControllerBase
    {
        private readonly MeuDbContext _context;

        public RelatoriosController(MeuDbContext context)
        {
            _context = context;
        }

        [HttpGet("ListagemUsuarioSimples")]
        public IActionResult GetListagemUsuarioSimples()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var webReport = HelperFastReport.WebReport("ListagemUsuario.frx");

            var usuarioList = _context.Usuarios.Where(u => u.Nome != "").ToList();
            var usuarios = HelperFastReport.GetTable<UsuarioEntity>(usuarioList, "Usuarios");
            webReport.Report.RegisterData(usuarios, "Usuarios");
            //"Usuarios" nome usado no relatório como Data Source
            return File(HelperFastReport.ExportarPdf(webReport), "application/pdf", "ListagemDeUsuario.pdf");
        }


        [HttpGet("ListagemUsuarioComCabecalho")]
        public IActionResult GetListagemUsuarioComCabecalho()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var webReport = HelperFastReport.WebReport("ListagemUsuarioComCabecalho.frx");

            var usuarioList = _context.Usuarios.Where(u => u.Nome != "").ToList();
            var empresaList = _context.Empresas.Where(u => u.Id == 1).ToList();

            var usuarios = HelperFastReport.GetTable<UsuarioEntity>(usuarioList, "Usuarios");
            var empresas = HelperFastReport.GetTable<EmpresaEntity>(empresaList, "Empresas");

            webReport.Report.RegisterData(usuarios, "Usuarios");
            webReport.Report.RegisterData(empresas, "Empresas");
            //"Usuarios" nome usado no relatório como Data Source
            return File(HelperFastReport.ExportarPdf(webReport), "application/pdf", "ListagemDeUsuarioComCabecalho.pdf");
        }



    }
}

//exemplo usando o modelo comum 
//var usuarios = new DataTable();
//usuarios.Columns.Add("id", typeof(string));
//usuarios.Columns.Add("Nome", typeof(string));
//usuarios.Columns.Add("Email", typeof(string));
//foreach (var item in usuarioList)
//{
//    usuarios.Rows.Add(item.Id, item.Nome, item.Email);
//}