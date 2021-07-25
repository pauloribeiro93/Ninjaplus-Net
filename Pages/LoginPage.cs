using Coypu;//2 - Tem que informar que vc vai usar o Coypu

namespace NinjaPlus.Pages

{
    public class LoginPage
    {
    
        private readonly BrowserSession _browser; 
        
        public LoginPage(BrowserSession Browser)  
                                                 
                                                
        {
            _browser = Browser; 
                              
                                
        }
        public void Load()
        {
            _browser.Visit("/login");
        }
        public void Whith(string email, string pass)
        {
            this.Load(); 
            _browser.FillIn("emailId").With(email);
            _browser.FindCss("#passId").SendKeys(pass);
            _browser.ClickButton("Entrar");
        }
        public void valida()
        {
             var logo = _browser.FindCss("img[src$='logo-white.png']").Text;
      

        }

        public string AltertMessage ()
        {
            return _browser.FindCss(".alert  span b").Text; //.text para pegar o texto que ele retorna
        }
    }
}
