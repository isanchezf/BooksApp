namespace BooksApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Book
    {
        public int Id { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public string Titulo { get; set; }
    }
}
