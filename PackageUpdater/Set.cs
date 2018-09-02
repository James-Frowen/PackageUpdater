using System.Collections.Generic;

namespace JamesFrowen.PackageUpdater
{
    public class Set<T>: List<T>
    {
        public new void Add(T name)
        {
            if (!this.Contains(name))
            {
                base.Add(name);
            }
        }
        public new void Remove(T name)
        {
            if (this.Contains(name))
            {
                base.Remove(name);
            }
        }
    }
}
