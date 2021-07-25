using Coypu;

namespace NinjaPlus.Pages
{
    public class Sidebar
    {
        private readonly BrowserSession _browser;

        public Sidebar(BrowserSession Browser) //Tem que ter o mesmo nome que a class
        {
            _browser = Browser;
        }

        public string LoggedUser() //Para ele poder devolver uma String
        {
           return _browser.FindCss(".user .info span").Text;
           
        }

    }
}