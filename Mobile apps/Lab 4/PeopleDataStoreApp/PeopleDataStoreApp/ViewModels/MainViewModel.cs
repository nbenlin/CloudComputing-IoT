using PeopleDataStoreApp.DataContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Android.Provider.MediaStore;

namespace PeopleDataStoreApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        string name = string.Empty;

        private Person person = new Person();
        private object imgPhoto;
        private readonly IPeopleClient client;


        public string FirstName
        {
            get => person.FirstName;
            set
            {
                if (person.FirstName == value)
                    return;
                person.FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => person.LastName;
            set
            {
                if (person.LastName == value)
                    return;
                person.LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string PhoneNumber
        {
            get => person.PhoneNumber;
            set
            {
                if (person.PhoneNumber == value)
                    return;
                person.PhoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public string PictureBase64
        {
            get => person.PictureBase64;
            set
            {
                if (person.PictureBase64 == value) {
                    return;
                }
                person.PictureBase64 = value;
                OnPropertyChanged(nameof(PictureBase64));
            }
        }

        private async void OnSaveDataClick()
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
                //tbxFirstName.Text = string.Empty;
                //tbxLastName.Text = string.Empty;
                //tbxPhoneNumber.Text = string.Empty;
                imgPhoto.Source = null;
                person = new Person();
            }
        }

        private void DisplayAlert(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }

        private async void OnSaveDataClicked()
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
                imgPhoto.Source = null;
                person = new Person();
            }
        }

        private void Clear()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            PictureBase64 = string.Empty;
            PhoneNumber = string.Empty;
        }

        private bool validate()
        {
            return !(string.IsNullOrWhiteSpace(person.FirstName) ||
                     string.IsNullOrWhiteSpace(person.LastName) ||
                     string.IsNullOrWhiteSpace(person.PhoneNumber) ||
                     string.IsNullOrWhiteSpace(person.PhoneNumber)
                     );
        }

        private async void OnTakePhotoClicked(object sender, EventArgs e)
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
        public string DisplayName => $"Name entered: {FirstName}";

        public event PropertyChangedEventHandler PropertyChanged;   

        void OnPropertyChanged(string value)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(value));
        }
    }
}
