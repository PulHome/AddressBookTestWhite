using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookTestWhite
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected string AUT_WIN_TITLE;
        public HelperBase(ApplicationManager appMan)
        {
            this.manager = appMan;
            this.AUT_WIN_TITLE = ApplicationManager.AUT_WIN_TITLE;
        }
    }
}
