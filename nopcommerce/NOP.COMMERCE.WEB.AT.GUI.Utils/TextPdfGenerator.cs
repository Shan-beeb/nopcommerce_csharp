using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NOP.COMMERCE.WEB.AT.GUI.PageObject;


namespace NOP.COMMERCE.WEB.AT.GUI.Utils
{
    public class TextPdfGenerator : IPdfGenerator
    {
        private readonly Page _page;
        private readonly string _location;
        private readonly string _fileName;
        private readonly PdfPTable _table;

        public TextPdfGenerator(Page page, string location, string fileName)
        {
            _location = location;
            _fileName = fileName;
            _page = page;

            const int numColumns = 1;
            const int widthPercentage = 100;
            _table = new PdfPTable(numColumns)
            {
                WidthPercentage = widthPercentage
            };
        }

        public void AddText(string text)
        {
            _table.AddCell(text);
        }

        public void TakeScreenshot()
        {
            var image = Image.GetInstance(_page.GetScreenShotAsByteArray());
            _table.AddCell(image);
        }

        public void GeneratePdf()
        {
            var fileNameWithTimeStamp = $"{_fileName}_{DateTime.Now:dd-MM-yyyy_HHmmss}.pdf";
            var filePath = Path.Combine(_location, fileNameWithTimeStamp);

            var document = new Document(PageSize.A3);
            var fileStream = new FileStream(filePath, FileMode.Create);
            var pdfWriter = PdfWriter.GetInstance(document, fileStream);

            pdfWriter.Open();
            document.Open();
            document.Add(_table);
            document.Close();
            document.Close();
        }
    }
}