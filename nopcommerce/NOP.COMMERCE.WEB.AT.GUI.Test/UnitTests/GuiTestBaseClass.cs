using Microsoft.VisualStudio.TestTools.UnitTesting;
using NOP.COMMERCE.WEB.AT.GUI.PageObject;
using OpenQA.Selenium.Chrome;

namespace NOP.COMMERCE.WEB.AT.GUI.Test.UnitTests
{
    [TestClass]
    public abstract class GuiTestBaseClass : TestBase
    {
        protected  Page Page;

        [TestInitialize]
        public void TestInitialize()
        {
            var driver = new ChromeDriver();
            Page = new Page(driver);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            Page.WebDriverQuit();
        }
    }
}