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
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace AnualLists.ViewModel
{
    public class SubjectViewModel
    {
        private ObservableCollection<SubjectModel> data { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        public readonly DatabaseContext dbContext;
        private ObservableCollection<SubjectModel> _subjectList { get; set; }
        private int _year;
        private string _subject_name;
        public ICommand FilterButton { get; }
        private Dictionary<string, string> parameters = new Dictionary<string, string>();

        public SubjectViewModel()
        {
            FilterButton = new RelayCommand(FilterSubjects);
            data = new ObservableCollection<SubjectModel>();
            dbContext = new DatabaseContext();
        }

        public void FilterSubjects(object parameter)
        {
            parameters.Clear();
            var list = dbContext.Subjects;
            if (Subject_name != null)
            {
                parameters.Add(nameof(Subject_name), Subject_name);
            }
            var filteredList = Filter.FilterByYearAndParameters(list, Year, parameters);
            SubjectList = new ObservableCollection<SubjectModel>(filteredList.OfType<SubjectModel>());
        }
        public ObservableCollection<SubjectModel> GetData()
        {
            var list = dbContext.Subjects.ToList();
            foreach (var subject in list)
            {
                data.Add(subject);
            }
            return data;
        }
        public ObservableCollection<SubjectModel> SubjectList
        {
            get { return _subjectList; }
            set
            {
                _subjectList = value;
                PropChanged(nameof(SubjectList));
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

        public string Subject_name
        {
            get { return _subject_name; }
            set
            {
                _subject_name = value;
                PropChanged(nameof(Subject_name));
            }
        }
    }
}
