using AM.ApplicationServices.Interfaces;
using AM.ApplicationServices.Messaging.Users;
using AM.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationServices.Implementations
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
    }
}
