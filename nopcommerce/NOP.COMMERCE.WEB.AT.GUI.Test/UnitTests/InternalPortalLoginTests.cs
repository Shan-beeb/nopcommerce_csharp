using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NOP.COMMERCE.WEB.AT.GUI.PageObject.nopCommerceInternal;
using NOP.COMMERCE.WEB.AT.GUI.Utils;

namespace NOP.COMMERCE.WEB.AT.GUI.Test.UnitTests
{
    [TestClass]
    public class InternalPortalLoginTests : GuiTestBaseClass
    {
        private IPdfGenerator _pdfGenerator;
        private AdminAreaLoginPage _adminAreaLoginPage;

        [TestInitialize]
        public void UrlSetup()
        {
            Page.NavigateToUrl(JsonConfiguration.GetInternalPortalUrl);
            _pdfGenerator = new TextPdfGenerator(Page, JsonConfiguration.GetPdfReportPath,$"InternalPortalLoginTests_{TestContext.TestName}");
            _adminAreaLoginPage = new AdminAreaLoginPage(Page);

            _adminAreaLoginPage.WaitForModuleToBeVisible();
            _pdfGenerator.TakeScreenshot();
        }


        [DataTestMethod]
        [DataRow("admin@yourstore.com", "admin")]
        public void TestForRegisteredUsers(string email, string password)
        {
            var internalPortalMainPage = new NopCommerceInternalPortalMainPage(Page);
            _adminAreaLoginPage.FillEmail(email).FillPassword(password);
            _pdfGenerator.TakeScreenshot();
            _adminAreaLoginPage.ClickLogin();

            Assert.IsTrue(internalPortalMainPage.IsLogoutElementDisplayed(),
                "internalPortalMainPage.IsLogoutElementDisplayed()");
        }

        [DataTestMethod]
        [DataRow("wrongemail1@yourstore.com", "admin")]
        [DataRow("wrongemail2@yourstore.com", "admin")]
        [DataRow("wrongemail3@yourstore.com", "admin")]
        public void TestForNonRegisteredUsers(string email, string password)
        {
            var expectedErrorMessage =
                $"Login was unsuccessful. Please correct the errors and try again.{Environment.NewLine}No customer account found";

            _adminAreaLoginPage.FillEmail(email).FillPassword(password);
            _pdfGenerator.TakeScreenshot();
            _adminAreaLoginPage.ClickLogin();

            Assert.AreEqual(expectedErrorMessage, _adminAreaLoginPage.GetLoginValidationEditMessage());
        }

        [DataTestMethod]
        [DataRow("admin@yourstore.com", "admin1")]
        [DataRow("admin@yourstore.com", "admin2")]
        [DataRow("admin@yourstore.com", "admin3")]
        public void TestForWrongPassword(string email, string password)
        {
            var expectedErrorMessage =
                $"Login was unsuccessful. Please correct the errors and try again.{Environment.NewLine}The credentials provided are incorrect";

            _adminAreaLoginPage.FillEmail(email).FillPassword(password);
            _pdfGenerator.TakeScreenshot();
            _adminAreaLoginPage.ClickLogin();

            Assert.AreEqual(expectedErrorMessage, _adminAreaLoginPage.GetLoginValidationEditMessage());
        }

        [TestMethod]
        public void TestForEmptyEmail()
        {
            const string expectedErrorMessage = "Please enter your email";
            _adminAreaLoginPage.FillEmail(string.Empty).FillPassword("Any");
            _pdfGenerator.TakeScreenshot();
            _adminAreaLoginPage.ClickLogin();

            Assert.AreEqual(expectedErrorMessage, _adminAreaLoginPage.GetEmailValidationEditMessage());
        }

        [DataTestMethod]
        [DataRow("adminyourstore")]
        [DataRow("adminyourstore..com")]
        [DataRow("admin..yourstore.com")]
        [DataRow("admin*9yourstore.com")]
        [DataRow("admin()yourstore.com")]
        [DataRow("admin#$%#yourstore.com")]
        public void TestForInvalidEmailFormat(string email)
        {
            const string expectedErrorMessage = "Wrong email";
            _adminAreaLoginPage.FillEmail(email).FillPassword("Any");
            
            Assert.AreEqual(expectedErrorMessage, _adminAreaLoginPage.GetEmailValidationEditMessage());
        }

        [TestCleanup]
        public void GeneratePdf()
        {
            _pdfGenerator.TakeScreenshot();
            _pdfGenerator.GeneratePdf();
        }
    }
}