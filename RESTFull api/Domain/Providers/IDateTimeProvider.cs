using System;

namespace Domain
{
    public interface IDateTimeProvider
    {
        public DateTime Now { get; }
    }
}