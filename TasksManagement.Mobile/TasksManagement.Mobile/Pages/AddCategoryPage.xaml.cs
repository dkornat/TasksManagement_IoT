using TasksManagement.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TasksManagement.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCategoryPage : ContentPage
    {
        public AddCategoryPage()
        {
            InitializeComponent();
            BindingContext = new AddCategoryViewModel(this.Navigation);
        }
    }
}