using System;
using System.Collections.Generic;
using TM.ApplicationServices.ViewModels;
using TM.Data.Entities;
using TM.Repositories.Implementations;

namespace TM.ApplicationServices.Services.Tasks
{
    public class TaskManagementService : BaseService
    {
        #region public Methods
        public List<TaskVM> GetAll()
        {
            List<TaskVM> allTaskVMs = new List<TaskVM>();

            try
            {
                using (UnitOfWork _unitOfWork = new UnitOfWork())
                {
                    foreach (var task in _unitOfWork.Tasks.GetAll())
                    {
                        allTaskVMs.Add(new TaskVM(task));
                    }
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
            TaskVM TaskVM = null;

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    TaskVM = new TaskVM(unitOfWork.Tasks.GetById(id));
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            return TaskVM;
        }

        public TaskVM Save(TaskVM taskVM)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Task task = new Task {
                        Id = taskVM.Id,
                        Name = taskVM.Name,
                        Description = taskVM.Description,
                        StartedOn = taskVM.StartedOn,
                        EndedOn = taskVM.EndedOn,
                        IsActive = taskVM.IsActive
                    };
                    unitOfWork.Tasks.Save(task);
                    unitOfWork.SaveChanges();

                    return new TaskVM(task);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public int Delete(int id)
        {
            try {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.Tasks.Delete(id);
                    unitOfWork.SaveChanges();

                    return id;
                }
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
