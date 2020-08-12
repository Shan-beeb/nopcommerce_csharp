using NOP.COMMERCE.WEB.AT.GUI.PageObject.nopCommerceInternal;
using NOP.COMMERCE.WEB.AT.GUI.Utils;

namespace NOP.COMMERCE.WEB.AT.GUI.FlowBuilder.nopCommerceInternalFlow.Navigable
{
    public class AdminAreaLoginPageNavigable : INavigable
    {
        private readonly AdminAreaLoginPage _adminAreaLoginPage;
        private readonly IPdfGenerator _pdfGenerator;
        private readonly string _email;
        private readonly string _password;

        public AdminAreaLoginPageNavigable(AdminAreaLoginPage adminAreaLoginPage, IPdfGenerator pdfGenerator,
            string email, string password)
        {
            _adminAreaLoginPage = adminAreaLoginPage;
            _pdfGenerator = pdfGenerator;
            _email = email;
            _password = password;
        }

        public void Execute()
        {
            _adminAreaLoginPage.WaitForModuleToBeVisible();
            _pdfGenerator?.TakeScreenshot();
            _adminAreaLoginPage
                .FillEmail(_email)
                .FillPassword(_password);
            _pdfGenerator?.TakeScreenshot();
            _adminAreaLoginPage.ClickLogin();
        }
    }
}