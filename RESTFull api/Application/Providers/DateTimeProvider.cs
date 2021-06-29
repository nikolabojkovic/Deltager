using System;
using Domain;

namespace Application
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now { get => DateTime.Now; }
    }
}