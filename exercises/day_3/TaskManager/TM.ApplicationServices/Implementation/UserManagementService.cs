using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Text;
using TM.ApplicationServices.Interface;
using TM.ApplicationServices.Massaging.Users;
using TM.ApplicationServices.ViewModels;
using TM.Data.Entities;
using TM.Repositories.Interface;

namespace TM.ApplicationServices.Implementation
{
    public class UserManagementService : ServiceBase, IUserManagementService
    {
        private readonly ILogger<UserManagementService> _logger;
        public UserManagementService(IUnitOfWork unitOfWork, ILogger<UserManagementService> logger) : base(unitOfWork) 
        {
            _logger = logger;
        }

        public GetUsersResponse GetAll()
        {
            _logger.LogInformation("Method User/GetAll is trigger");
            GetUsersResponse getUsersResponse = new GetUsersResponse();
            List<UserViewModel> listUserViewModel = new List<UserViewModel>();

            try
            {
                var allUsers = _unitOfWork.Users.GetAll();
                foreach (var item in allUsers)
                {
                    listUserViewModel.Add(new UserViewModel
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        UserName = item.UserName
                    });
                }
                getUsersResponse.Users = listUserViewModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                getUsersResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                getUsersResponse.StatusDescription = ex.Message;
            }

            return getUsersResponse;
        }

        public GetUserResponse GetById(GetUserRequest getUserRequest)
        {
            _logger.LogInformation("Method User/GetById is trigger");
            GetUserResponse getUserResponse = new GetUserResponse();

            try
            {
                User user = _unitOfWork.Users.GetById(getUserRequest.Id);
                getUserResponse.User = new UserViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                getUserResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                getUserResponse.StatusDescription = ex.Message;
            }

            return getUserResponse;
        }

        public InsertUserResponse Insert(InsertUserRequest insertUserRequest)
        {
            _logger.LogInformation("Method User/Insert is trigger");
            InsertUserResponse insertUserResponse = new InsertUserResponse();
            try
            {
                User user = new User {
                    FirstName = insertUserRequest.UserProperties.FirstName,
                    LastName = insertUserRequest.UserProperties.LastName,
                    UserName = insertUserRequest.UserProperties.UserName
                };
                _unitOfWork.Users.Save(user);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                insertUserResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                insertUserResponse.StatusDescription = ex.Message;
            }

            return insertUserResponse;
        }

        public DeleteUserResponse Delete(DeleteUserRequest deleteUserRequest)
        {
            _logger.LogInformation("Method User/Delete is trigger");
            DeleteUserResponse deleteUserResponse = new DeleteUserResponse();

            try
            {
                _unitOfWork.Users.Delete(deleteUserRequest.Id);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                deleteUserResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                deleteUserResponse.StatusDescription = ex.Message;
            }

            return deleteUserResponse;
        }

        public UpdateUserResponse Update(UpdateUserRequest updateUserRequest)
        {
            _logger.LogInformation("Method User/Update is trigger");
            UpdateUserResponse updateUserResponse = new UpdateUserResponse();

            try
            {
                User existUser = _unitOfWork.Users.GetById(updateUserRequest.Id);
                if (existUser != null)
                {
                    User user = new User
                    {
                        Id = updateUserRequest.Id,
                        FirstName = updateUserRequest.UserProperties.FirstName ?? existUser.FirstName,
                        LastName = updateUserRequest.UserProperties.LastName ?? existUser.LastName,
                        UserName = updateUserRequest.UserProperties.UserName ?? existUser.UserName
                    };
                    _unitOfWork.Users.Update(user);
                    _unitOfWork.SaveChanges();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                updateUserResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                updateUserResponse.StatusDescription = ex.Message;
            }

            return updateUserResponse;
        }
    }
}
