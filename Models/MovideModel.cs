using System.Collections.Generic;

namespace NinjaPlus.Models
{
    public class MovieModel //Definir nossa massa de dados
    {
        public string Title { get; set; }

        public string Status { get; set; }

        public int Year { get; set; }

        public string ReleaseDate { get; set; }

        public List<string> cast = new List<string>(); //array lista de srtings

        public string Plot { get; set; }

        public string Cover { get; set; }

    }

}