﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.ApplicationServices.Messaging.Users
{
    public class GetUserRequest : IntegerIdRequest
    {
        public GetUserRequest(int id) : base(id) { }
    }
}