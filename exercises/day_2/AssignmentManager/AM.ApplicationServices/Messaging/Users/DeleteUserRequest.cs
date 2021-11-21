using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationServices.Messaging.Users
{
    public class DeleteUserRequest : IntegerIdRequest
    {
        public DeleteUserRequest(int id) : base(id) { }
    }
}
