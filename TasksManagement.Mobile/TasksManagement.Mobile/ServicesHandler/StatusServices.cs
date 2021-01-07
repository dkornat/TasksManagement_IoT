using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TasksManagement.Mobile.Helpers;
using TasksManagement.Models;

namespace TasksManagement.Mobile.ServicesHandler
{
    public class StatusServices
    {
        RestClient.TasksManagementClient<Status> _rest = new RestClient.TasksManagementClient<Status>();
        private readonly string _statusesUri = Secrets.StatusesURI;

        public async Task<IEnumerable<Status>> GetAllStatuses()
        {
            var tasks = await _rest.GetAllItems(_statusesUri);
            return tasks;
        }
    }
}
