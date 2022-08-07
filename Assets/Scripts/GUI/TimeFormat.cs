using System;

public static class TimeFormat
{
   public static string Format(float seconds)
   {
      TimeSpan time = TimeSpan.FromSeconds(seconds);
      return time.Hours + ":" + time.Minutes + ":" + time.Seconds;
   }
}
