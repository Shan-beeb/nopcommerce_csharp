using NOP.COMMERCE.WEB.AT.GUI.PageObject;
using TechTalk.SpecFlow;

namespace NOP.COMMERCE.WEB.AT.GUI.Test.Steps
{
    [Binding]
    public class UrlsInitializer
    {
        private readonly Page _page;

        public UrlsInitializer(Page page)
        {
            _page = page;
        }
        
        [Given(@"a user wants to login to nopCommerce internal portal")]
        public void GivenAUserWantsToLoginToNopCommerceInternalPortal()
        {
           _page.NavigateToUrl("https://admin-demo.nopcommerce.com/");
        }
    }
}