using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleNavigationApp.Services
{
    public interface INavigationService
    {
        Task<Page> PopAsync();

        Task<Page> PopAsync(bool animated);

        Task PushAsync(Page page);

        Task PushAsync(Page page, bool animated);
        Task PushModalAsync(Page page);
        Task PushModalAsync(Page page, bool animated);
    }
}
