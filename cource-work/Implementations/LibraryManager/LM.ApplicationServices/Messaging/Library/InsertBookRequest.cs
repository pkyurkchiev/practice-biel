using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.ApplicationServices.Messaging.Library
{
    public class InsertBookRequest : ServiceRequestBase
    {
        public InsertBookRequest(BookPropertiesViewModel properties) 
        {
            BookProperties = properties;
        }

        public BookPropertiesViewModel BookProperties { get; set; }
    }
}
