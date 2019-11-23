using System;
using System.Collections.Generic;
using System.Text;
using TM.ApplicationServices.Massaging.Users;

namespace TM.ApplicationServices.Interface
{
    public interface IUserManagementService
    {
        GetUsersResponse GetAll();
        GetUserResponse GetById(GetUserRequest getUserRequest);
        InsertUserResponse Insert(InsertUserRequest insertUserRequest);
        DeleteUserResponse Delete(DeleteUserRequest deleteUserRequest);
        UpdateUserResponse Update(UpdateUserRequest updateUserRequest);
    }
}
