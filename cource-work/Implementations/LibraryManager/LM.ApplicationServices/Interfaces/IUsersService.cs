using LM.ApplicationServices.Messaging.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.ApplicationServices.Interfaces
{
    public interface IUsersService
    {
        GetUsersResponse GetAll();
        GetUserResponse GetById(GetUserRequest request);
        InsertUserResponse Insert(InsertUserRequest request);
        DeleteUserResponse Delete(DeleteUserRequest request);
        UpdateUserResponse Update(UpdateUserRequest request);
    }
}
