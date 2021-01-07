using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TasksManagement.Mobile.ServicesHandler;
using TasksManagement.Models;
using Xamarin.Forms;

namespace TasksManagement.Mobile.ViewModels
{
    class TasksListViewModel : INotifyPropertyChanged
    {
        public TasksListViewModel()
        {
            CloseTaskCommand = new Command(CloseTask);
            InitializeGetStatusesAsync();
        }

        TaskServices _taskServices = new TaskServices();
        StatusServices _statusServices = new StatusServices();

        public ICommand CloseTaskCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
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


        private Status _statusToShow;
        public Status StatusToShow
        {
            get { return _statusToShow; }
            set
            {
                _statusToShow = value;
                NotifyPropertyChanged();
                InitializeGetTasksAsync();
            }
        }

        private Object _selectedTask;
        public Object SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                NotifyPropertyChanged();
            }
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
        private async System.Threading.Tasks.Task InitializeGetTasksAsync()
        {
            try
            {
                IsBusy = true; 
                var items = await _taskServices.GetAllTasks(this.StatusToShow.Id);
                Tasks = new ObservableCollection<Models.Task>(items);
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

                Status defaultStatus = new Status()
                {
                    Id = 0,
                    Name = "Wszystkie"
                };
                Statuses.Add(defaultStatus);
                StatusToShow = defaultStatus;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void CloseTask()
        {
            await _taskServices.CloseTask((Models.Task)SelectedTask);
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
