using PeopleDataStoreApp.DataContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PeopleDataStoreApp
{
    public partial class MainPage : ContentPage
    {
        private readonly IPeopleClient client;
        Person person = new Person();
        public MainPage(IPeopleClient client)
        {
            InitializeComponent();
            this.client = client;
            btnPhoto.Clicked += btnPhoto_Clicked;
            tbxFirstName.TextChanged += tbxFirstName_TextChanged;
            tbxLastName.TextChanged += tbxLastName_TextChanged;
            tbxPhoneNumber.TextChanged += tbxPhoneNumber_TextChanged;
            btnSave.Clicked += btnSave_Clicked;
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            if (!validate())
            {
                await DisplayAlert("Validation Error", "All fields are are required.", "Ok");
                return;
            }

            try
            {
                await client.AddPersonAsync(person);
                await DisplayAlert("Success", "Data has been saved.", "Ok");
                Clear();
            }
            catch (Exception ex)
            {
                tbxFirstName.Text = string.Empty;
                tbxLastName.Text = string.Empty;
                tbxPhoneNumber.Text = string.Empty;
                imgPhoto.Source = null;
                person = new Person();
            }
        }

        private void Clear()
        {
            throw new NotImplementedException();
        }

        private void tbxPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            person.PhoneNumber = e.NewTextValue;
        }

        private void tbxLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            person.LastName = e.NewTextValue;
        }

        private void tbxFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            person.FirstName = e.NewTextValue;
        }

        private async void btnPhoto_Clicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions { });

            if (photo == null)
                return;

            imgPhoto.Source = ImageSource.FromStream(() => photo.GetStream());
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                photo.GetStream().CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            string base64 = Convert.ToBase64String(bytes);
            person.PictureBase64 = base64;
        }

        private bool validate()
        {
            return !(string.IsNullOrWhiteSpace(person.FirstName) ||
                     string.IsNullOrWhiteSpace(person.LastName) ||
                     string.IsNullOrWhiteSpace(person.PhoneNumber) ||
                     string.IsNullOrWhiteSpace(person.PhoneNumber) 
                     );
        }
    }
}
