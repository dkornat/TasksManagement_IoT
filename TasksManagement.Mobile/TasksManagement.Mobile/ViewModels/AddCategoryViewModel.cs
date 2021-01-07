using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TasksManagement.Mobile.ServicesHandler;
using TasksManagement.Models;
using Xamarin.Forms;

namespace TasksManagement.Mobile.ViewModels
{
    public class AddCategoryViewModel
    {
        public Category Category { get; set; }
        private CategoryServices _categoryServices = new CategoryServices();
        public ICommand AddCategoryCommand { get; private set; }
        public INavigation Navigation { get; set; }
        public AddCategoryViewModel()
        {
            Category = new Category();
            AddCategoryCommand = new Command(AddCategory);
        }

        public AddCategoryViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Category = new Category();
            AddCategoryCommand = new Command(AddCategory);
        }
        private async void AddCategory()
        {
            await _categoryServices.AddCategory(Category);
            await Navigation.PopAsync();
        }
    }
}
