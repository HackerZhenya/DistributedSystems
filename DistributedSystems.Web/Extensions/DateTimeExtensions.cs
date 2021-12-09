namespace DistributedSystems.Web.Extensions;

public static class DateTimeExtensions
{
    private static readonly DateTime Epoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public static long ToUnixTimestamp(this DateTime date)
    {
        var time = date.ToUniversalTime().Subtract(Epoch);
        return time.Ticks / TimeSpan.TicksPerSecond;
    }

    public static string ToHumanReadableString(this TimeSpan t)
    {
        if (t.TotalSeconds <= 1)
        {
            return $@"{t:s\.ff} seconds";
        }

        if (t.TotalMinutes <= 1)
        {
            return $@"{t:%s} seconds";
        }

        if (t.TotalHours <= 1)
        {
            return $@"{t:%m} minutes";
        }

        if (t.TotalDays <= 1)
        {
            return $@"{t:%h} hours";
        }

        return $@"{t:%d} days";
    }
}