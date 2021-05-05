using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using SimpleNavigationApp.Services;
using SimpleNavigationApp.Pages;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleNavigationApp.ViewModels
{
    public class MainPageViewModel
    {
        private readonly IServiceProvider provider;
        public MainPageViewModel(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public ICommand NavigateToAbout
        {
            get => new Command(async () =>
            {
                await provider
                .GetService<INavigationService>()
                .PushAsync(provider.GetService<AboutPage>());
            });
        }
    }
}
