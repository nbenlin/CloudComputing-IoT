using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleNavigationApp.Services
{
    public class NavigationService : INavigationService
    {
        public Task<Page> PopAsync()
        {
            return Application.Current.MainPage.Navigation.PopAsync();
        }

        public Task<Page> PopAsync(bool animated)
        {
            return Application.Current.MainPage.Navigation.PopAsync(animated);
        }

        public Task PushAsync(Page page)
        {
            return Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public Task PushAsync(Page page, bool animated)
        {
            return Application.Current.MainPage.Navigation.PushAsync(page, animated);
        }

        public Task PushModalAsync(Page page)
        {
            return Application.Current.MainPage.Navigation.PushModalAsync(page);
        }

        public Task PushModalAsync(Page page, bool animated)
        {
            return Application.Current.MainPage.Navigation.PushModalAsync(page, animated);
        }
    }
}
