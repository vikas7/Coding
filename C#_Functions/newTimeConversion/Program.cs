using System;
using System.Globalization;
using System.Threading;

namespace newTimeConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // CultureInfo cu=new CultureInfo("en-US");
            // DateTime da=new DateTime(2019,12,05);
            // new DateTime();

            // DateTime userTime = DateTime.SpecifyKind(DateTime.Today, DateTimeKind.Unspecified);
            // Console.WriteLine("User time : "+userTime);
            // Console.WriteLine("UTC current time is : "+ DateTime.UtcNow.Date);
            // Console.WriteLine("Date time for Specify kind " +DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified));


            DateTime indianTime=TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            indianTime=indianTime.AddHours(-8);
            DateTime utcTime=TimeZoneInfo.ConvertTimeToUtc(indianTime,TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            Console.WriteLine(indianTime);
            Console.WriteLine(utcTime);

            Console.WriteLine("It is UTC time and date: "+DateTime.UtcNow);
            DateTime convertFromUtc=TimeZoneInfo.ConvertTimeToUtc(DateTime.UtcNow,TimeZoneInfo.FindSystemTimeZoneById("UTC"));
            Console.WriteLine("Conversion from utc :"+convertFromUtc);
          
            
        }
    }
}
