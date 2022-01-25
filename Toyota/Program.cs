using NLog;
using NLog.Config;
using System;
using Toyota.Entity;

namespace Toyota
{
    class Program
    {
        //public static Logger Log;
        static void Main(string[] args)
        {
            LogManager.Configuration = new XmlLoggingConfiguration("nLogConfig.xml");

            App app = new App();  // start programm

            Console.ReadKey();
        }
    }
}
