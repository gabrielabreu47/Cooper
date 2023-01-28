using Cooper.Application.Bills.Dtos;
using Cooper.Application.Bills.Interfaces;
using Cooper.Core.Extensions;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Cooper.Infrastructure.Services
{
    public interface IDocumentService
    {
        string GenerateBill(BillDto billDto);
    }
    public class DocumentService : IDocumentService
    {
        private readonly IHtmlToPdfHelper _htmlToPdfHelper;

        public DocumentService(IHtmlToPdfHelper htmlToPdfHelper)
        {
            _htmlToPdfHelper = htmlToPdfHelper;
        }

        public string GenerateBill(BillDto billDto)
        {
            var path = "C:\\Users\\Juan Luis\\Downloads\\Cooper-main\\Cooper-main\\Cooper.Design\\Templates\\invoice.html";

            var streamReader = new StreamReader(path);

            var file = streamReader.ReadToEnd();

            file = new Regex("{{TOTAL}}").Replace(file, billDto.Total.ToString());
            file = new Regex("{{DATE}}").Replace(file, billDto.Total.ToString());
            file = new Regex("{{CONTENT}}").Replace(file, GenerateBillDetail(billDto.Products));

            var bytes = Encoding.Default.GetBytes(file);

            string billName = $"Factura-{billDto.Id}{billDto.ClientName}.html";
            var stream = new MemoryStream(bytes);
            stream.Seek(0, SeekOrigin.Begin);
            var fileName = string.Concat(billName, ".html");
            var pathSaved = Path.Combine("C:\\Users\\Juan Luis\\Downloads\\Cooper-main\\Cooper-main\\Cooper.Design\\temp\\", fileName);
            using FileStream fileStream = new FileStream(pathSaved, FileMode.Create, FileAccess.Write);
            stream.WriteTo(fileStream);
            return pathSaved;
        }

        private static string GenerateBillDetail(List<BillProductDto> billProductDtos)
        {
            var path = "C:\\Users\\Juan Luis\\Downloads\\Cooper-main\\Cooper-main\\Cooper.Design\\Templates\\invoiceDetail.html";

            var streamReader = new StreamReader(path);

            string content = "";

            var file = streamReader.ReadToEnd();

            foreach (var item in billProductDtos)
            {
                var currentProductInvoice = StringExtensions.Copy(file);

                currentProductInvoice = new Regex("{{PRODUCT}}").Replace(file, item.Name);
                currentProductInvoice = new Regex("{{STOCK}}").Replace(file, item.Stock.ToString());
                currentProductInvoice = new Regex("{{PRODUCTTOTAL}}").Replace(file, item.PriceTotal.ToString());

                content += currentProductInvoice;
            }

            return content;
        }

    }
}
