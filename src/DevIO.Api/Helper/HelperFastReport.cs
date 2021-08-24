using FastReport.Export.PdfSimple;
using FastReport.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Api.Helper
{
    public static class HelperFastReport
    {
        public static WebReport WebReport(string nomeDoRelatorio)
        {
            var result = new WebReport();
            result.Report.Load(Path.Combine("Reports", nomeDoRelatorio));
            return result;
        }

        public static byte[] ExportarPdf(WebReport webReport)
        {
            webReport.Report.Prepare();
            using (MemoryStream ms = new MemoryStream())
            {
                var pdfExport = new PDFSimpleExport();
                pdfExport.Export(webReport.Report, ms);
                ms.Flush();
                return ms.ToArray();

            }
        }

    }
}
