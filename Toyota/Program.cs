using NLog;
using NLog.Config;
using System;

namespace Toyota
{
    class Program
    {
        public static Logger Log;
        static void Main(string[] args)
        {
            LogManager.Configuration = new XmlLoggingConfiguration("nLogConfig.xml");


            Console.ReadKey();
        }
    }
}
