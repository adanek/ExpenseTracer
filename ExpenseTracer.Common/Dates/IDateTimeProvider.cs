using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracer.Common.Dates
{
    public interface IDateTimeProvider
    {
        DateTimeOffset Now { get; }
    }

    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
    }
}
