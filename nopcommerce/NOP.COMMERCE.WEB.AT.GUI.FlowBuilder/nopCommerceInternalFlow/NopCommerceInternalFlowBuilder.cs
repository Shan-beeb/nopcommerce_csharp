using System.Collections.Generic;
using System.Linq;
using NOP.COMMERCE.WEB.AT.GUI.FlowBuilder.nopCommerceInternalFlow.Navigable;
using NOP.COMMERCE.WEB.AT.GUI.PageObject;
using NOP.COMMERCE.WEB.AT.GUI.PageObject.nopCommerceInternal;
using NOP.COMMERCE.WEB.AT.GUI.Utils;

namespace NOP.COMMERCE.WEB.AT.GUI.FlowBuilder.nopCommerceInternalFlow
{
    public class NopCommerceInternalFlowBuilder
    {
        private readonly Page _page;
        private readonly IPdfGenerator _pdfGenerator;
        private readonly List<INavigable> _navigable;

        private AdminAreaLoginPage _adminAreaLoginPage;

        public NopCommerceInternalFlowBuilder(Page page, IPdfGenerator pdfGenerator = null)
        {
            _page = page;
            _pdfGenerator = pdfGenerator;
            _navigable = new List<INavigable>();
        }


        public NopCommerceInternalFlowBuilder FillAdminAreaLoginPage(string email, string password)
        {
            _adminAreaLoginPage = _adminAreaLoginPage ?? new AdminAreaLoginPage(_page);
            _navigable.Add(new AdminAreaLoginPageNavigable(_adminAreaLoginPage,_pdfGenerator, email, password));
            return this;
        }

        public void Build()
        {
            _navigable.ToList().ForEach(fw => fw.Execute());
        }

        public void Clear()
        {
            _navigable.Clear();
        }
    }
}