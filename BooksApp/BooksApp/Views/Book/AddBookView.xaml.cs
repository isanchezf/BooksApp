namespace BooksApp.Views.Book
{
    using BooksApp.ProxyClient;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using Models;
    using System.Collections.Generic;
    using BooksApp.ViewModels.Book;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddBookView : ContentPage
    {
        private AddBookViewModel AddBookViewModelContext { get; }

        public AddBookView(BaseClient<Book> bookContextWs, IList<Book> books)
        {
            AddBookViewModelContext = new AddBookViewModel(bookContextWs, books, Navigation);
            BindingContext = AddBookViewModelContext;
            InitializeComponent();
        }
    }
}