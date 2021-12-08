using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.ApplicationServices.Messaging.Library
{
    public class UpdateBookRequest : IntegerIdRequest
    {
        public UpdateBookRequest(int id, BookPropertiesViewModel properties) : base(id)
        {
            BookProperties = properties;
        }

        public BookPropertiesViewModel BookProperties { get; set; }
    }
}
