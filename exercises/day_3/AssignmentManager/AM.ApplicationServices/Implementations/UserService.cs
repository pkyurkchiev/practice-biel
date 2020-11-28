using AM.ApplicationServices.Interfaces;
using AM.ApplicationServices.Messaging.Users;
using AM.ApplicationServices.ViewModels;
using AM.Data.Entities;
using AM.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.ApplicationServices.Implementations
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly ILogger<AssignmentService> _logger;
        public UserService(IUnitOfWork unitOfWork, ILogger<AssignmentService> logger) : base(unitOfWork)
        {
            _logger = logger;
        }

        public GetUsersResponse GetAll()
        {
            GetUsersResponse response = new GetUsersResponse();
            List<UserViewModel> userViewModels = new List<UserViewModel>();

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
                _logger.LogError(ex.Message);
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.StatusDescription = ex.Message;
            }

            return response;
        }

        public GetUserResponse GetById(GetUserRequest request)
        {
            GetUserResponse response = new GetUserResponse();

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
                else
                {
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    response.StatusDescription = "User not found";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.StatusDescription = ex.Message;
            }

            return response;
        }

        public InsertUserResponse Insert(InsertUserRequest request)
        {
            InsertUserResponse response = new InsertUserResponse();

            try
            {
                var user = new User
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
                _logger.LogError(ex.Message);
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.StatusDescription = ex.Message;
            }

            return response;
        }

        public DeleteUserResponse Delete(DeleteUserRequest request)
        {
            DeleteUserResponse response = new DeleteUserResponse();

            try
            {
                _unitOfWork.Users.Delete(request.Id);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.StatusDescription = ex.Message;
            }

            return response;
        }

        public UpdateUserResponse Update(UpdateUserRequest request)
        {
            UpdateUserResponse response = new UpdateUserResponse();

            try
            {
                var user = _unitOfWork.Users.GetById(request.Id);
                user.FirstName = request.UserProperties.FirstName ?? user.FirstName;
                user.LastName = request.UserProperties.LastName ?? user.LastName;

                _unitOfWork.Users.Update(user);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.StatusDescription = ex.Message;
            }

            return response;
        }
    }
}
