using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FP.Monitoring.Metrics.Models
{
    public class MeetupViewModel
    {
        public string Title { get; set; }
        public string Speaker { get; set; }

        public string Location { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
