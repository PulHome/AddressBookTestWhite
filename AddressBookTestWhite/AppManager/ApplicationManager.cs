using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;

namespace AddressBookTestWhite
{
    public class ApplicationManager
    {
        private GroupHelper groupHelper;
        
        public static string AUT_WIN_TITLE = "Free Address Book";
        public Application app;
        public ApplicationManager()
        {
            app = Application.Launch(@"D:\AutoItX\AddressBook.exe");
            MainWindow = app.GetWindow(AUT_WIN_TITLE);
            groupHelper = new GroupHelper(this);
        }
        public Window MainWindow { get; private set; }
        public void Stop()
        {
            //app.Kill();
            MainWindow.Get<Button>("uxExitAddressButton").Click();
            
        }
        
        public GroupHelper Groups
        {
            get { return groupHelper; }
        }
    }
}
