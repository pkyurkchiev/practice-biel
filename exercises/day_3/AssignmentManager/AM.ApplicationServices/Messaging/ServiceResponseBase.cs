using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AM.ApplicationServices.Messaging
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
    }
}
