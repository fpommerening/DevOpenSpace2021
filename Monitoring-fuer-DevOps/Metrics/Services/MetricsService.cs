using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FP.Monitoring.Metrics.Business;
using Microsoft.Extensions.Hosting;

namespace FP.Monitoring.Metrics.Services
{
    public class MetricsService : BackgroundService
    {
        private readonly MeetupRepository _meetupRepository;

        public MetricsService(MeetupRepository meetupRepository)
        {
            _meetupRepository = meetupRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var meetups = _meetupRepository.GetMeetups();
                MeeetupMetrics.MeetupsInFutureCount.Set(meetups.Count(x => x.Start > DateTime.UtcNow));
                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}
