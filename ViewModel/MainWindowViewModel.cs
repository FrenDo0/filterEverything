using AnualLists.Commands;
using AnualLists.Helper;
using AnualLists.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace AnualLists.ViewModel
{
    public class MainWindowViewModel : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        
       
        public MainWindowViewModel()
        {
           
        }

      
    }
}
