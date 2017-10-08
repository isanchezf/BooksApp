﻿using BooksApp.ProxyClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BooksApp
{
    public partial class App : Application
    {
        public App(IHttpClient httpClient)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.Book.BooksView(httpClient));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
