using System;

namespace ExpenseTracer.Common.Dates
{
    public static class DateTimeOffsetExtensions
    {
        public static DateTimeOffset Trim(this DateTimeOffset timestamp, long roundTicks)
        {
            var ticks = timestamp.Ticks - timestamp.Ticks % roundTicks;
            return new DateTimeOffset(ticks, timestamp.Offset);
        }
    }
}
