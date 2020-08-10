using Microsoft.VisualStudio.TestTools.UnitTesting;
using NOP.COMMERCE.WEB.AT.GUI.FlowBuilder.nopCommerceInternalFlow;
using NOP.COMMERCE.WEB.AT.GUI.PageObject;
using OpenQA.Selenium.Chrome;

namespace NOP.COMMERCE.WEB.AT
{
    [TestClass]
    public class PlayGround
    {

        private Page _page;
        private NopCommerceInternalFlowBuilder _nopCommerceInternalFlowBuilder;
        
        [TestInitialize]
        public void TestInitialize()
        {
            var driver = new ChromeDriver();
            _page = new Page(driver);
            _nopCommerceInternalFlowBuilder = new NopCommerceInternalFlowBuilder(_page);
        }

        [TestMethod]
        public void Test1()
        {
            const string email = "admin@yourstore.com";
            const string password = "admin";
            _page.NavigateToUrl("https://admin-demo.nopcommerce.com/");
            _nopCommerceInternalFlowBuilder.FillAdminAreaLoginPage(email,password).Build();
            
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            _page.WebDriverQuit();
        }
    }
}