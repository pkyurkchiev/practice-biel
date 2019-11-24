using System;
using System.Collections.Generic;
using System.Text;

namespace TM.ApplicationServices.Massaging
{
    public abstract class ServiceResponseBase
    {
        public ServiceResponseBase()
        {
            this.StatusCode = System.Net.HttpStatusCode.OK;
            this.StatusDescription = "OK";
        }
        public System.Net.HttpStatusCode StatusCode { get; set; }
        public string StatusDescription { get; set; }
    }
}
