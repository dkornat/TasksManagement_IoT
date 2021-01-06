using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using TasksManagement.Mobile.ServicesHandler;
using System.Runtime.CompilerServices;
using TasksManagement.Models;

namespace TasksManagement.Mobile.ViewModels
{
    class CategoriesListViewModel : INotifyPropertyChanged
    {
        public CategoriesListViewModel()
        {
            InitializeGetCategoriesAsync();
        }

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
