using System.Collections.Generic;

namespace JamesFrowen.PackageUpdater
{
    public class IncludePackages : List<string>
    {
        public new void Add(string name)
        {
            if (!this.Contains(name))
            {
                base.Add(name);
            }
        }
        public new void Remove(string name)
        {
            if (this.Contains(name))
            {
                base.Remove(name);
            }
        }
    }
}
