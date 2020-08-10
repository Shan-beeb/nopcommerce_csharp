using OpenQA.Selenium;

namespace NOP.COMMERCE.WEB.AT.GUI.PageObject.nopCommerceInternal

{
    public class AdminAreaLoginPage
    {
        private readonly Page _page;
        private const string PageTitleElementXpath = "//div[@class='page-title']";
        private const string EmailInputId = "Email";
        private const string EmailValidationEditId = "Email-error";
        private const string PasswordInputId = "Password";
        private const string LoginButtonXpath = "//input[@value='Log in']";
        private const string LoginValidationEditXpath = "//div[@class='message-error validation-summary-errors']";

        private IWebElement PageTitleElement => _page.FindElement(By.XPath(PageTitleElementXpath));
        private IWebElement EmailInput => _page.FindElement(By.Id(EmailInputId));
        private IWebElement EmailValidationEdit => _page.FindElement(By.Id(EmailValidationEditId));
        private IWebElement PasswordInput => _page.FindElement(By.Id(PasswordInputId));
        private IWebElement LoginButton => _page.FindElement(By.XPath(LoginButtonXpath));
        private IWebElement LoginValidationEdit => _page.FindElement(By.XPath(LoginValidationEditXpath));

        public AdminAreaLoginPage(Page page)
        {
            _page = page;
        }

        public AdminAreaLoginPage WaitForModuleToBeVisible()
        {
            _page.WaitForElementToBeVisible(() => EmailInput);
            return this;
        }

        public string GetAdminAreaPageTitle()
        {
            return PageTitleElement.Text;
        }

        public AdminAreaLoginPage FillEmail(string email)
        {
            EmailInput.Clear();
            EmailInput.SendKeys(email);
            return this;
        }

        public string GetEmailValidationEditMessage()
        {
            _page.WaitForElementToBeVisible(() => EmailValidationEdit);
            return EmailValidationEdit.Text;
        }

        public AdminAreaLoginPage FillPassword(string password)
        {
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
            return this;
        }

        public AdminAreaLoginPage ClickLogin()
        {
            LoginButton.Click();
            return this;
        }

        public string GetLoginValidationEditMessage()
        {
            _page.WaitForElementToBeVisible(() => LoginValidationEdit);
            return LoginValidationEdit.Text;
        }
    }
}