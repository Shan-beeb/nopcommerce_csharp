using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NOP.COMMERCE.WEB.AT.GUI.PageObject
{
    public class Page
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public Page(IWebDriver driver, int maximumWaitingTime = 30)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(maximumWaitingTime));
        }

        public IWebElement FindElement(By @by) => _driver.FindElement(by);
        
        public void NavigateToUrl(string url) => _driver.Navigate().GoToUrl(new Uri(url));

        public void WaitForElementToBeVisible(Func<IWebElement> targetFunc)
        {
            _wait.Until(_ =>
            {
                try
                {
                    var targetElement = targetFunc.Invoke();
                    return targetElement.Displayed && targetElement.Enabled;
                }
                catch (WebDriverTimeoutException e)
                {
                    Console.WriteLine($"Maximum timeout has been reached {e.Message}");
                    return false;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Something terribly wrong {e.Message}");
                    return false;
                }
            });
            
        }

        public void WebDriverQuit()
        {
            _driver.Quit();
        }
    }
}