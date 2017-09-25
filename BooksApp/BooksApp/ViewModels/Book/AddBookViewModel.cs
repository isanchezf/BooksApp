using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BooksApp.ViewModels.Book
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ProxyClient;
    using Models;
    using Xamarin.Forms;

    public class AddBookViewModel : INotifyPropertyChanged
    {
        #region "Attributes"
        private readonly BaseClient<Book> _bookContextWs;
        private readonly IList<Book> _books;
        private Book _bookEntity;
        #endregion "Attributes"

        #region Constructors
        public AddBookViewModel(BaseClient<Book> bookContextWs, IList<Book> books, INavigation navigation)
        {
            _bookContextWs = bookContextWs;
            _books = books;
            AddBookCommand = new Command(async () => await AddBook());
            Navigation = navigation;
        }
        #endregion Constructors

        #region "Properties"
        public Command AddBookCommand { get; }
        public INavigation Navigation { get; set; }
        private string _autor;
        public string Autor { get => _autor; set { _autor = value; OnPropertyChanged(); } }
        private string _genero;
        public string Genero { get => _genero; set { _genero = value; OnPropertyChanged(); } }
        private string _titulo;
        public string Titulo
        {
            get => _titulo;
            set
            {
                _titulo = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        
        public bool IsValidForm => (IsValidTitle && IsValidGenre);
        
        private bool _isValidTitle;
        public bool IsValidTitle
        {
            get => _isValidTitle;
            set
            {
                _isValidTitle = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsValidForm));
            }
        }

        private bool _isValidGenre;
        public bool IsValidGenre
        {
            get => _isValidGenre;
            set
            {
                _isValidGenre = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsValidForm));
            }
        }

        bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set { _isBusy = value; OnPropertyChanged(); }
        }
        #endregion "Properties"

        #region Private Methods
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private async Task AddBook()
        {
            IsBusy = true;
            _bookEntity = new Book() { Autor = Autor, Genero = Genero, Titulo = Titulo };
            _bookEntity = await _bookContextWs.Add(_bookEntity);
            _books.Add(_bookEntity);
            IsBusy = false;
            await Navigation.PopModalAsync();
        }
        #endregion Private Methods
    }
}
