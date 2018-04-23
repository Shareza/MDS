using RestSharp;
using System;

namespace MDS
{
    public class Event
    {
        public string EventStartTime { get; set; }

        public string EventEndTime { get; set; }

        public int EventLengthInMins { get; set; }

        public int ServiceType { get; set; }

        public bool IsConfirmed { get; set; }

        public Customer Customer { get; set; }
    }
}
