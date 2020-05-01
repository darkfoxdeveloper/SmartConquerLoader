namespace SCLManager
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.csvManager = new System.Windows.Forms.ListView();
            this.ServerName = new System.Windows.Forms.ColumnHeader();
            this.Host = new System.Windows.Forms.ColumnHeader();
            this.EnableHostName = new System.Windows.Forms.ColumnHeader();
            this.HostName = new System.Windows.Forms.ColumnHeader();
            this.GamePort = new System.Windows.Forms.ColumnHeader();
            this.LoginPort = new System.Windows.Forms.ColumnHeader();
            this.NameConquerExecutable = new System.Windows.Forms.ColumnHeader();
            this.ExecuteInSubFolder = new System.Windows.Forms.ColumnHeader();
            this.Image = new System.Windows.Forms.ColumnHeader();
            this.Version = new System.Windows.Forms.ColumnHeader();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // csvManager
            // 
            this.csvManager.AllowColumnReorder = true;
            this.csvManager.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.csvManager.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ServerName,
            this.Host,
            this.EnableHostName,
            this.HostName,
            this.GamePort,
            this.LoginPort,
            this.NameConquerExecutable,
            this.ExecuteInSubFolder,
            this.Image,
            this.Version});
            this.csvManager.HideSelection = false;
            this.csvManager.Location = new System.Drawing.Point(0, 0);
            this.csvManager.MultiSelect = false;
            this.csvManager.Name = "csvManager";
            this.csvManager.Size = new System.Drawing.Size(2027, 204);
            this.csvManager.TabIndex = 0;
            this.csvManager.UseCompatibleStateImageBehavior = false;
            this.csvManager.View = System.Windows.Forms.View.Details;
            // 
            // ServerName
            // 
            this.ServerName.Name = "ServerName";
            this.ServerName.Text = "ServerName";
            this.ServerName.Width = 200;
            // 
            // Host
            // 
            this.Host.Name = "Host";
            this.Host.Text = "Host";
            this.Host.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Host.Width = 200;
            // 
            // EnableHostName
            // 
            this.EnableHostName.Name = "EnableHostName";
            this.EnableHostName.Text = "EnableHostName";
            this.EnableHostName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EnableHostName.Width = 200;
            // 
            // HostName
            // 
            this.HostName.Name = "HostName";
            this.HostName.Text = "HostName";
            this.HostName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.HostName.Width = 200;
            // 
            // GamePort
            // 
            this.GamePort.Name = "GamePort";
            this.GamePort.Text = "GamePort";
            this.GamePort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.GamePort.Width = 200;
            // 
            // LoginPort
            // 
            this.LoginPort.Name = "LoginPort";
            this.LoginPort.Text = "LoginPort";
            this.LoginPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LoginPort.Width = 200;
            // 
            // NameConquerExecutable
            // 
            this.NameConquerExecutable.Name = "NameConquerExecutable";
            this.NameConquerExecutable.Text = "NameConquerExecutable";
            this.NameConquerExecutable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NameConquerExecutable.Width = 200;
            // 
            // ExecuteInSubFolder
            // 
            this.ExecuteInSubFolder.Name = "ExecuteInSubFolder";
            this.ExecuteInSubFolder.Text = "ExecuteInSubFolder";
            this.ExecuteInSubFolder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ExecuteInSubFolder.Width = 200;
            // 
            // Image
            // 
            this.Image.Name = "Image";
            this.Image.Text = "Image";
            this.Image.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Image.Width = 200;
            // 
            // Version
            // 
            this.Version.Name = "Version";
            this.Version.Text = "Version";
            this.Version.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Version.Width = 200;
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.Black;
            this.btnAddNew.FlatAppearance.BorderSize = 0;
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Font = new System.Drawing.Font("Caladea", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddNew.ForeColor = System.Drawing.Color.White;
            this.btnAddNew.Location = new System.Drawing.Point(1883, 220);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(132, 40);
            this.btnAddNew.TabIndex = 1;
            this.btnAddNew.Text = "Add new";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.BtnAddNew_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(2027, 272);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.csvManager);
            this.Font = new System.Drawing.Font("Caladea", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "SCLManager";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView csvManager;
        private System.Windows.Forms.ColumnHeader ServerName;
        private System.Windows.Forms.ColumnHeader Host;
        private System.Windows.Forms.ColumnHeader EnableHostName;
        private System.Windows.Forms.ColumnHeader HostName;
        private System.Windows.Forms.ColumnHeader GamePort;
        private System.Windows.Forms.ColumnHeader LoginPort;
        private System.Windows.Forms.ColumnHeader NameConquerExecutable;
        private System.Windows.Forms.ColumnHeader ExecuteInSubFolder;
        private System.Windows.Forms.ColumnHeader Image;
        private System.Windows.Forms.ColumnHeader Version;
        private System.Windows.Forms.Button btnAddNew;
    }
}

