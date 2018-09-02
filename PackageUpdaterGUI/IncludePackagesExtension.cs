using System.Windows.Forms;

namespace JamesFrowen.PackageUpdater.GUI
{
    public static class IncludePackagesExtension
    {
        public static bool Contains(this StringSet list,  ListViewItem packageItem)
        {
            return list.Contains(packageItem.Text);
        }
    }
}
