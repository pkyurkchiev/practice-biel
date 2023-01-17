using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LM.ApplicationServices.Messaging
{
    public abstract class ServiceResponseBase
    {
        public HttpStatusCode StatusCode { get; set; }
        public string StatusDescription { get; set; }

        public ServiceResponseBase()
        {
            StatusCode = HttpStatusCode.OK;
            StatusDescription = "OK";
        }

        public void BuildException(Exception exception)
        {
            StatusCode = HttpStatusCode.InternalServerError;
            StatusDescription = exception.Message;
        }
    }
}
