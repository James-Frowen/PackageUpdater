﻿namespace JamesFrowen.PackageUpdater
{
    [System.Serializable]
    public abstract class NamedFolder
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public StringSet Dependencies { get; set; } = new StringSet();
    }
}
