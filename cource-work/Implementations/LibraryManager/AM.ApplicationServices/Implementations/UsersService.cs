using LM.ApplicationServices.Interfaces;
using LM.ApplicationServices.Messaging.Users;
using LM.Data.Entites;
using LM.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.ApplicationServices.Implementations
{
    public class UsersService : BaseService, IUsersService
    {
        private readonly ILogger<UsersService> _logger;

        public UsersService(IUnitOfWork unitOfWork, ILogger<UsersService> logger) : base(unitOfWork)
        {
            _logger = logger;
        }

        public GetUsersResponse GetAll()
        {
            GetUsersResponse response = new();
            List<UserViewModel> userViewModels = new();
            try
            {
                var users = _unitOfWork.Users.GetAll();
                foreach (var item in users)
                {
                    userViewModels.Add(new UserViewModel
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        UserName = item.UserName,
                        IsActive = item.IsActive
                    });
                }
                response.Users = userViewModels;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have a select error!");
                response.BuildException(ex);
            }

            return response;
        }

        public GetUserResponse GetById(GetUserRequest request)
        {
            GetUserResponse response = new();
            try
            {
                var user = _unitOfWork.Users.GetById(request.Id);
                if (user != null)
                {
                    response.User = new UserViewModel
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        UserName = user.UserName,
                        IsActive = user.IsActive
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have a select error!");
                response.BuildException(ex);
            }

            return response;
        }

        public InsertUserResponse Insert(InsertUserRequest request)
        {
            InsertUserResponse response = new();
            try
            {
                User user = new()
                {
                    FirstName = request.UserProperties.FirstName,
                    LastName = request.UserProperties.LastName,
                    UserName = request.UserProperties.UserName,
                    IsActive = true
                };

                _unitOfWork.Users.Insert(user);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have a insert error!");
                response.BuildException(ex);
            }
            return response;
        }

        public UpdateUserResponse Update(UpdateUserRequest request)
        {
            UpdateUserResponse response = new();
            try
            {
                var user = _unitOfWork.Users.GetById(request.Id);
                user.FirstName = request.UserProperties.FirstName ?? user.FirstName;
                user.LastName = request.UserProperties.LastName ?? user.LastName;
                user.UserName = request.UserProperties.UserName ?? user.UserName;

                _unitOfWork.Users.Update(user);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have a update error!");
                response.BuildException(ex);
            }
            return response;
        }

        public DeleteUserResponse Delete(DeleteUserRequest request)
        {
            DeleteUserResponse response = new();

            try
            {
                _unitOfWork.Users.Delete(request.Id);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have a delete error!");
                response.BuildException(ex);
            }
            return response;
        }
    }
}
