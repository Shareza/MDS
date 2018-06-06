using System;
using System.Collections;
using System.Collections.Generic;

namespace MDS.Models
{
    public class EventsResponse : IEnumerable<EventsResponse>
    {
        public List<Schedule> schedule { get; set; }

        public IEnumerator<EventsResponse> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
