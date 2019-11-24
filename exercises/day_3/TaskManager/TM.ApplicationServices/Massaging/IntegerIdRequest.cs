using System;
using System.Collections.Generic;
using System.Text;

namespace TM.ApplicationServices.Massaging
{
    public abstract class IntegerIdRequest : ServiceRequestBase
    {
        private int _id;

        public IntegerIdRequest(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID must be positive.");

            _id = id;
        }

        public int Id { get { return _id; } }
    }
}
