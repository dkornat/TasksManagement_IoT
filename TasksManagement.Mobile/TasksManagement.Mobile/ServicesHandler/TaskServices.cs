using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TasksManagement.Mobile.Helpers;

namespace TasksManagement.Mobile.ServicesHandler
{
    public class TaskServices
    {
        RestClient.TasksManagementClient<Models.Task> _rest = new RestClient.TasksManagementClient<Models.Task>();
        private readonly string _tasksUri = Secrets.TasksURI;

        public async Task<IEnumerable<Models.Task>> GetAllTasks(int? statusId)
        {
            string statusQuery = statusId != null ? $"/{statusId}" : "/0";
            var tasks = await _rest.GetAllItems(_tasksUri + statusQuery);
            return tasks;
        }

        public async Task<bool> AddTask(Models.Task task)
        {
            var createdTask = await _rest.CreateObject(task, _tasksUri);
            return true;
        }

        public async Task<bool> CloseTask(Models.Task task)
        {
            try
            {
                task.StatusId = 2;
                var updatedTask = await _rest.UpdateObject(task, _tasksUri + "/" + task.Id);
                if (updatedTask != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
