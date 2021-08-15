using NUnit.Framework;
using NinjaPlus.Pages; 
using NinjaPlus.Common;

namespace NinjasPlus.Tests
{

    public class LoginTests : BaseTest
    {
      
        private LoginPage _login; 
        private Sidebar _side;


        [SetUp] 
        public void Start()
        {

            _login = new LoginPage(Browser);
            _side = new Sidebar(Browser);
        }

        // Temos que colocar uma notação "Test" para o nUnit entender que é um Teste.
        [Test]//PRecisa chamar o using para funcionar
        [Category("Critical")]
        public void ShouldSeeLoggedUser() 
        {

            _login.Whith("paulo@ninjaplus.com", "pwd123");

            Assert.AreEqual("Paulo", _side.LoggedUser());
        }
     
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
