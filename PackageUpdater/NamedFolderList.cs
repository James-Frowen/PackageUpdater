using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace JamesFrowen.PackageUpdater
{
    public abstract class NamedFolderList<T> : Dictionary<string, T> where T : NamedFolder, new()
    {
    }
}
