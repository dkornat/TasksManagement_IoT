using System;
using TasksManagement.Mobile.Pages;
using TasksManagement.Mobile.ServicesHandler;
using TasksManagement.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TasksManagement.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TasksListPage : ContentPage
    {
        public TasksListPage()
        {
            InitializeComponent();
            BindingContext = new TasksListViewModel();
        }

        protected override void OnAppearing()
        {
            (BindingContext as TasksListViewModel)?.InitializeGetTasksAsync();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;


            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private async void addTaskBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTaskPage());
        }
    }
}
