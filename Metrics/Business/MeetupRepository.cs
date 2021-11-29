using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FP.Monitoring.Metrics.Business
{
    public class MeetupRepository
    {
        private List<Meetup> _meetups = new List<Meetup>();
            
        public async Task AddMeetup(string title, string speaker, string loaction, DateTime start, DateTime end)
        {
            _meetups.Add(new Meetup
            {
                Title = title,
                Speaker = speaker,
                Location = loaction,
                Start = start,
                End = end
            });

            await Task.Delay(TimeSpan.FromMilliseconds(500));
        }

        public IReadOnlyCollection<Meetup> GetMeetups()
        {
            return _meetups.AsReadOnly();
        }
    }
}
