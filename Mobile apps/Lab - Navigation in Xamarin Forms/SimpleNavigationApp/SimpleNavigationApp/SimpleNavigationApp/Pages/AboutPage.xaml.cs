using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleNavigationApp.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleNavigationApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void btnContact_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContacPage(), animated: true);
        }
    }
}