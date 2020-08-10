using NOP.COMMERCE.WEB.AT.GUI.PageObject.nopCommerceInternal;

namespace NOP.COMMERCE.WEB.AT.GUI.FlowBuilder.nopCommerceInternalFlow.Navigable
{
    public class AdminAreaLoginPageNavigable : INavigable
    {
        private readonly AdminAreaLoginPage _adminAreaLoginPage;
        private readonly string _email;
        private readonly string _password;

        public AdminAreaLoginPageNavigable(AdminAreaLoginPage adminAreaLoginPage, string email, string password)
        {
            _adminAreaLoginPage = adminAreaLoginPage;
            _email = email;
            _password = password;
        }

        public void Execute()
        {
            _adminAreaLoginPage
                .WaitForModuleToBeVisible()
                .FillEmail(_email)
                .FillPassword(_password)
                .ClickLogin();
        }
    }
}