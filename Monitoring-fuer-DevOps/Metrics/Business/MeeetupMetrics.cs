using Prometheus;

namespace FP.Monitoring.Metrics.Business
{
    public class MeeetupMetrics
    {
        internal static readonly Gauge MeetupsInFutureCount = Prometheus.Metrics
            .CreateGauge("meetup_in_future", "Number of meetups in future.");

        internal static readonly Counter MeetupsCount = Prometheus.Metrics.CreateCounter("meetup_total", "Number of meetups.", "location");

        internal static readonly Histogram GreetingDuration = Prometheus.Metrics
            .CreateHistogram("greeeting_duration_seconds", "Histogram of greeting processing durations.");

    }
}
