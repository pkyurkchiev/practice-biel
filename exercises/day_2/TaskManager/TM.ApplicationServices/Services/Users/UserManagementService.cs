using System;
using System.Collections.Generic;
using System.Text;
using TM.ApplicationServices.Services;
using TM.ApplicationServices.ViewModels.Users;
using TM.Data.Entities;

namespace TM.ApplicationServices.Services.Users
{
    public class UserManagementService : BaseService
    {
        #region Public Methods
        public List<UserVM> GetAll()
        {
            List<UserVM> allUserVMs = new List<UserVM>();

            try
            {
                foreach (var user in _unitOfWork.Users.GetAll())
                {
                    allUserVMs.Add(new UserVM
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName
                    });
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
                var user = _unitOfWork.Users.GetById(id);
                userVM = new UserVM
                {
                    Id = user.Id,
                    FirstName = user.FirstName
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            return userVM;
        }

        public int Save(UserVM userVM)
        {
            try
            {
                var user = new User
                {
                    Id = userVM.Id,
                    FirstName = userVM.FirstName
                };
                _unitOfWork.Users.Save(user);
                _unitOfWork.SaveChanges();

                return user.Id;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return -1;
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
