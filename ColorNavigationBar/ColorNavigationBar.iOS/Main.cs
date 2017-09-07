using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using System.Threading.Tasks;

namespace ColorNavigationBar.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }

        static void SetupExceptionHandler()
        {
            AppDomain.CurrentDomain.UnhandledException +=
                (sender, args) =>
                {
                    Console.WriteLine(args.ExceptionObject.GetType());
                };
            TaskScheduler.UnobservedTaskException +=
                (sender, args) =>
                {
                    Console.WriteLine(args.Exception);
                };
        }

    }
}
