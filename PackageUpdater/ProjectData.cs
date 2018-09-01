using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace JamesFrowen.PackageUpdater
{
    [System.Serializable]
    public class ProjectData
    {
        public static string GetSavePath()
        {
            return Path.Combine(GetSaveDirectory(), "ProjectList.xml");
        }
        public static string GetSaveDirectory()
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(appData, "James Frowen", "PackageUpdater");
            return path;
        }
        public ProjectList projects;
        public PackageList packages;

        private ProjectData()
        {
            this.projects = new ProjectList();
            this.packages = new PackageList();
        }
        private ProjectData(Data data)
        {
            this.projects = new ProjectList();
            foreach (var project in data.projects)
            {
                this.projects.Add(project.Name, project);
            }

            this.packages = new PackageList();
            foreach (var package in data.packages)
            {
                this.packages.Add(package.Name, package);
            }
        }

        [System.Serializable]
        public class Data
        {
            public Project[] projects;
            public Package[] packages;

            public Data() { }
            public Data(ProjectList projectList, PackageList packageList)
            {
                this.projects = new Project[projectList.Count];
                projectList.Values.CopyTo(this.projects, 0);
                this.packages = new Package[packageList.Count];
                packageList.Values.CopyTo(this.packages, 0);
            }
        }

        public static ProjectData Load()
        {
            string path = GetSavePath();
            if (!File.Exists(path))
            {
                return new ProjectData();
            }
            
            ProjectData list = null;
            using (var stream = new StreamReader(path))
            {
                XmlSerializer x = new XmlSerializer(typeof(Data));
                var data = x.Deserialize(stream) as Data;
                list = new ProjectData(data);
            }

            return list;
        }
        public static void Save(ProjectData list)
        {
            string directory = GetSaveDirectory();
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var data = new Data(list.projects, list.packages);
            string path = GetSavePath();
            using (var stream = new StreamWriter(path))
            {
                XmlSerializer x = new XmlSerializer(typeof(Data));
                x.Serialize(stream, data);
            }
        }
    }
}
