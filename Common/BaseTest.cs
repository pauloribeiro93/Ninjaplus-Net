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

    {
        protected BrowserSession Browser; 


        [SetUp] 
        public void Setup()
        {
            var config = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();
          
            var sessionConfig = new SessionConfiguration
            {
                AppHost = "http://ninjaplus-web",
                Port = 5000, 
                SSL = false,
                Driver = typeof(SeleniumWebDriver),
                Timeout = TimeSpan.FromSeconds(10),

            };
            if (config["browser"].Equals("chrome"))
            {
                sessionConfig.Browser = Coypu.Drivers.Browser.Chrome;
            
            }
            if (config["browser"].Equals("firefox"))
            {
                sessionConfig.Browser = Coypu.Drivers.Browser.Firefox;
            }
            
            Browser = new BrowserSession(sessionConfig);
            Browser.MaximiseWindow();
        }



        public string CoverPath()
        {
            var outputPath = Environment.CurrentDirectory;
            return outputPath + "\\Images\\"; //Barra invertida no /Mac/ ou no /Linux/

        }
        public void TakeScreenshot()
        {
            var resultId = TestContext.CurrentContext.Test.ID; 
            var shotPath = Environment.CurrentDirectory + "\\Screenshots";

            if (!Directory.Exists(shotPath))
            {
                Directory.CreateDirectory(shotPath);
            }

            var screenshot = $"{shotPath}\\{resultId}.png";

            Browser.SaveScreenshot(screenshot);
            TestContext.AddTestAttachment(screenshot);

        }


       
        [TearDown] 
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
