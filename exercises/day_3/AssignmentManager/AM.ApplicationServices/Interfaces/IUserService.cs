using AM.ApplicationServices.Messaging.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.ApplicationServices.Interfaces
{
    public interface IUserService
    {
        GetUsersResponse GetAll();
        GetUserResponse GetById(GetUserRequest request);
        InsertUserResponse Insert(InsertUserRequest request);
        DeleteUserResponse Delete(DeleteUserRequest request);
        UpdateUserResponse Update(UpdateUserRequest request);
    }
}
