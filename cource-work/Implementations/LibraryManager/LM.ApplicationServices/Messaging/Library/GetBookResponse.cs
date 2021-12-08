using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.ApplicationServices.Messaging.Library
{
    public class GetBookResponse : ServiceResponseBase
    {
        public BookViewModel Book { get; set; }
    }
}
