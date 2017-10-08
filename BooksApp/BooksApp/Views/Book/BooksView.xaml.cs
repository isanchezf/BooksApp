using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApp.ViewModels.Book;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BooksApp.ProxyClient;

namespace BooksApp.Views.Book
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BooksView : ContentPage
    {
        public BooksViewModel BooksViewModelContext { get; }

        public BooksView(IHttpClient httpClient)
        {
            BooksViewModelContext = new BooksViewModel(Navigation, httpClient);
            BindingContext = BooksViewModelContext;
            InitializeComponent();
        }
    }
}