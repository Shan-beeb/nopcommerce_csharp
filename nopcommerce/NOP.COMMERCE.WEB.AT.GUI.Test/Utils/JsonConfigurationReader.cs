using Microsoft.Extensions.Configuration;

namespace NOP.COMMERCE.WEB.AT.GUI.Test.Utils
{
    public class JsonConfigurationReader
    {
        private const string InternalUrl = "internalUrl";
        private const string PdfPath = "pdfPath";
        private readonly IConfigurationRoot _configuration;

        public JsonConfigurationReader()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appConfig.json").Build();
        }

        public string GetInternalPortalUrl => _configuration[InternalUrl];
        public string GetPdfReportPath => _configuration[PdfPath];
    }
}