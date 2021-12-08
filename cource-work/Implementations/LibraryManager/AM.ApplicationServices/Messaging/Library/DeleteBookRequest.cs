using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.ApplicationServices.Messaging.Library
{
    public class DeleteBookRequest : IntegerIdRequest
    {
        public DeleteBookRequest(int id) : base(id) { }
    }
}
