using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TM.ApplicationServices.Interface;
using TM.ApplicationServices.Massaging.Tasks;
using TM.ApplicationServices.ViewModels;
using TM.Data.Entities;
using TM.Repositories.Interface;

namespace TM.ApplicationServices.Implementation
{
    public class TaskManagementService : ServiceBase, ITaskManagementService
    {
        private readonly ILogger<TaskManagementService> _logger;
        public TaskManagementService(IUnitOfWork unitOfWork, ILogger<TaskManagementService> logger) : base(unitOfWork) 
        {
            _logger = logger;
        }

        public GetTasksResponse GetAll()
        {
            _logger.LogInformation("Method Task/GetAll is trigger");
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
                _logger.LogError(ex.Message);
                getTasksResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                getTasksResponse.StatusDescription = ex.Message;
            }

            return getTasksResponse;
        }

        public InsertTaskResponse Insert(InsertTaskRequest insertTaskRequest)
        {
            _logger.LogInformation("Method Task/Insert is trigger");
            InsertTaskResponse insertTaskResponse = new InsertTaskResponse();
            try
            {
                Task task = new Task
                {
                    Title = insertTaskRequest.TaskProperties.Title,
                    Description = insertTaskRequest.TaskProperties.Description,
                    StartedOn = insertTaskRequest.TaskProperties.StartedOn,
                    EndedOn = insertTaskRequest.TaskProperties.EndedOn
                };
                _unitOfWork.Tasks.Save(task);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                insertTaskResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                insertTaskResponse.StatusDescription = ex.Message;
            }

            return insertTaskResponse;
        }
    }
}
