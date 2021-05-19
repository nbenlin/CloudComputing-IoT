using MVVMApplication.Mobile.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMApplication.Mobile.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private readonly PeopleDb peopleDb;

        public MainPageViewModel()
        {
            peopleDb = new PeopleDb(Constants.DatabasePath);
            var people = peopleDb.GetPeople();
            if (people.Any())
            {
                var lastRecord = people.OrderByDescending(by => by.PersonId).First();
                firstName = lastRecord.FirstName;
                lastName = lastRecord.LastName;
            }
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName == value) return;
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (lastName == value) return;
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand SaveDataCommand
        {
            get => new Command(SaveData);
        }

        private async void SaveData()
        {
            try
            {
                peopleDb.AddPerson(firstName, lastName);
                await Application.Current.MainPage.DisplayAlert("Success", "Data saved" ,"Ok");
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", e.Message, "Ok");
            }
        }
    }
}
