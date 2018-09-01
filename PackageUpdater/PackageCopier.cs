using System;
using System.IO;

namespace JamesFrowen.PackageUpdater
{
    public class CopyPackages
    {
        public static void Run(ProjectData data)
        {
            foreach (var project in data.projects.Values)
            {
                foreach (var packageName in project.includePackages)
                {
                    var package = data.packages[packageName];
                    copy(project, package);
                }
            }
        }

        private static void copy(Project project, Package package)
        {
            const string folderPattern = "*";
            const string filePattern = "*.*";
            const SearchOption searchOptions = SearchOption.AllDirectories;


            var sourcePath = package.Path;
            var sourceName = new DirectoryInfo(sourcePath).Name;
            var destinationPath = Path.Combine(project.Path, "Assets", "External", sourceName);
            Directory.CreateDirectory(destinationPath);

            foreach (string dirPath in Directory.GetDirectories(sourcePath, folderPattern, searchOptions))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, destinationPath));
            }

            foreach (string newPath in Directory.GetFiles(sourcePath, filePattern, searchOptions))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, destinationPath), true);
            }
        }
    }
}
