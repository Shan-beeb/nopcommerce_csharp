using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NOP.COMMERCE.WEB.AT.GUI.PageObject.nopCommerceInternal;
using TechTalk.SpecFlow;

namespace NOP.COMMERCE.WEB.AT.StepDefinitions.nopCommerceInternal
{
    [Binding]
    public class NopCommerceInternalPortalLoginFunctionalitySteps
    {
        private readonly AdminAreaLoginPage _adminAreaLoginPage;
        private readonly NopCommerceInternalPortalMainPage _nopCommerceInternalPortalMainPage;

        public NopCommerceInternalPortalLoginFunctionalitySteps(AdminAreaLoginPage adminAreaLoginPage,
            NopCommerceInternalPortalMainPage nopCommerceInternalPortalMainPage)
        {
            _adminAreaLoginPage = adminAreaLoginPage;
            _nopCommerceInternalPortalMainPage = nopCommerceInternalPortalMainPage;
        }

        // When
        [When(@"a user enters (.*) and (.*) as credentials")]
        public void WhenAUserEntersAdminYourStoreComAndAdminAsCredentials(string email, string password)
        {
            _adminAreaLoginPage
                .WaitForModuleToBeVisible()
                .FillEmail(email)
                .FillPassword(password);
        }

        [When(@"a user clicks on submit button")]
        public void WhenAUserClicksOnSubmitButton()
        {
            _adminAreaLoginPage.ClickLogin();
        }

        [When(@"a user does not enter any email")]
        public void WhenAUserDoesNotEnterAnyEmail()
        {
            _adminAreaLoginPage.FillEmail(string.Empty);
        }


        // Then
        [Then(@"a user should be logged in")]
        public void ThenAUserShouldBeLoggedIn()
        {
            var isLogoutPageDisplayed =
                _nopCommerceInternalPortalMainPage
                    .WaitForModuleToBeVisible()
                    .IsLogoutElementDisplayed();

            Assert.IsTrue(isLogoutPageDisplayed, "isLogoutPageDisplayed");
        }

        [Then(@"a user should get the following error message in admin area login page")]
        public void ThenAUserShouldGetTheFollowingErrorMessageInAdminAreaLoginPage(string expectedMessage)
        {
            Assert.AreEqual(expectedMessage, _adminAreaLoginPage.GetLoginValidationEditMessage());
        }

        [Then(@"a user should get the following error message underneath user's email input")]
        public void ThenAUserShouldGetTheFollowingErrorMessageUnderneathUserSEmailInput(string expectedMessage)
        {
            Assert.AreEqual(expectedMessage, _adminAreaLoginPage.GetEmailValidationEditMessage());
        }

        [Then(@"following emails will trigger a validation edit as Wrong email")]
        public void ThenFollowingEmailsWillTriggerAValidationEditAsWrongEmail(Table table)
        {
            const string expectedValidationEdit = "Wrong email";
            
            foreach (var row in table.Rows)
            {
                _adminAreaLoginPage
                    .FillEmail(row[0]);
                 Assert.AreEqual(expectedValidationEdit,_adminAreaLoginPage.GetEmailValidationEditMessage());
                Console.WriteLine(row[0]);
            }
            
            
        }
    }
}