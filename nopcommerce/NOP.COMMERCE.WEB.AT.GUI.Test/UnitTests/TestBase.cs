using Microsoft.VisualStudio.TestTools.UnitTesting;
using NOP.COMMERCE.WEB.AT.GUI.Test.Utils;

namespace NOP.COMMERCE.WEB.AT.GUI.Test.UnitTests
{
    [TestClass]
    public class TestBase
    {
        protected JsonConfigurationReader JsonConfiguration;
        public TestContext TestContext { get; set; }
        
        
        [TestInitialize]
        public void ReadConfigurations()
        {
            JsonConfiguration = new JsonConfigurationReader();
        }
    }
}