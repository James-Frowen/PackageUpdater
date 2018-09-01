using System.Windows.Forms;

namespace JamesFrowen.PackageUpdater.GUI
{
    public class ProjectListGUI : NamedFolderListGUI<Project>
    {
        public ProjectListGUI(NamedFolderList<Project> namedFolderList, ListView view) : base(namedFolderList, view)
        {
        }

        protected override string VisableName => "Project";
    }
}
