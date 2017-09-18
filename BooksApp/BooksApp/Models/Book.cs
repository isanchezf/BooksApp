namespace BooksApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    public class Book : INotifyPropertyChanged
    {
        int _id;
        public int Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        string _autor;
        public string Autor { get => _autor; set { _autor = value; OnPropertyChanged(); } }
        string _genero;
        public string Genero { get=>_genero; set { _genero = value; OnPropertyChanged(); } }
        string _titulo;
        public string Titulo { get=>_titulo; set { _titulo = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
