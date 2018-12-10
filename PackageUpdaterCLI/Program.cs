using System;
using System.Diagnostics;
using System.IO;

namespace JamesFrowen.PackageUpdater.CLI
{
    internal class Program
    {
        private const string UPDATE = "update";
        private const string OPEN_XML = "open-xml";

        private static void Main(string[] args)
        {
            if (args[0].ToLower() == UPDATE)
            {
                updateAll();
            }
            else if (args[0].ToLower() == OPEN_XML)
            {
                openXml();
            }
            else
            {
                var e = new ArgumentException(string.Format("Avaliable Args:\n{0}\n{1}", UPDATE, OPEN_XML));
                Console.Error.Write(e.ToString());
            }
        }

        private static void openXml()
        {
            Process.Start(Path.GetFullPath(ProjectData.GetSavePath()));
        }

        private static void updateAll()
        {
            Console.WriteLine("Updating All projects");
            var copyError = CopyPackages.Run(ProjectData.Load());

            if (copyError.error)
            {

                foreach (var error in copyError.messages)
                {
                    Console.Error.WriteLine(error.title);
                    Console.Error.WriteLine(error.message);
                    Console.Error.WriteLine("");
                }
            }
            Console.WriteLine("Finished");
        }
    }
}
