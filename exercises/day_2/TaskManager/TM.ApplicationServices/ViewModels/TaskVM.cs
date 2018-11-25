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
            StartedOnString = task.StartedOn.ToString("dd.MM.yyyy");
            EndedOnString = task.EndedOn.ToString("dd.MM.yyyy");
        }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore, Order = 3)]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore, Order = 4)]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "startedOn", NullValueHandling = NullValueHandling.Ignore, Order = 5)]
        public DateTime StartedOn { get; set; }
        [JsonProperty(PropertyName = "startedOnString", NullValueHandling = NullValueHandling.Ignore, Order = 6)]
        public string StartedOnString { get; set; }
        [JsonProperty(PropertyName = "EndedOn", NullValueHandling = NullValueHandling.Ignore, Order = 7)]
        public DateTime EndedOn { get; set; }
        [JsonProperty(PropertyName = "endedOnString", NullValueHandling = NullValueHandling.Ignore, Order = 8)]
        public string EndedOnString { get; set; }
    }
}