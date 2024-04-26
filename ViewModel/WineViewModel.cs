using AnualLists.Commands;
using AnualLists.Database;
using AnualLists.Helper;
using AnualLists.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnualLists.ViewModel
{
    public class WineViewModel
    {
        private ObservableCollection<WineModel> data { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        public readonly DatabaseContext dbContext;
        private Dictionary<string, string> parameters = new Dictionary<string, string>();
        private ObservableCollection<WineModel> _wineList { get; set; }
        private int _year;
        private string _name;
        private string _variety;
        private string _vineyard;
        private string _productionSize;
        public ICommand FilterButton { get; }
        public WineViewModel()
        {
            FilterButton = new RelayCommand(FilterWines);
            data = new ObservableCollection<WineModel>();
            dbContext = new DatabaseContext();
        }
        public void FilterWines(object parameter)
        {
            parameters.Clear();
            var list = dbContext.Wine;
            if (Name != null)
            {
                parameters.Add(nameof(Name), Name);
            }
            if (Variety != null)
            {
                parameters.Add(nameof(Variety), Variety);
            }
            if (Vineyard != null)
            {
                parameters.Add(nameof(Vineyard), Vineyard);
            }
            var filteredList = Filter.FilterByYearAndParameters(list, Year, parameters);
            WineList = new ObservableCollection<WineModel>(filteredList.OfType<WineModel>());
        }
        public ObservableCollection<WineModel> GetData()
        {
            var list = dbContext.Wine.ToList();
            foreach (var wine in list)
            {
                data.Add(wine);
            }
            return data;
        }

        public ObservableCollection<WineModel> WineList
        {
            get { return _wineList; }
            set
            {
                _wineList = value;
                PropChanged(nameof(WineList));
            }
        }


        public void PropChanged(String propertyName)
        {
            //Did WPF registerd to listen to this event
            if (PropertyChanged != null)
            {
                //Tell WPF that this property changed
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public int Year
        {
            get { return _year; }
            set
            {
                _year = value;
                PropChanged(nameof(Year));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                PropChanged(nameof(Name));
            }
        }
        public string Variety
        {
            get { return _variety; }
            set
            {
                _variety = value;
                PropChanged(nameof(Variety));
            }
        }
        public string Vineyard
        {
            get { return _vineyard; }
            set
            {
                _vineyard = value;
                PropChanged(nameof(Vineyard));
            }
        }
        public string ProductionSize
        {
            get { return _productionSize; }
            set
            {
                _productionSize = value;
                PropChanged(nameof(ProductionSize));
            }
        }
    }
}
