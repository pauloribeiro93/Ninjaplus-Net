using NUnit.Framework;
using NinjaPlus.Common;
//using System.Threading;

//Org no Namespace  vai a cordo de onde o teste está localizado
//Dentro do NameSpace.Pasta.ArquivodeTeste
namespace NinjasPlus.Tests 
{
    public class OnAirTest : BaseTest //Herdando o BaseTest para usar o Setup //Classe de Teste |Nome da class tem que ser o mesmo do arquivo
    {

        [Test]
        [Category("Smoke")] //catgorizar dotnet test --filter TestCategory= Nome da tag
        public void ShouldBeHaveTitle() //Nome do teste | Isso é um metodo
        {
          
            Browser.Visit("/login"); //Visit estilo Capybara
            Assert.AreEqual("Ninja+", Browser.Title); //Esse Assert é do nUnit   (Valor, seja igual) |Browser.Title pega o titulo da pagina
            //Thread.Sleep(5000); //Sleep para aguardar |Era temporaido
        
        }
      
    }
}