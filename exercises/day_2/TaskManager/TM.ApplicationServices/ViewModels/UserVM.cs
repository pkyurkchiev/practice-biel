using Newtonsoft.Json;
using TM.Data.Entities;

namespace TM.ApplicationServices.ViewModels
{
    public class UserVM : BaseVM
    {
        public UserVM() { }
        public UserVM(User user)
        {
            Id = user.Id;
            IsActive = user.IsActive;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
        }

        [JsonProperty(PropertyName = "firstName", NullValueHandling = NullValueHandling.Ignore, Order = 3)]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "lastName", NullValueHandling = NullValueHandling.Ignore, Order = 4)]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore, Order = 5)]
        public string UserName { get; set; }
    }
}