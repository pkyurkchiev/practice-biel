using System;
using System.Collections.Generic;
using System.Text;
using TM.ApplicationServices.Interface;
using TM.ApplicationServices.Massaging.Tasks;
using TM.ApplicationServices.ViewModels;
using TM.Repositories.Interface;

namespace TM.ApplicationServices.Implementation
{
    public class TaskManagementService : ServiceBase, ITaskManagementService
    {
        public TaskManagementService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public GetTasksResponse GetAll()
        {
            GetTasksResponse getTasksResponse = new GetTasksResponse();
            List<TaskViewModel> listTaskViewModel = new List<TaskViewModel>();

            try
            {
                var allTasks = _unitOfWork.Tasks.GetAll();
                foreach (var item in allTasks)
                {
                    listTaskViewModel.Add(new TaskViewModel
                    {
                        Title = item.Title,
                        Description = item.Description,
                        StartedOn = item.StartedOn,
                        EndedOn = item.EndedOn
                    });
                }
                getTasksResponse.Tasks = listTaskViewModel;
            }
            catch (Exception ex)
            {
                getTasksResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                getTasksResponse.StatusDescription = ex.Message;
            }

            return getTasksResponse;
        }
    }
}
