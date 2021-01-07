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
            Task.StatusId = 1;
            AddTaskCommand = new Command(AddTask);
            InitializeGetCategoriesAsync();
            InitializeGetStatusesAsync();
        }
        public INavigation Navigation { get; set; }
        public ICommand AddTaskCommand { get; private set; }

        CategoryServices _categoryServices = new CategoryServices();
        TaskServices _taskServices = new TaskServices();
        StatusServices _statusServices = new StatusServices();

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

        private IList<Status> _statuses;
        public IList<Status> Statuses
        {
            get
            {
                return this._statuses;
            }
            set
            {
                this._statuses = value;
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

        private bool _isBusy;

        public event PropertyChangedEventHandler PropertyChanged;

        private async void AddTask()
        {
            this.Task.CreatedOn = DateTime.Now;
            this.Task.CategoryId = Task.Category?.Id;
            this.Task.StatusId = Task.Status?.Id;
            this.Task.Category = null;
            this.Task.Status = null;
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
                IsBusy = true;
                var items = await _categoryServices.GetAllCategories();
                Categories = new ObservableCollection<Models.Category>(items);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async System.Threading.Tasks.Task InitializeGetStatusesAsync()
        {
            try
            {
                IsBusy = true;
                var items = await _statusServices.GetAllStatuses();
                Statuses = new ObservableCollection<Models.Status>(items);
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
