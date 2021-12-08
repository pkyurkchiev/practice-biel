using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.ApplicationServices.Messaging
{
    public abstract class IntegerIdRequest : ServiceRequestBase
    {
        private readonly int _id;
        public IntegerIdRequest(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be positive.");
            _id = id;
        }

        public int Id { get => _id; }
    }
}
