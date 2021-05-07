using PeopleDataStoreApp.DataContracts;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PeopleDataStoreApp
{
    public partial class App : Application
    {
        private const string API_URL = "http://192.168.1.66:5000/api";
        public App()
        {
            InitializeComponent();

            var client = RestEase.RestClient.For<IPeopleClient>(API_URL);

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
