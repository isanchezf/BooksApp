namespace BooksApp.ViewModels.Book
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using BooksApp.Views.Book;
    using Xamarin.Forms;
    using BooksApp.ProxyClient;
    using Models;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class BooksViewModel : INotifyPropertyChanged
    {
        #region Atributes
        IList<Book> _books;
        public IList<Book> Books
        {
            get => _books;
            set
            {
                _books = value;
            }
        }
        private readonly BaseClient<Book> _bookContextWs;
        public event PropertyChangedEventHandler PropertyChanged;
        public Command OnAddNewBookCommand { get; }
        public INavigation Navigation { get; set; }

        bool _isBusy;
        public bool IsBusy { get => _isBusy;
            set { _isBusy = value; OnPropertyChanged(); }
        }
        #endregion Atributes

        public BooksViewModel(INavigation navigation, IHttpClient httpClient)
        {
            Books = new ObservableCollection<Book>();
            _bookContextWs = new BaseClient<Book>("Books", httpClient);
            Task.Factory.StartNew(LoadBooks);
            OnAddNewBookCommand = new Command(async () => await AddBook());
            Navigation = navigation;
        }

        public BooksViewModel()
        {
        }


        void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private async Task AddBook()
        {
            await Navigation.PushModalAsync(new AddBookView(_bookContextWs, Books));
        }

        async void LoadBooks()
        {
            IsBusy = true;
            if (Books.Count <= 0)
            {
                var booksResponse = await _bookContextWs.GetAll();
                foreach (var item in booksResponse)
                {
                    Books.Add(item);
                }
            }
            IsBusy = false;
        }
    }
}
