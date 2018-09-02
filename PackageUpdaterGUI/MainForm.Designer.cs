namespace JamesFrowen.PackageUpdater.GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "pack1"),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "e:/testfolder/pack1"),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "Included", System.Drawing.SystemColors.MenuHighlight, System.Drawing.SystemColors.GrayText, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))))}, -1);
            this.addProjectButton = new System.Windows.Forms.Button();
            this.addPackageButton = new System.Windows.Forms.Button();
            this.removeProjectbutton = new System.Windows.Forms.Button();
            this.removePackageButton = new System.Windows.Forms.Button();
            this.projectsListView = new System.Windows.Forms.ListView();
            this.project_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.project_path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.packagesListView = new System.Windows.Forms.ListView();
            this.package_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.package_path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.package_Included = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SaveButton = new System.Windows.Forms.Button();
            this.ReloadButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.editProjectButton = new System.Windows.Forms.Button();
            this.openXmlButton = new System.Windows.Forms.Button();
            this.editPackageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addProjectButton
            // 
            this.addProjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.addProjectButton.Location = new System.Drawing.Point(12, 12);
            this.addProjectButton.Name = "addProjectButton";
            this.addProjectButton.Size = new System.Drawing.Size(180, 40);
            this.addProjectButton.TabIndex = 0;
            this.addProjectButton.Text = "Add Project";
            this.addProjectButton.UseVisualStyleBackColor = true;
            this.addProjectButton.Click += new System.EventHandler(this.addProjectButton_Click);
            // 
            // addPackageButton
            // 
            this.addPackageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.addPackageButton.Location = new System.Drawing.Point(12, 208);
            this.addPackageButton.Name = "addPackageButton";
            this.addPackageButton.Size = new System.Drawing.Size(180, 40);
            this.addPackageButton.TabIndex = 3;
            this.addPackageButton.Text = "Add Package";
            this.addPackageButton.UseVisualStyleBackColor = true;
            this.addPackageButton.Click += new System.EventHandler(this.addPackageButton_Click);
            // 
            // removeProjectbutton
            // 
            this.removeProjectbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.removeProjectbutton.Location = new System.Drawing.Point(198, 12);
            this.removeProjectbutton.Name = "removeProjectbutton";
            this.removeProjectbutton.Size = new System.Drawing.Size(180, 40);
            this.removeProjectbutton.TabIndex = 4;
            this.removeProjectbutton.Text = "Remove Project";
            this.removeProjectbutton.UseVisualStyleBackColor = true;
            this.removeProjectbutton.Click += new System.EventHandler(this.removeProjectbutton_Click);
            // 
            // removePackageButton
            // 
            this.removePackageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.removePackageButton.Location = new System.Drawing.Point(198, 208);
            this.removePackageButton.Name = "removePackageButton";
            this.removePackageButton.Size = new System.Drawing.Size(180, 40);
            this.removePackageButton.TabIndex = 5;
            this.removePackageButton.Text = "Remove Package";
            this.removePackageButton.UseVisualStyleBackColor = true;
            this.removePackageButton.Click += new System.EventHandler(this.removePackageButton_Click);
            // 
            // projectsListView
            // 
            this.projectsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.project_name,
            this.project_path});
            this.projectsListView.FullRowSelect = true;
            this.projectsListView.GridLines = true;
            this.projectsListView.Location = new System.Drawing.Point(12, 58);
            this.projectsListView.MultiSelect = false;
            this.projectsListView.Name = "projectsListView";
            this.projectsListView.Size = new System.Drawing.Size(660, 144);
            this.projectsListView.TabIndex = 6;
            this.projectsListView.UseCompatibleStateImageBehavior = false;
            this.projectsListView.View = System.Windows.Forms.View.Details;
            this.projectsListView.SelectedIndexChanged += new System.EventHandler(this.projectsListView_SelectedIndexChanged);
            // 
            // project_name
            // 
            this.project_name.Text = "Name";
            this.project_name.Width = 131;
            // 
            // project_path
            // 
            this.project_path.Text = "Path";
            this.project_path.Width = 498;
            // 
            // packagesListView
            // 
            this.packagesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.package_name,
            this.package_path,
            this.package_Included});
            this.packagesListView.FullRowSelect = true;
            this.packagesListView.GridLines = true;
            this.packagesListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.packagesListView.Location = new System.Drawing.Point(12, 254);
            this.packagesListView.Name = "packagesListView";
            this.packagesListView.Size = new System.Drawing.Size(660, 144);
            this.packagesListView.TabIndex = 7;
            this.packagesListView.UseCompatibleStateImageBehavior = false;
            this.packagesListView.View = System.Windows.Forms.View.Details;
            // 
            // package_name
            // 
            this.package_name.Tag = "";
            this.package_name.Text = "Name";
            this.package_name.Width = 115;
            // 
            // package_path
            // 
            this.package_path.Text = "SourcePath";
            this.package_path.Width = 468;
            // 
            // package_Included
            // 
            this.package_Included.Text = "Included";
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SaveButton.Location = new System.Drawing.Point(12, 558);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(180, 40);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ReloadButton
            // 
            this.ReloadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ReloadButton.Location = new System.Drawing.Point(198, 558);
            this.ReloadButton.Name = "ReloadButton";
            this.ReloadButton.Size = new System.Drawing.Size(180, 40);
            this.ReloadButton.TabIndex = 9;
            this.ReloadButton.Text = "Reload";
            this.ReloadButton.UseVisualStyleBackColor = true;
            this.ReloadButton.Click += new System.EventHandler(this.ReloadButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UpdateButton.Location = new System.Drawing.Point(438, 404);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(234, 40);
            this.UpdateButton.TabIndex = 10;
            this.UpdateButton.Text = "Send Package To Projects";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // editProjectButton
            // 
            this.editProjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.editProjectButton.Location = new System.Drawing.Point(540, 12);
            this.editProjectButton.Name = "editProjectButton";
            this.editProjectButton.Size = new System.Drawing.Size(132, 40);
            this.editProjectButton.TabIndex = 11;
            this.editProjectButton.Text = "Edit Project";
            this.editProjectButton.UseVisualStyleBackColor = true;
            this.editProjectButton.Click += new System.EventHandler(this.editProjectButton_Click);
            // 
            // openXmlButton
            // 
            this.openXmlButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.openXmlButton.Location = new System.Drawing.Point(492, 558);
            this.openXmlButton.Name = "openXmlButton";
            this.openXmlButton.Size = new System.Drawing.Size(180, 40);
            this.openXmlButton.TabIndex = 12;
            this.openXmlButton.Text = "Open XML";
            this.openXmlButton.UseVisualStyleBackColor = true;
            this.openXmlButton.Click += new System.EventHandler(this.openXmlButton_Click);
            // 
            // editPackageButton
            // 
            this.editPackageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.editPackageButton.Location = new System.Drawing.Point(540, 208);
            this.editPackageButton.Name = "editPackageButton";
            this.editPackageButton.Size = new System.Drawing.Size(132, 40);
            this.editPackageButton.TabIndex = 13;
            this.editPackageButton.Text = "Edit Package";
            this.editPackageButton.UseVisualStyleBackColor = true;
            this.editPackageButton.Click += new System.EventHandler(this.editPackageButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 610);
            this.Controls.Add(this.editPackageButton);
            this.Controls.Add(this.openXmlButton);
            this.Controls.Add(this.editProjectButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.ReloadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.packagesListView);
            this.Controls.Add(this.projectsListView);
            this.Controls.Add(this.addPackageButton);
            this.Controls.Add(this.removePackageButton);
            this.Controls.Add(this.removeProjectbutton);
            this.Controls.Add(this.addProjectButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addProjectButton;
        private System.Windows.Forms.Button addPackageButton;
        private System.Windows.Forms.Button removeProjectbutton;
        private System.Windows.Forms.Button removePackageButton;
        private System.Windows.Forms.ListView projectsListView;
        private System.Windows.Forms.ColumnHeader project_name;
        private System.Windows.Forms.ColumnHeader project_path;
        private System.Windows.Forms.ListView packagesListView;
        private System.Windows.Forms.ColumnHeader package_name;
        private System.Windows.Forms.ColumnHeader package_path;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ReloadButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.ColumnHeader package_Included;
        private System.Windows.Forms.Button editProjectButton;
        private System.Windows.Forms.Button openXmlButton;
        private System.Windows.Forms.Button editPackageButton;
    }
}

