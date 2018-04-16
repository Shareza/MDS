using System;
using System.Collections.Generic;
using System.Text;

namespace MDS
{
    public class Event
    {
        public DateTime EventDate { get; set; }
        public string EventStartTime { get; set; }
        public string EventEndTime { get; set; }
        public int EventLengthInMins { get; set; }
        public Service ServiceType { get; set; }
        public bool IsConfirmed { get; set; }
        public Customer Customer { get; set; }


        
    }
}
