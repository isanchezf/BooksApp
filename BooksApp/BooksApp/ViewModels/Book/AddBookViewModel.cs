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

    public class AddBookViewModel
    {
        private BaseClient<Book> _bookContextWs;
        private IList<Book> _books;
        public Book BookEntity { get; set; }
        public Command AddBookCommand { get; }
        public INavigation Navigation { get; set; }

        public AddBookViewModel(BaseClient<Book> bookContextWs, IList<Book> books, INavigation navigation)
        {
            _bookContextWs = bookContextWs;
            _books = books;
            BookEntity = new Book();
            AddBookCommand = new Command(async () => await AddBook());
            Navigation = navigation;
        }

        private async Task AddBook()
        {
            BookEntity = await _bookContextWs.Add(BookEntity);
            _books.Add(BookEntity);
            await Navigation.PopModalAsync();
        }
    }
}
