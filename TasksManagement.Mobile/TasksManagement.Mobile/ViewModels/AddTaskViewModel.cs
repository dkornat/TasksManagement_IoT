using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using TasksManagement.Mobile.ServicesHandler;
using TasksManagement.Models;
using Xamarin.Forms;

namespace TasksManagement.Mobile.ViewModels
{
    public class AddTaskViewModel : INotifyPropertyChanged
    {
        public AddTaskViewModel()
        {
            Task = new Models.Task();
            AddTaskCommand = new Command(AddTask);
            InitializeGetCategoriesAsync();
        }
        public AddTaskViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Task = new Models.Task();
            AddTaskCommand = new Command(AddTask);
            InitializeGetCategoriesAsync();
        }
        public INavigation Navigation { get; set; }
        public ICommand AddTaskCommand { get; private set; }
        CategoryServices _categoryServices = new CategoryServices();
        TaskServices _taskServices = new TaskServices();
        private IList<Category> _categories;
        public IList<Category> Categories
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

        private Models.Task _task;
        public Models.Task Task
        {
            get
            {
                return this._task;
            }
            set
            {
                this._task = value;
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

        private string _description;
        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
                NotifyPropertyChanged();
            }
        }

        private DateTime _start;
        public DateTime Start
        {
            get
            {
                return this._start;
            }
            set
            {
                this._start = value;
                NotifyPropertyChanged();
            }
        }

        private DateTime _end;
        public DateTime End
        {
            get
            {
                return this._end;
            }
            set
            {
                this._end = value;
                NotifyPropertyChanged();
            }
        }

        private Category _category;
        public Category Category
        {
            get
            {
                return this._category;
            }
            set
            {
                this._category = value;
                NotifyPropertyChanged();
            }
        }

        private bool _isBusy;

        public event PropertyChangedEventHandler PropertyChanged;

        private async void AddTask()
        {
            await _taskServices.AddTask(this.Task);
            await Navigation.PopAsync();
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                NotifyPropertyChanged();
            }
        }

        private async System.Threading.Tasks.Task InitializeGetCategoriesAsync()
        {
            try
            {
                IsBusy = true; // set the ui property "IsRunning" to true(loading) in Xaml ActivityIndicator Control
                var items = await _categoryServices.GetAllCategories();
                Categories = new ObservableCollection<Models.Category>(items);
            }
            finally
            {
                IsBusy = false;
            }
        }
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
