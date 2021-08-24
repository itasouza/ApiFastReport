using DevIO.Api.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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

            var webReport = new WebReport();
            webReport.Report.Load(Path.Combine("Reports\\ListagemUsuario.frx"));
            var usuarioList = _context.Usuarios.Where(u => u.Nome != "").ToList();
            var usuarios = new DataTable();
            usuarios.Columns.Add("id", typeof(string));
            usuarios.Columns.Add("Nome", typeof(string));
            usuarios.Columns.Add("Email", typeof(string));

            foreach (var item in usuarioList)
            {
                usuarios.Rows.Add(item.Id, item.Nome, item.Email);
            }
            webReport.Report.RegisterData(usuarios, "Usuarios");
            webReport.Report.Prepare();
            byte[] reportArray = null;
            using (MemoryStream ms = new MemoryStream())
            {
                var pdfExport = new PDFSimpleExport();
                pdfExport.Export(webReport.Report, ms);
                ms.Flush();
                reportArray = ms.ToArray();

            }
            return File(reportArray, "application/pdf", "ListagemDeUsuario.pdf");
        }


    }
}
