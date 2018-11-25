using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.ApplicationServices.ViewModels
{
    public class BaseVM
    {
        public BaseVM() { }

        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore, Order = 1)]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "isActive", NullValueHandling = NullValueHandling.Ignore, Order = 2)]
        public bool IsActive { get; set; }
    }
}
