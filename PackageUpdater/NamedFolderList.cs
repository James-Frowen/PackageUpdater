using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace JamesFrowen.PackageUpdater
{
    public interface INamedFolderList
    {
        NamedFolder this[string name] { get; }
    }
    public abstract class NamedFolderList<T> : Dictionary<string, T>, INamedFolderList where T : NamedFolder, new()
    {
        NamedFolder INamedFolderList.this[string name]
        {
            get
            {
                return base[name];
            }
        }
    }
}
