namespace JamesFrowen.PackageUpdater
{
    [System.Serializable]
    public class Project : NamedFolder
    {
        [System.Xml.Serialization.XmlArrayItem("package")]
        public IncludePackages includePackages = new IncludePackages();
    }
}
