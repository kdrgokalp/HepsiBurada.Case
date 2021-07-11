using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Helper
{
    public static class SystemClock
    {
        private static TimeSpan _currentTime = new TimeSpan(00, 00, 00);
        public static DateTime Now => new DateTime(2021, 01, 01, _currentTime.Hours, 0, 0);

        public static void IncreaseTime(int hour) { _currentTime = _currentTime + new TimeSpan(hour, 0, 0); }

        public static void Reset() => _currentTime = new TimeSpan(00, 00, 00);
    }
}
