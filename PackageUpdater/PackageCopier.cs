using System.Collections.Generic;
using System.IO;
namespace JamesFrowen.PackageUpdater
{
    public class CopyError
    {
        public bool error;
        public List<Error> messages;
        public struct Error
        {
            public string message;
            public string title;
        }
    }
    public class CopyPackages
    {
        public static CopyError Run(ProjectData data)
        {
            var copyError = new CopyError()
            {
                error = false,
                messages = new List<CopyError.Error>()
            };
            foreach (var project in data.projects.Values)
            {
                var toCopy = new PackageSet();

                addPackagesAndDependacies(copyError, toCopy, project.Dependencies, data.packages);

                foreach (var package in toCopy)
                {
                    copy(project, package);
                }
            }

            return copyError;
        }
        private static void addPackagesAndDependacies(CopyError copyError, PackageSet set, StringSet packageNames, PackageList all)
        {
            foreach (var packageName in packageNames)
            {
                Package package;
                if (all.TryGetValue(packageName, out package))
                {
                    set.Add(package);

                    addPackagesAndDependacies(copyError, set, package.Dependencies, all);
                }
                else
                {
                    copyError.error = true;
                    copyError.messages.Add(new CopyError.Error
                    {
                        title = "Package not found!",
                        message = string.Format("Could not find package with name '{0}'", packageName),
                    });
                }
            }
        }


        private static void copy(Project project, Package package)
        {
            const string folderPattern = "*";
            const string filePattern = "*.*";
            const SearchOption searchOptions = SearchOption.AllDirectories;


            var sourcePath = package.Path;
            var sourceName = package.Name;
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
