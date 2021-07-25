using Coypu;//2 - Tem que informar que vc vai usar o Coypu

namespace NinjaPlus.Pages

{
    public class LoginPage
    {
        //1 - Coisa para se fazer: FOi criado para poder ter acesso a estancia do Coypu(browser)
        //  |
        //  V
        private readonly BrowserSession _browser; //_POr convenção é para com under_line


        //3 - FOi criado o construtor para a instancia funcionar.
        //                                 |
        //                                 V
        public LoginPage(BrowserSession Browser) //Construtor é um metodo que tem o mesmo nome da classe. 
                                                 //O constutor não é tipado, sendo assim, ele vai receber um Objeto do tipo (BrowserSession browser).
                                                 //Sendo assim, vou poder usar ele para  Para realizar as buscas
        {
            _browser = Browser; //<===Quando instaciar a classe login page vou falar que _browser = browser  
                                // Dessa forma eu vou receber a instacia do coypu dentro dessa classe 
                                //vou poder usar o _browser para buscar os elementos
        }
        public void Load()
        {
            _browser.Visit("/login");
        }
        public void Whith(string email, string pass) //Custom command ou custom action
        {
            this.Load(); //This assim eu invoco o metodo dentro de outro metodo ou class
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