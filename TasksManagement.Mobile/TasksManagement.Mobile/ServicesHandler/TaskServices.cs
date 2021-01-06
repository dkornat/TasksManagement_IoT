using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TasksManagement.Mobile.Helpers;
using TasksManagement.Models;

namespace TasksManagement.Mobile.ServicesHandler
{
    public class TaskServices
    {
        RestClient.TasksManagementClient<Models.Task> _rest = new RestClient.TasksManagementClient<Models.Task>();
        private readonly string _tasksUri = Secrets.TasksURI;

        public async Task<IEnumerable<Models.Task>> GetAllTasks()
        {
            var tasks = await _rest.GetAllItems(_tasksUri);
            return tasks;
        }

        public async Task<bool> AddTask(Models.Task task)
        {
            var createdTask = await _rest.CreateObject(task, _tasksUri);
            return true;
        }
    }
}
