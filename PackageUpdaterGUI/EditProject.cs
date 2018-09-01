using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JamesFrowen.PackageUpdater.GUI
{
    public partial class EditProject : Form
    {
        public Project Project { get; }
        public PackageList Packages { get; }

        public EditProject(Project project, PackageList packages)
        {
            InitializeComponent();

            this.Project = project;
            this.Packages = packages;

            this.NameTextBox.Text = project.Name;
            this.PathTextBox.Text = project.Path;

            this.packageCheckedList.Items.Clear();
            foreach (var package in packages.Keys)
            {
                this.packageCheckedList.Items.Add(package, project.includePackages.Contains(package));
            }
        }

        private void SelectFolderButton_Click(object sender, EventArgs e)
        {
            var folderDialog = new CommonOpenFileDialog();
            folderDialog.IsFolderPicker = true;
            folderDialog.Multiselect = false;
            var result = folderDialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                this.PathTextBox.Text = folderDialog.FileName;
            }
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            this.Project.Name = this.NameTextBox.Text;
        }

        private void PathTextBox_TextChanged(object sender, EventArgs e)
        {
            this.Project.Path = this.PathTextBox.Text;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var key = (string)this.packageCheckedList.Items[e.Index];
            if (e.NewValue == CheckState.Checked)
            {
                this.Project.includePackages.Add(key);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                this.Project.includePackages.Remove(key);
            }
        }
    }
}
