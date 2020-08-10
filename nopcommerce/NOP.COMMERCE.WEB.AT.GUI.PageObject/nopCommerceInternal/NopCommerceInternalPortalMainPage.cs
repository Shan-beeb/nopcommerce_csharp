using OpenQA.Selenium;

namespace NOP.COMMERCE.WEB.AT.GUI.PageObject.nopCommerceInternal
{
    public class NopCommerceInternalPortalMainPage
    {
        private readonly Page _page;

        private const string LogoutXpath = "//a[contains(text(),'Logout')]";

        private IWebElement Logout => _page.FindElement(By.XPath(LogoutXpath));


        public NopCommerceInternalPortalMainPage(Page page)
        {
            _page = page;
        }

        public NopCommerceInternalPortalMainPage WaitForModuleToBeVisible()
        {
            _page.WaitForElementToBeVisible(() => Logout);
            return this;
        }

        public bool IsLogoutElementDisplayed()
        {
            return Logout.Displayed;
        }
    }
}