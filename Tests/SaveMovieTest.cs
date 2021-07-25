using NinjaPlus.Common;
using NUnit.Framework;
using NinjaPlus.Pages;
using System.Threading;
using NinjaPlus.Models;
using System;
using NinjaPlus.Lib;

namespace NinjaPlus.Tests
{
    public class SaveTest : BaseTest
    {
        private LoginPage _login;

        private MoviePage _movie;

        [SetUp]
        public void Before()
        {
            _login = new LoginPage(Browser);
            _movie = new MoviePage(Browser);
            _login.Whith("paulo@ninjaplus.com", "pwd123");
        }
        [Test]
        public void ShouldSaveMovie()
        {
            var movieData = new MovieModel()
            {
                Title = "Resident Evil",
                Status = "Disponível",
                Year = 2002,
                ReleaseDate = "01/05/2002",
                cast = { "Mila Javovoich", "Ali Larter", "Ian Glen", "Shawn Roberts" },
                Plot = "O filme se passa em Raccoon City, cidade do meio-oeste em que era sediada a farmacêutica Umbrella Corporation, no ano de 1998.",
                Cover = CoverPath() + "Capa_Resident_Evil_2.jpg"
            };

            Database.RemoveByTitle(movieData.Title); //Depois de definido a massa de teste
            //Eu removo se tiver no banco com esse comando acima. 

            _movie.Add();
            _movie.Save(movieData);
            Thread.Sleep(15000);

            Assert.That(
                _movie.HasMovie(movieData.Title),
            $"Erro ao verificar se o filme {movieData.Title} foi cadastrado."
            );
        }
    }


}