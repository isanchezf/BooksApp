using System.Linq;
using System.Threading.Tasks;
using BooksApp.Views.Book;
using Xamarin.Forms;

namespace BooksApp.ViewModels.Book
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using BooksApp.ProxyClient;
    using Models;

    public class BooksViewModel
    {
        public IList<Book> Books { get; }
        private readonly BaseClient<Book> _bookContextWs;
        public Command OnAddNewBookCommand { get; }
        public INavigation Navigation { get; set; }

        public BooksViewModel(INavigation navigation)
        {
            Books = new ObservableCollection<Book>();
            _bookContextWs = new BaseClient<Book>("Books");
            Task.Factory.StartNew(RechargeBooks);
            OnAddNewBookCommand = new Command(async ()=> await AddBook());
            Navigation = navigation;
        }

        public BooksViewModel()
        {
        }

        private async Task AddBook()
        {
            await Navigation.PushModalAsync(new AddBookView());
        }

        async void RechargeBooks()
        {
            var bookCollection = await _bookContextWs.GetAll();
            foreach (var book in bookCollection)
            {
                if (Books.All(b => b.Id != book.Id))
                    Books.Add(book);
            }
        }
    }
}
