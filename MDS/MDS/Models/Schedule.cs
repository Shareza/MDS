using System;
using System.Collections.Generic;
using System.Text;

namespace MDS.Models
{
    public class Schedule
    {
        public string Day { get; set; }
        public List<Event> Events { get; set; }
    }
}
