using System;
using System.Threading.Tasks;
using FP.Monitoring.Metrics.Business;
using FP.Monitoring.Metrics.Contract;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Prometheus;

namespace FP.Monitoring.Metrics.Services
{
    public class MeetupService : Contract.MeetupService.MeetupServiceBase
    {
        private readonly ILogger<MeetupService> _logger;
        private readonly MeetupRepository _meetupRepository;

        public MeetupService(ILogger<MeetupService> logger, MeetupRepository meetupRepository)
        {
            _logger = logger;
            _meetupRepository = meetupRepository;
        }

        public override async Task<GreetAttendeeResponse> GreetAttendee(GreetAttendeeRequest request, ServerCallContext context)
        {

            using (MeeetupMetrics.GreetingDuration.NewTimer())
            {
                var greeting = $"Hallo to {string.Join(',', request.Names)}";
                await Task.Delay(TimeSpan.FromSeconds(new Random().Next(1, 5)));
                return new GreetAttendeeResponse
                {
                    Message = greeting
                };
            }
           
        }

        public override async Task<ScheduleMeetupResponse> ScheduleMeetup(ScheduleMeetupRequest request, ServerCallContext context)
        {
            await _meetupRepository.AddMeetup(request.Title, request.Speaker, request.Location,
                request.Start.ToDateTime(), request.End.ToDateTime());

            return new ScheduleMeetupResponse
            {
                CreatedAt = DateTime.UtcNow.ToTimestamp()
            };
        }
    }
}
