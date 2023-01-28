using DinkToPdf;
using DinkToPdf.Contracts;

namespace Cooper.Infrastructure.Services
{

    public interface IHtmlToPdfHelper
    {
        public string ConvertToPdf(string htmlContent, string fileName);
    }
    public class HtmlToPdfHelper : IHtmlToPdfHelper
    {
        private readonly IConverter _converter;
        public HtmlToPdfHelper(IConverter converter)
        {
            _converter = converter;
        }
        public string ConvertToPdf(string htmlContent, string fileName)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DPI = 370,
                DocumentTitle = fileName,
                ImageDPI = 370
            };
            var objectSettings = new ObjectSettings
            {
                HtmlContent = htmlContent,
                WebSettings =
            {
                DefaultEncoding = "utf-8"
            }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            var fileBytes = _converter.Convert(pdf);
            var path = SaveDocument(fileBytes, fileName);
            return path;
        }
        private static string SaveDocument(byte[] file, string fileName)
        {
            var stream = new MemoryStream(file);
            stream.Seek(0, SeekOrigin.Begin);
            var pdfFileName = string.Concat(fileName, ".pdf");
            var path = Path.Combine("C:\\Users\\Juan Luis\\Downloads\\Cooper-main\\Cooper-main\\Cooper.Design\\temp\\", pdfFileName);
            using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            stream.WriteTo(fileStream);
            return path;
        }
    }
}
