using Microsoft.Extensions.DependencyInjection;
using SimpleNavigationApp.Pages;
using SimpleNavigationApp.Services;
using SimpleNavigationApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleNavigationApp
{
    public class IoC
    {
        private IServiceCollection serviceCollection;
        private IServiceProvider provider;

        public IServiceProvider Provider
        {
            get
            {
                if (provider == null)
                {
                    LoadDependencies();
                    provider = serviceCollection.BuildServiceProvider();
                }

                return provider;
            }
        }

        private void LoadDependencies()
        {
            serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<INavigationService, NavigationService>();
            serviceCollection.AddTransient<MainPage>();
            serviceCollection.AddTransient<ContacPage>();
            serviceCollection.AddTransient<AboutPage>();

            serviceCollection.AddTransient(provider =>
            {
                return new ContactPageViewModel(provider);
            });

            serviceCollection.AddTransient(provider =>
            {
                return new AboutPageViewModel(provider);
            });
        }
    }
}
