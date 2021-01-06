using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using TasksManagement.Mobile.ServicesHandler;
using TasksManagement.Models;
using Xamarin.Forms;

namespace TasksManagement.Mobile.ViewModels
{
    public class CreateTaskViewModel
    {
        public CreateTaskViewModel()
        {
            InitializeGetCategoriesAsync();
        }
        public ICommand AddTaskCommand => new Command(AddTask);

        public string Test { get; set; }

        CategoryServices _services = new CategoryServices();
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get
            {
                return this._categories;
            }
            set
            {
                this._categories = value;
                NotifyPropertyChanged();
            }
        }
        private string _title;
        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
                NotifyPropertyChanged();
            }
        }
        private async System.Threading.Tasks.Task InitializeGetCategoriesAsync()
        {
            try
            {
                IsBusy = true; // set the ui property "IsRunning" to true(loading) in Xaml ActivityIndicator Control
                var items = await _services.GetAllCategories();
                Categories = new ObservableCollection<Category>(items);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private  void AddTask()
        {
            Test = Test.ToUpper();
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                NotifyPropertyChanged();
            }
        }
    }
}
