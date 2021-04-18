using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Cars_MVVM.Model;
using Cars_MVVM.View.ViewModel;

namespace Cars_MVVM.ViewModel
{
    public class CarViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Cars> Cars { get; set; }
        public ObservableCollection<Coffee> Coffees { get; set; }

        private string searchText = string.Empty;
        public string SearchText
        {
            get { return searchText; }
            set { searchText = value; OnPropertyChanged(SearchText); }
        }

        private RelayCommand findCommand;
        public RelayCommand FindCommand
        {
            get
            {
                return findCommand ?? (findCommand = new RelayCommand(act =>
                {
                    if (SearchText == string.Empty)
                        //this.foundCars = this.Cars;
                        this.Cars = new ObservableCollection<Cars>(Find(i => i.Company.Length > 0));
                    else
                    {
                        this.Cars = new ObservableCollection<Cars>(Find(i => i.Company.ToLower().Contains(searchText.ToLower())));
                        OnPropertyChanged("Cars");
                    }
                }
                ));
            }
        }

        IEnumerable<Cars> Find(Func<Cars, bool> filter) => Cars.Where(filter).ToList();

        public CarViewModel()
        {
            //this.Cars = new ObservableCollection<Cars>()
            //{
            //    new Cars() {Company = "Honda", Model = "Civic 4d", Engine_volume = 1800, Consumption = 7.5, Release = new DateTime(},
            //    new Cars() {Company = "Honda", Model = "Accord 7", Engine_volume = 1500, Consumption = 6.5, Release = "2012 - 2015"},
            //    new Cars() {Company = "VW", Model = "Jetta 7", Engine_volume = 2000, Consumption = 9, Release = "2015 - 2020"}
            //};
            using (CarModel carModel = new CarModel())
            {
                //this.Cars = new ObservableCollection<Cars>(carModel.Cars.ToList());
                this.Cars = new ObservableCollection<Cars>(carModel.Cars);
            }

            using (CoffeeModel coffeeModel = new CoffeeModel())
            {
                this.Coffees = new ObservableCollection<Coffee>(coffeeModel.Coffees);
            }
        }

        private Cars selectedCar;

        public Cars SelectedCar
        {
            get { return selectedCar; }
            set { selectedCar = value; OnPropertyChanged("SelectedCar"); }
        }

        private Coffee selectedCoffee;

        public Coffee SelectedCoffee
        {
            get { return selectedCoffee; }
            set { selectedCoffee = value; OnPropertyChanged("SelectedCoffee"); }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
