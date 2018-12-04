using System;
using System.Collections.Generic;
using TM.ApplicationServices.ViewModels;
using TM.Data.Entities;
using TM.Repositories.Implementations;

namespace TM.ApplicationServices.Services.Users
{
    public class UserManagementService : BaseService
    {
        #region public Methods
        public List<UserVM> GetAll()
        {
            List<UserVM> allUserVMs = new List<UserVM>();

            try
            {
                using (UnitOfWork _unitOfWork = new UnitOfWork())
                {
                    foreach (var user in _unitOfWork.Users.GetAll())
                    {
                        allUserVMs.Add(new UserVM(user));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);                
            }

            return allUserVMs;
        }

        public UserVM GetById(int id)
        {
            UserVM userVM = null;

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    userVM = new UserVM(unitOfWork.Users.GetById(id));
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            return userVM;
        }

        public UserVM Save(UserVM userVM)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    User user = new User
                    {
                        Id = userVM.Id,
                        FirstName = userVM.FirstName,
                        LastName = userVM.LastName,
                        UserName = userVM.UserName,
                        IsActive = userVM.IsActive
                    };
                    unitOfWork.Users.Save(user);
                    unitOfWork.SaveChanges();

                    return new UserVM(user);
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
                    unitOfWork.Users.Delete(id);
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
