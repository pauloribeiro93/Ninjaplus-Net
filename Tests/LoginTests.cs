using NUnit.Framework;
using NinjaPlus.Pages; //Importando o namespace eu tenho acesso a Classe LoginPage
using NinjaPlus.Common;

namespace NinjasPlus.Tests
{
    //Criando a nossa Class de testes
    public class LoginTests : BaseTest
    {
        // public BrowserSession browser; //Propriedade para eu poder usar em todo test
        private LoginPage _login; //PAGE Criar porpriedade para não declar em cada teste
        private Sidebar _side; //PAGE Criar porpriedade para não declar em cada teste


        [SetUp] //Before do nUnit | Instanciei o Coypu para o Setup.
        public void Start()
        {
            //ULTIMO PASSO A SER REALIZADO SOBRE PAGE OBJECT TIRANDO O IMPORT DO NAMESPACE DA CLASSE
            //Depois de fazer o page Object, vc cria uma variavel que vai ser uma nova instacia da classe LoginPage recebendo browser
            //Recebendo todas configurações do Coypu 
            //var LoginPage = new LoginPage(browser);
            //Recebdno a instacia do browse, ele tem acesso
            //ao contexto do Coypu.
            //var sidebar = new Sidebar(browser);

            _login = new LoginPage(Browser);//PAGE Depois de criar as propriedades eu faço isso
            _side = new Sidebar(Browser);//Instacniando as paginas dentro do SETUP sem preciar chamer no metodo de teste
        }

        // Temos que colocar uma notação "Test" para o nUnit entender que é um Teste.
        [Test]//PRecisa chamar o using para funcionar
        [Category("Critical")]
        public void ShouldSeeLoggedUser() //Dica: Metodo de Teste, Escrever metodo de teste com uma finalidade
        {

            _login.Whith("paulo@ninjaplus.com", "pwd123");

            Assert.AreEqual("Paulo", _side.LoggedUser());
        }
        //DDT => Teste orientado a Dados (Data Driven Testing)
        [TestCase("paulo@ninjaplus.com", "123456", "Usuário e/ou senha inválidos")]
        [TestCase("404@ninjaplus.com", "123pwd", "Usuário e/ou senha inválidos")]
        [TestCase("", "123pwd", "Opps. Cadê o email?")]
        [TestCase("paulo@ninjaplus.com", "", "Opps. Cadê a senha?")]
        public void ShouldSeeIncorrectPass(string email, string pass, string expectMessage)
        {
            _login.Whith(email, pass);

            Assert.AreEqual(expectMessage, _login.AltertMessage());
        }

    }
}