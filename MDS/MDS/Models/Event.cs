namespace MDS
{
    public class Event
    {
        public int EventId { get; set; }

        public string EventStartTime { get; set; }

        public string EventEndTime { get; set; }

        public int EventLengthInMins { get; set; }

        public int EventType { get; set; }

        public bool IsConfirmed { get; set; }

        public Customer Customer { get; set; }
    }
}
