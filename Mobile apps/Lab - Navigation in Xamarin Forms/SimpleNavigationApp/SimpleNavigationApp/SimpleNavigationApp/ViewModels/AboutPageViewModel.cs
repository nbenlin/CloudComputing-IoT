using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
using SimpleNavigationApp.Services;
using SimpleNavigationApp.Pages;

namespace SimpleNavigationApp.ViewModels
{
    public class AboutPageViewModel
    {
        private readonly IServiceProvider provider;
        public AboutPageViewModel(IServiceProvider provider)
        {
            this.provider = provider;
        }
        public ICommand NavigateToContact
        {
            get => new Command(async () =>
            {
                await provider.GetService<INavigationService>().PushAsync(provider.GetService<ContacPage>());
            });
        }
    }
}
