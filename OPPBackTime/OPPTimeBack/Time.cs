namespace OPPTimeBack
{   public class Time
    {
        // Fields
        private int _hour;
        private int _millisecond;
        private int _minute;
        private int _second;

        // Constructors
        public Time()
        {
            _hour = 0;
            _minute = 0;
            _second = 0;
            _millisecond = 0;
        }

        public Time(int hour)
        {
            Hour = hour;
            _minute = 0;
            _second = 0;
            _millisecond = 0;
        }

        public Time(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
            _second = 0;
            _millisecond = 0;
        }

        public Time(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            _millisecond = 0;
        }

        public Time(int hour, int minute, int second, int millisecond)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;
        }

        // Properties
        public int Hour
        {
            get => _hour;
            set => _hour = ValidateHour(value);
        }

        public int Minute
        {
            get => _minute;
            set => _minute = ValidateMinute(value);
        }

        public int Second
        {
            get => _second;
            set => _second = ValidateSecond(value);
        }

        public int Millisecond
        {
            get => _millisecond;
            set => _millisecond = ValidateMillisecond(value);
        }

        //Methods
        public override string ToString()
        {

            int hour12 = Hour % 12;
            if (hour12 == 0) hour12 = 12;
            string ampm = Hour < 12 ? "AM" : "PM";
            return $"{hour12:D2}:{Minute:D2}:{Second:D2}.{Millisecond:D3} {ampm}";
        }

        public long ToMilliseconds()
        {
            return (long)Hour * 3600000 + Minute * 60000 + Second * 1000 + Millisecond;
        }

        public long ToSeconds()
        {
            return ToMilliseconds() / 1000;
        }

        public long ToMinutes()
        {
            return ToMilliseconds() / 60000;
        }

        public bool IsOtherDay(Time other)
        {
            long totalMs = ToMilliseconds() + other.ToMilliseconds();
            return totalMs >= 24 * 3600000;
        }

        public Time Add(Time other)
        {
            long totalMs = ToMilliseconds() + other.ToMilliseconds();

            long totalDays = totalMs / (24 * 3600000);
            long msInDay = totalMs % (24 * 3600000);

            int ms = (int)(msInDay % 1000);
            int s = (int)((msInDay / 1000) % 60);
            int m = (int)(((msInDay / 1000) / 60) % 60);
            int h = (int)((msInDay / 3600000) % 24);

            return new Time(h, m, s, ms);
        }

        private static int ValidateHour(int hour)
        {
            if (hour < 0 || hour > 23)
                throw new ArgumentOutOfRangeException(nameof(hour), $"The hour: {hour}, is not valid");
            return hour;
        }

        private static int ValidateMinute(int minute)
        {
            if (minute < 0 || minute > 59)
                throw new ArgumentOutOfRangeException(nameof(minute), $"The hour:{minute}, is not valid");
            return minute;
        }

        private static int ValidateSecond(int second)
        {
            if (second < 0 || second > 59)
                throw new ArgumentOutOfRangeException(nameof(second), $"The hour:{second}, is not valid");
            return second;
        }

        private static int ValidateMillisecond(int millisecond)
        {
            if (millisecond < 0 || millisecond > 999)
                throw new ArgumentOutOfRangeException(nameof(millisecond), $"The hour:{millisecond}, is not valid");
            return millisecond;
        }
    }
}