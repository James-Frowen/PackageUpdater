using System.Windows.Forms;

namespace JamesFrowen.PackageUpdater.GUI
{
    public class PackageListGUI : NamedFolderListGUI<Package>
    {
        public PackageListGUI(NamedFolderList<Package> namedFolderList, ListView view) : base(namedFolderList, view)
        {
        }

        protected override string VisableName => "Package";

        protected override void extraItemSetup(ListViewItem item)
        {
            item.SubItems.Add("");
            item.SubItems[2].BackColor = System.Drawing.Color.Red;
            item.UseItemStyleForSubItems = false;
        }
    }
}
