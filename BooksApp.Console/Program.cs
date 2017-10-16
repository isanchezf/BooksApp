using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApp.Models;
using BooksApp.ResilientHttp.ResilienceHttp;
using BooksApp.ProxyClient;

namespace BooksApp.Console
{
    class Program
    {
        private static BaseClient<Book> _bookContextWs;

        static void Main(string[] args)
        {
            _bookContextWs = new BaseClient<Book>("Books", new ResilientHttpClientFactory().CreateResilientHttpClient());
            var respuesta = Task.Factory.StartNew(async ()=> await _bookContextWs.GetAll()).Result.Result.ToList();
        }
    }
}
