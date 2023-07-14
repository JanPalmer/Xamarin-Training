using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFormsAppTutorial.Models;
using XFormsAppTutorial.Types;
using XFormsAppTutorial.Views;

namespace XFormsAppTutorial.ViewModels
{
    public class CoffeeEquipmentViewModel : BindableObject
    {
        public ObservableCollection<CoffeeType> Coffee { get; }
        public bool IsBusy { get; set; } = false;
        public ICommand IncreaseCount { get; }
        public Command<CoffeeType> SelectFavourite { get; }
        public ICommand RefreshCommand { get; }
        public ICommand AddCommand { get; }       

        public CoffeeEquipmentViewModel() 
        {
            IncreaseCount = new Command(OnIncrease);
            SelectFavourite = new Command<CoffeeType>(Favourite);
            RefreshCommand = new Command(Refresh);
            AddCommand = new Command(AddCoffee);
            Coffee = CoffeeProvider.coffees;
            InitCoffee();
        }

        private void InitCoffee()
        {
            var items = new List<CoffeeType> { 
                new CoffeeType("Tchibo", "Coffee description"),
                new CoffeeType("Tchibo", "Coffee description"),
                new CoffeeType("Tchibo", "Coffee description"),
                new CoffeeType("Latte", "Coffee description"),
                new CoffeeType("Black", "Coffee description"),
                new CoffeeType("Inka", "Coffee description"),
                new CoffeeType("Nescafe", "Coffee description"),
                new CoffeeType("Nescafe", "Coffee description"),
                new CoffeeType("Nescafe", "Coffee description")
            };
            foreach(var item in items)
            {
                Coffee.Add(item);
            }
        }

        private int count = 0;
        private string _countDisplay = "Clickity clack";
        public string CountDisplay
        {
            get => _countDisplay;
            set
            {
                if (value == _countDisplay)
                    return;
                _countDisplay = value;
                OnPropertyChanged();
            }
        }

        private void OnIncrease(object obj)
        {
            //var button = sender as Button;            
            count++;
            CountDisplay = $"Clicked {count} time(s).";
        }

        private async void Favourite(CoffeeType coffee)
        {
            if(coffee == null)
                return;

            await Application.Current.MainPage.DisplayAlert("Favourite", coffee.Name, "OK");
        }

        CoffeeType selectedCoffee;
        public CoffeeType SelectedCoffee
        {
            get => selectedCoffee;
            set
            {
                if(value != null)
                {
                    Application.Current.MainPage.DisplayAlert("Selected", value.Name, "OK");
                    value = null;
                }
                selectedCoffee = value;
                OnPropertyChanged();
            }
        }

        private async void Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            Coffee.Clear();
            InitCoffee();

            IsBusy = false;
            OnPropertyChanged(nameof(IsBusy));
        }
        private async void AddCoffee()
        {
            var route = $"{nameof(AddCoffeePage)}";
            await Shell.Current.GoToAsync(route);
        }
    }
}
