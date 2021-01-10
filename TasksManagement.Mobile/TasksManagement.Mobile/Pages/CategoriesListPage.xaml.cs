using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using TasksManagement.Mobile.Helpers;
using System.Text;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Linq;
using TasksManagement.Mobile.ViewModels;
using TasksManagement.Models;
using TasksManagement.Mobile.Pages;

namespace TasksManagement.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesListPage : ContentPage
    {

        //public ObservableCollection<string> Categories { get; set; }

        public CategoriesListPage()
        {
            InitializeComponent();
            BindingContext = new CategoriesListViewModel();
        }

        protected override void OnAppearing()
        {
            (BindingContext as CategoriesListViewModel)?.InitializeGetCategoriesAsync();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            Category cat = (Category)e.Item;

            await DisplayAlert("Item Tapped", "An item was tapped: " + cat.Name, "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private async void addCategoryBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCategoryPage());
        }
    }
}
