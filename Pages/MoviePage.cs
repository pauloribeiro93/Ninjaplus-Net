using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Coypu;
using NinjaPlus.Models;
using OpenQA.Selenium;

namespace NinjaPlus.Tests
{
    public class MoviePage
    {
        private readonly BrowserSession _browser; //Atributo
        public MoviePage(BrowserSession browser) //contrutor, isso é para usar o Coypu
        {
            _browser = browser;
        }
        public void Add()
        {
            _browser.FindCss(".movie-add").Click();
        }
        private void SelectStatus(string status)
        {
            _browser.FindCss("input[placeholder=Status]").Click();
            var option = _browser.FindCss("ul li span", text: status);
            option.Click();
            //_browser.Select("Disponível").From("Status"); se fosse  uns Select seria só isso 
        }
        private void InputCast(List<string> cast)
        {
            var element = _browser.FindCss("input[placeholder$='ator']");

            foreach (var actor in cast)
            {
                element.SendKeys(actor);
                element.SendKeys(Keys.Tab);
                Thread.Sleep(500); //Thinkg time uma pratica para simular um usuario real. E não uma espera de elemento.
            }


        }
        private void UploadCover(string cover)
        {
            var jsScript = "document.getElementById('upcover').classList.remove('el-upload__input');";
            //Já que o C# não exeuta JavaScript é necessario botar em uma variavel botar para executar e, 
            //deixar tudo como string.
            _browser.ExecuteScript(jsScript);

            _browser.FindCss("#upcover").SendKeys(cover);
        }
        public void Save(MovieModel movie)
        {
            _browser.FindCss("input[name='title']").SendKeys(movie.Title);
            SelectStatus(movie.Status);
            _browser.FindCss("input[name=year]").SendKeys(movie.Year.ToString());
            _browser.FindCss("input[name=release_date]").SendKeys(movie.ReleaseDate);
            InputCast(movie.cast);
            _browser.FindCss("textarea[name=overview]").SendKeys(movie.Plot);
            UploadCover(movie.Cover);
            _browser.ClickButton("Cadastrar");

        }

        public void Search(string value)
        {
            _browser.FindCss("input[placeholder^=Pesquisar]").SendKeys(value);
            _browser.FindId("search-movie").Click();
        }

        public int CountMovie()
        {
            return _browser.FindAllCss("table tbody tr").Count();
        }

        public string SearchAlert()
        {
            return _browser.FindCss(".alert-dark").Text;
        }

        public bool HasMovie(string title)
        {
            return  _browser.FindCss("table tbody tr", text: title).Exists();
        }
    }
}