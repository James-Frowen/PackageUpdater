using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JamesFrowen.PackageUpdater.GUI
{
    public partial class MainForm : Form
    {
        static readonly Color includedColor = Color.Green;
        static readonly Color excludedColor = Color.Red;

        public ProjectData data;
        public ProjectListGUI projectGUI;
        public PackageListGUI packageGUI;

        public MainForm()
        {
            InitializeComponent();
            this.editProjectButton.Enabled = false;
            load();
        }

        private void load()
        {
            this.data = ProjectData.Load();

            this.projectGUI = new ProjectListGUI(this.data.projects, this.projectsListView);
            this.packageGUI = new PackageListGUI(this.data.packages, this.packagesListView);

            this.projectGUI.RefreshListView();
            this.packageGUI.RefreshListView();
        }

        private void projectsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            IncludePackages includePackages;
            if (this.projectsListView.SelectedItems.Count == 0)
            {
                includePackages = null;
                this.editProjectButton.Enabled = false;
            }
            else
            {
                this.editProjectButton.Enabled = true;

                var selectedItem = this.projectsListView.SelectedItems[0];
                var project = this.data.projects[selectedItem.Text];
                includePackages = project.includePackages;
            }


            for (int i = 0; i < this.packagesListView.Items.Count; i++)
            {
                var packageItem = this.packagesListView.Items[i];
                var included = includePackages != null ? includePackages.Contains(packageItem) : false;

                packageItem.SubItems[2].BackColor = included ? includedColor : excludedColor;
            }
        }

        private void addProjectButton_Click(object sender, EventArgs e)
        {
            this.projectGUI.CheckAndAddItem();
        }

        private void removeProjectbutton_Click(object sender, EventArgs e)
        {
            this.projectGUI.CheckAndRemoveSelected();
        }

        private void addPackageButton_Click(object sender, EventArgs e)
        {
            this.packageGUI.CheckAndAddItem();
        }

        private void removePackageButton_Click(object sender, EventArgs e)
        {
            this.packageGUI.CheckAndRemoveSelected();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ProjectData.Save(this.data);
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            const string text = "Are you sure you want to Reload (current data will be lost)";
            const string Caption = "Are you Sure?";
            var result = MessageBox.Show(text, Caption, MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                load();
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            CopyPackages.Run(this.data);
        }

        private void editProjectButton_Click(object sender, EventArgs e)
        {
            if (this.projectsListView.SelectedItems.Count != 0)
            {
                var selectedItem = this.projectsListView.SelectedItems[0];
                var project = this.data.projects[selectedItem.Text];
                var editForm = new EditProjectForm(project, this.data.packages);
                editForm.Show();
            }
        }

        private void openXmlButton_Click(object sender, EventArgs e)
        {
            Process.Start(Path.GetFullPath(ProjectData.GetSavePath()));
        }
    }
}
