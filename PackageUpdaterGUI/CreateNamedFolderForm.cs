using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace JamesFrowen.PackageUpdater.GUI
{
    public partial class CreateNamedFolderForm : Form
    {
        public Action<string, string> CreateAction { get; private set; }

        public CreateNamedFolderForm()
        {
            InitializeComponent();
        }


        public void CreateNamedFolder(Action<string, string> createAction)
        {
            this.CreateAction = createAction;
            this.Show();
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
                this.Focus();
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            this.CreateAction.Invoke(this.NameTextBox.Text, this.PathTextBox.Text);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void textChanged(object sender, EventArgs e)
        {
            var nameNotEmpty = this.NameTextBox.Text != "";
            var pathNotEmpty = this.PathTextBox.Text != "";

            this.CreateButton.Enabled = nameNotEmpty && pathNotEmpty;
        }
    }
}
