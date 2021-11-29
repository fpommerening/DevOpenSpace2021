using System;

namespace FP.Monitoring.Metrics.Business
{
    public class Meetup
    {
        public string Title { get; set; }
        public string Speaker { get; set; }

        public string Location { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
