using System;
using System.IO;
using Coypu;
using Coypu.Drivers.Selenium;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;


namespace NinjaPlus.Common
{
    public class BaseTest
    //publica =>public == Qualuqer codigo acessa ou projeto exemplo nome
    //privada =>private == Ela pode ser acessa somente pela classe  que ela está _nome
    //protegida => protected == Ela pode ser acessada somente por ela ou por um filho herdado Nome
    {
        protected BrowserSession Browser; //Propriedade para eu poder usar em todo test


        [SetUp] //Before do nUnit | Instanciei o Coypu para o Setup.
        public void Setup()
        {
            var config = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();
            // 2 - Aqui é segunda coisa a se fazer
            //Aqui realizamos as configurações de acesso igual o capybara // Configurações do Coypu definidas na varivel(Config)
            var sessionConfig = new SessionConfiguration
            {
                AppHost = "http://ninjaplus-web", //Definir host pafrão.
                Port = 5000, //porta padrão
                SSL = false, //Propriedade SSL define se vai trabalhar com HTTPS.
                Driver = typeof(SeleniumWebDriver), //Tipo de Driver utilizado, Necessario realizar 
                //o using para SeleniumWebDriver.
                // Browser = Coypu.Drivers.Browser.Chrome, //Decisão do Navegador a ser utiizado no teste. 
                Timeout = TimeSpan.FromSeconds(10), //timout padrão
                

            };
            if (config["browser"].Equals("chrome"))
            {
                sessionConfig.Browser = Coypu.Drivers.Browser.Chrome;
            
            }
            if (config["browser"].Equals("firefox"))
            {
                sessionConfig.Browser = Coypu.Drivers.Browser.Firefox;
            }
            // 1 - TUDO COMEÇA AQUI
            //Quando eu estanciar Browser aqui em baixo eu vou passar as configurações(configs) para BrowserSession
            //Minha variavel Browser sabe qual configurações eu vou utilizar(As informações do config)
            Browser = new BrowserSession(sessionConfig); //instanciei para utilizar os configs | BrowserSession é onde tudo começa, vou ter acesso do coypu aqui 
            Browser.MaximiseWindow();
        }



        public string CoverPath()
        {
            var outputPath = Environment.CurrentDirectory;
            return outputPath + "\\Images\\"; //Barra invertida no /Mac/ ou no /Linux/

        }
        public void TakeScreenshot()
        {
            var resultId = TestContext.CurrentContext.Test.ID; // Contexto do NUnit
            var shotPath = Environment.CurrentDirectory + "\\Screenshots";

            if (!Directory.Exists(shotPath))
            {
                Directory.CreateDirectory(shotPath);
            }

            var screenshot = $"{shotPath}\\{resultId}.png";

            Browser.SaveScreenshot(screenshot);
            TestContext.AddTestAttachment(screenshot);

        }


        //Afater do nUnit
        [TearDown] //Gancho| independente o que acontecer no Teste ele vai fechar o Browser
        public void Finish()
        {
            try
            {
                TakeScreenshot();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao capturar o Screenshot :S");
                throw new Exception(e.Message);
            }
            finally
            {
                Browser.Dispose();
            }
        }
    }
}