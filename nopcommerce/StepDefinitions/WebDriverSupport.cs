using BoDi;
using NOP.COMMERCE.WEB.AT.GUI.PageObject;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace NOP.COMMERCE.WEB.AT.StepDefinitions
{
    [Binding]
    public class WebDriverSupport
    {
        private readonly IObjectContainer _objectContainer;

        public WebDriverSupport(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario()]
        public void BeforeScenario()
        {
            // We go with Chrome browser now
            var driver = new ChromeDriver();
            var page = new Page(driver);
            _objectContainer.RegisterInstanceAs(page);
        }

        [AfterScenario()]
        public void AfterScenario()
        {
            var page = _objectContainer.Resolve<Page>();
            page.WebDriverQuit();
        }
    }
}