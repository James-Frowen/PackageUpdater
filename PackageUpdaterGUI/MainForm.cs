using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace JamesFrowen.PackageUpdater.GUI
{
    public partial class MainForm : Form
    {
        private static readonly Color includedColor = Color.Green;
        private static readonly Color excludedColor = Color.Red;

        public ProjectData data;
        public ProjectListGUI projectGUI;
        public PackageListGUI packageGUI;

        public MainForm()
        {
            this.InitializeComponent();
            this.editProjectButton.Enabled = false;
            this.load();
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
            StringSet includePackages;
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
                includePackages = project.Dependencies;
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
                this.load();
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            this.UpdateButton.Enabled = false;

            var copyError = CopyPackages.Run(this.data);

            if (copyError.error)
            {
                foreach (var error in copyError.messages)
                {
                    MessageBox.Show(error.message, error.title,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("Finished Coping", "Finished",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.UpdateButton.Enabled = true;
        }

        private void editProjectButton_Click(object sender, EventArgs e)
        {
            this.editNamedFolder(this.projectsListView, this.data.projects);
        }
        private void editPackageButton_Click(object sender, EventArgs e)
        {
            this.editNamedFolder(this.packagesListView, this.data.packages);
        }
        private void editNamedFolder(ListView view, INamedFolderList list)
        {
            if (view.SelectedItems.Count != 0)
            {
                var selectedItem = view.SelectedItems[0];
                var namedFolder = list[selectedItem.Text];
                var editForm = new EditProjectForm(namedFolder, this.data.packages);
                editForm.Show();
            }
        }


        private void openXmlButton_Click(object sender, EventArgs e)
        {
            Process.Start(Path.GetFullPath(ProjectData.GetSavePath()));
        }

    }
}
