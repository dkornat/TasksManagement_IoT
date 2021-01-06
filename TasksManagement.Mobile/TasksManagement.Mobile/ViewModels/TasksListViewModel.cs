using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TasksManagement.Mobile.ServicesHandler;

namespace TasksManagement.Mobile.ViewModels
{
    class TasksListViewModel : INotifyPropertyChanged
    {
        public TasksListViewModel()
        {
            InitializeGetTasksAsync();
        }
        TaskServices _services = new TaskServices();
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Models.Task> _tasks;
        public ObservableCollection<Models.Task> Tasks { 
            get 
            {
                return this._tasks;
            }
            set
            {
                this._tasks = value;
                NotifyPropertyChanged();
            }
        }
        private async Task InitializeGetTasksAsync()
        {
            try
            {
                IsBusy = true; // set the ui property "IsRunning" to true(loading) in Xaml ActivityIndicator Control
                var items = await _services.GetAllTasks();
                Tasks = new ObservableCollection<Models.Task>(items);
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
