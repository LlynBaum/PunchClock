using M223PunchclockDotnet.Model;

namespace M223PunchclockDotnet.Service;

public class TimeSummaryService
{
    public Dictionary<DateTime, TimeSpan> CalculateSummaryPerDay(List<Entry> entries)
    {
        return entries
            .GroupBy(e => e.CheckIn.Date)
            .Select(dateGroup => new
            {
                Date = dateGroup.Key,
                Duration = dateGroup
                    .Select(e => e.CheckOut - e.CheckIn)
                    .Aggregate((span, timeSpan) => span + timeSpan)
            })
            .ToDictionary(e => e.Date, e => e.Duration);
    }
}