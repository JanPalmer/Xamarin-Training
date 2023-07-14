using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XFormsAppTutorial.Models;
using XFormsAppTutorial.Types;

namespace XFormsAppTutorial.ViewModels
{
    class AddCoffeeViewModel : BindableObject
    {
        public string title { get; set; }
        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
                IsButtonEnabled();
            }
        }

        private string description;
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged();

            }
        }
        public bool isValid { get; set; } = false;
        public ObservableCollection<CoffeeType> Coffee { get; }
        public Command AddCoffeeCommand { get; }
        public AddCoffeeViewModel()
        {
            title = "Say hello to my little coffee!";
            AddCoffeeCommand = new Command(AddCoffee);
            Coffee = CoffeeProvider.coffees;
        }
        public void IsButtonEnabled()
        {
            if(name != null && name != string.Empty)
                isValid = true;
            else
                isValid = false;

            OnPropertyChanged();
        }
        private async void AddCoffee()
        {
            Coffee.Add(new CoffeeType(name, description));
            await Shell.Current.GoToAsync("..");
        }
    }
}
