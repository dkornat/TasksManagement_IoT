using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManagement.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TasksManagement.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTaskPage : ContentPage
    {
        public AddTaskPage()
        {
            InitializeComponent();
            var addTaskViewModel = new AddTaskViewModel(Navigation);
            addTaskViewModel.Task.Start = DateTime.Today;
            addTaskViewModel.Task.End = DateTime.Today;
            BindingContext = addTaskViewModel;
        }

    }
}