using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TasksManagement.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void categoriesListBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CategoriesListPage());
        }

        private async void tasksListBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TasksListPage());
        }
    }
}
