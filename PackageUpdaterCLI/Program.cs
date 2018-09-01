using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesFrowen.PackageUpdater.CLI
{
    class Program
    {
        private const string UPDATE= "update";
        private const string OPEN_XML= "open-xml";

        static void Main(string[] args)
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
            CopyPackages.Run(ProjectData.Load());
        }
    }
}
