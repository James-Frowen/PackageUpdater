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
    public partial class EditProjectForm : Form
    {
        private Button button1;

        public NamedFolder NamedFolder { get; }
        public PackageList packages { get; }

        public EditProjectForm(NamedFolder namedFolder, PackageList packages)
        {
            InitializeComponent();

            this.NamedFolder = namedFolder;
            this.packages = packages;

            this.NameTextBox.Text = this.NamedFolder.Name;
            this.PathTextBox.Text = this.NamedFolder.Path;

            this.packageCheckedList.Items.Clear();
            foreach (var package in packages.Keys)
            {
                bool isChecked = this.NamedFolder.Dependencies.Contains(package);
                this.packageCheckedList.Items.Add(package, isChecked);
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
            this.NamedFolder.Name = this.NameTextBox.Text;
        }

        private void PathTextBox_TextChanged(object sender, EventArgs e)
        {
            this.NamedFolder.Path = this.PathTextBox.Text;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var key = (string)this.packageCheckedList.Items[e.Index];
            if (e.NewValue == CheckState.Checked)
            {
                this.NamedFolder.Dependencies.Add(key);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                this.NamedFolder.Dependencies.Remove(key);
            }
        }
    }
}
