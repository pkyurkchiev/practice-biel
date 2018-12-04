using Newtonsoft.Json;
using System;
using TM.Data.Entities;

namespace TM.ApplicationServices.ViewModels
{
    public class TaskVM : BaseVM
    {
        public TaskVM() { }
        public TaskVM(Task task)
        {
            Id = task.Id;
            IsActive = task.IsActive;
            Name = task.Name;
            Description = task.Description;
            StartedOn = task.StartedOn;
            EndedOn = task.EndedOn;
        }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore, Order = 3)]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore, Order = 4)]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "startedOn", NullValueHandling = NullValueHandling.Ignore, Order = 5)]
        public DateTime StartedOn { get; set; }
        [JsonProperty(PropertyName = "endedOn", NullValueHandling = NullValueHandling.Ignore, Order = 6)]
        public DateTime EndedOn { get; set; }
    }
}