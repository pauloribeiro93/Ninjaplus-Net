using Coypu;

namespace NinjaPlus.Pages
{
    public class Sidebar
    {
        private readonly BrowserSession _browser;

        public Sidebar(BrowserSession Browser)
        {
            _browser = Browser;
        }

        public string LoggedUser() 
        {
           return _browser.FindCss(".user .info span").Text;
           
        }

    }
}
