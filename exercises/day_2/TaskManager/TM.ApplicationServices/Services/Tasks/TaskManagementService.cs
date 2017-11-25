using System;
using System.Collections.Generic;
using TM.ApplicationServices.ViewModels.Tasks;
using TM.Data.Entities;

namespace TM.ApplicationServices.Services.Tasks
{
    public class TaskManagementService : BaseService
    {
        #region Public Methods
        public List<TaskVM> GetAll()
        {
            List<TaskVM> allTaskVMs = new List<TaskVM>();

            try
            {
                foreach (var task in _unitOfWork.Tasks.GetAll())
                {
                    allTaskVMs.Add(new TaskVM
                    {
                        Id = task.Id,
                        Name = task.Name,
                        Description = task.Description,
                        StartedBy = task.StartedBy.Value,
                        StartedOn = task.StartedOn,
                        EndedOn = task.EndedOn
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            return allTaskVMs;
        }

        public TaskVM GetById(int id)
        {
            TaskVM taskVM = null;

            try
            {
                var task = _unitOfWork.Tasks.GetById(id);
                taskVM = new TaskVM
                {
                    Id = task.Id,
                    Name = task.Name
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            return taskVM;
        }

        public TaskVM Save(TaskVM taskVM)
        {
            try
            {
                var task = new Task
                {
                    Id = taskVM.Id,
                    Name = taskVM.Name,
                    StartedBy = taskVM.StartedBy,
                    StartedOn = taskVM.StartedOn,
                    EndedOn = taskVM.EndedOn
                };
                _unitOfWork.Tasks.Save(task);
                _unitOfWork.SaveChanges();

                return new TaskVM
                {
                    Id = task.Id,
                    Name = task.Name,
                    StartedBy = task.StartedBy.Value,
                    StartedOn = task.StartedOn,
                    EndedOn = task.EndedOn
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public int Delete(int id)
        {
            try
            {
                _unitOfWork.Tasks.Delete(id);
                _unitOfWork.SaveChanges();

                return id;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return -1;
            }

        }
        #endregion
    }
}
