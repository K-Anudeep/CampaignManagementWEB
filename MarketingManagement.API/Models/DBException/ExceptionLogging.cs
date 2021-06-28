using System;
using System.IO;

namespace DatabaseLayer.DBException
{
    public class ExceptionLogging : Exception
    {
        //public ExceptionLogging(string logMessage, TextWriter w, string location)
        //{
        //    w.WriteLine("\r\nLog Entry : ");
        //    w.WriteLine($"During: {DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
        //    w.WriteLine($"Location : {location}");
        //    w.WriteLine("  :");
        //    w.WriteLine($" Message :{logMessage}");
        //    w.WriteLine("-------------------------------");
        //}

        public static void WriteLog(Exception ex)
        {
            StreamWriter writer = new StreamWriter("log.txt", true);
            writer.WriteLine("\r\nLog Entry : ");
            writer.WriteLine($"During: {DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            writer.WriteLine($"Location : {ex.StackTrace}");
            writer.WriteLine("  :");
            writer.WriteLine($" Message :{ex.Message}");
            writer.WriteLine("-------------------------------");
        }

        public ExceptionLogging(string message) : base(message)
        {
        }

        public ExceptionLogging() : base()
        {
        }

        public ExceptionLogging(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
