using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TasksManagement.MobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void TasksListOnClicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TasksListPage());
        }
    }
}
