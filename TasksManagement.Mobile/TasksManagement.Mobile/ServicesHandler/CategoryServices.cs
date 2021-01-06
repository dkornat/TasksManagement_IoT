using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksManagement.Mobile.Helpers;
using TasksManagement.Models;

namespace TasksManagement.Mobile.ServicesHandler
{
    public class CategoryServices
    {
        RestClient.TasksManagementClient<Category> _rest = new RestClient.TasksManagementClient<Category>();
        private readonly string _categoriesUri = Secrets.CategoriesURI;

        public async Task<IList<Category>> GetAllCategories()
        {
            var categories = await _rest.GetAllItems(_categoriesUri);
            return categories.ToList();
        }
    }
}
