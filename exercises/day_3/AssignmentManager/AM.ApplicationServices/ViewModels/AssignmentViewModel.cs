﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AM.ApplicationServices.ViewModels
{
    public class AssignmentViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime EndedOn { get; set; }
        public string OwnerFullName { get; set; }
        public bool IsActive { get; set; }
    }
}
