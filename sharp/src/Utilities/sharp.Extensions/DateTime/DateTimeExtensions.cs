namespace sharp.Extensions.DateTime
{
    public static class DateTimeExtensions
    {
        public static bool Between(this System.DateTime dt, System.DateTime rangeBeg, System.DateTime rangeEnd)
        {
            return dt.Ticks >= rangeBeg.Ticks && dt.Ticks <= rangeEnd.Ticks;
        }

        public static int CalculateAgeFromNow(this System.DateTime birthdateTime)
        {
            var age = System.DateTime.Now.Year - birthdateTime.Year;
            if (System.DateTime.Now < birthdateTime.AddYears(age))
                age--;
            return age;
        }

        public static string ToReadableTime(this System.DateTime value)
        {
            var ts = new System.TimeSpan(System.DateTime.UtcNow.Ticks - value.Ticks);
            double delta = ts.TotalSeconds;
            if (delta < 60)
            {
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            }
            if (delta < 120)
            {
                return "a minute ago";
            }
            if (delta < 2700)
            {
                return ts.Minutes + " minutes ago";
            }
            if (delta < 5400)
            {
                return "an hour ago";
            }
            if (delta < 86400) 
            {
                return ts.Hours + " hours ago";
            }
            if (delta < 172800)
            {
                return "yesterday";
            }
            if (delta < 2592000)
            {
                return ts.Days + " days ago";
            }
            if (delta < 31104000)
            {
                int months = System.Convert.ToInt32(System.Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            var years = System.Convert.ToInt32(System.Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "one year ago" : years + " years ago";
        }
    }
}
