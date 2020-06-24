

using System.IO;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace PlayGround
{
    class Program
    {
        static void Main(string[] args)
        {
            var x =File.ReadAllText(@"C:\Users\tmi\Downloads\2020-21856-INF (2).html");
            File.WriteAllBytes(@"C:\Users\tmi\Downloads\2020-21856-INF (6).pdf", PdfSharpConvert(x));
        }

        private static byte[] PdfSharpConvert(string html)
        {
            byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                pdf.Save(ms);
                res = ms.ToArray();
            }
            return res;
        }
    }
}
