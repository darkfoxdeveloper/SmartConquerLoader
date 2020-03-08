namespace SCLManager
{
    partial class ChangeConfiguration
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
            this.tbServerName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.cbUseHostName = new System.Windows.Forms.CheckBox();
            this.tbHostName = new System.Windows.Forms.TextBox();
            this.tbGamePort = new System.Windows.Forms.TextBox();
            this.tbLoginPort = new System.Windows.Forms.TextBox();
            this.tbNameConquerExecutable = new System.Windows.Forms.TextBox();
            this.tbExecuteInSubFolder = new System.Windows.Forms.TextBox();
            this.tbImage = new System.Windows.Forms.TextBox();
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.tbGameCryptographyKey = new System.Windows.Forms.TextBox();
            this.btnGetGameCryptKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbServerName
            // 
            this.tbServerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbServerName.Font = new System.Drawing.Font("Caladea", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbServerName.Location = new System.Drawing.Point(12, 12);
            this.tbServerName.Name = "tbServerName";
            this.tbServerName.PlaceholderText = "ServerName";
            this.tbServerName.Size = new System.Drawing.Size(226, 31);
            this.tbServerName.TabIndex = 0;
            this.tbServerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Caladea", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(12, 244);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(543, 44);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // tbHost
            // 
            this.tbHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbHost.Font = new System.Drawing.Font("Caladea", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbHost.Location = new System.Drawing.Point(12, 49);
            this.tbHost.Name = "tbHost";
            this.tbHost.PlaceholderText = "Host";
            this.tbHost.Size = new System.Drawing.Size(226, 31);
            this.tbHost.TabIndex = 0;
            this.tbHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbUseHostName
            // 
            this.cbUseHostName.AutoSize = true;
            this.cbUseHostName.Location = new System.Drawing.Point(81, 91);
            this.cbUseHostName.Name = "cbUseHostName";
            this.cbUseHostName.Size = new System.Drawing.Size(157, 29);
            this.cbUseHostName.TabIndex = 2;
            this.cbUseHostName.Text = "Use HostName";
            this.cbUseHostName.UseVisualStyleBackColor = true;
            this.cbUseHostName.CheckedChanged += new System.EventHandler(this.CbUseHostName_CheckedChanged);
            // 
            // tbHostName
            // 
            this.tbHostName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbHostName.Enabled = false;
            this.tbHostName.Font = new System.Drawing.Font("Caladea", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbHostName.Location = new System.Drawing.Point(12, 131);
            this.tbHostName.Name = "tbHostName";
            this.tbHostName.PlaceholderText = "HostName";
            this.tbHostName.Size = new System.Drawing.Size(226, 31);
            this.tbHostName.TabIndex = 0;
            this.tbHostName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbGamePort
            // 
            this.tbGamePort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbGamePort.Font = new System.Drawing.Font("Caladea", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbGamePort.Location = new System.Drawing.Point(12, 168);
            this.tbGamePort.Name = "tbGamePort";
            this.tbGamePort.PlaceholderText = "GamePort";
            this.tbGamePort.Size = new System.Drawing.Size(226, 31);
            this.tbGamePort.TabIndex = 0;
            this.tbGamePort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbLoginPort
            // 
            this.tbLoginPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLoginPort.Font = new System.Drawing.Font("Caladea", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbLoginPort.Location = new System.Drawing.Point(12, 205);
            this.tbLoginPort.Name = "tbLoginPort";
            this.tbLoginPort.PlaceholderText = "LoginPort";
            this.tbLoginPort.Size = new System.Drawing.Size(226, 31);
            this.tbLoginPort.TabIndex = 0;
            this.tbLoginPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbNameConquerExecutable
            // 
            this.tbNameConquerExecutable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNameConquerExecutable.Font = new System.Drawing.Font("Caladea", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbNameConquerExecutable.Location = new System.Drawing.Point(255, 12);
            this.tbNameConquerExecutable.Name = "tbNameConquerExecutable";
            this.tbNameConquerExecutable.PlaceholderText = "NameConquerExecutable";
            this.tbNameConquerExecutable.Size = new System.Drawing.Size(226, 31);
            this.tbNameConquerExecutable.TabIndex = 0;
            this.tbNameConquerExecutable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbExecuteInSubFolder
            // 
            this.tbExecuteInSubFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbExecuteInSubFolder.Font = new System.Drawing.Font("Caladea", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbExecuteInSubFolder.Location = new System.Drawing.Point(255, 49);
            this.tbExecuteInSubFolder.Name = "tbExecuteInSubFolder";
            this.tbExecuteInSubFolder.PlaceholderText = "ExecuteInSubFolder";
            this.tbExecuteInSubFolder.Size = new System.Drawing.Size(226, 31);
            this.tbExecuteInSubFolder.TabIndex = 0;
            this.tbExecuteInSubFolder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbImage
            // 
            this.tbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbImage.Font = new System.Drawing.Font("Caladea", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbImage.Location = new System.Drawing.Point(255, 89);
            this.tbImage.Name = "tbImage";
            this.tbImage.PlaceholderText = "Image";
            this.tbImage.Size = new System.Drawing.Size(226, 31);
            this.tbImage.TabIndex = 0;
            this.tbImage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbVersion
            // 
            this.tbVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbVersion.Font = new System.Drawing.Font("Caladea", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbVersion.Location = new System.Drawing.Point(255, 126);
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.PlaceholderText = "Version";
            this.tbVersion.Size = new System.Drawing.Size(226, 31);
            this.tbVersion.TabIndex = 0;
            this.tbVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbGameCryptographyKey
            // 
            this.tbGameCryptographyKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbGameCryptographyKey.Font = new System.Drawing.Font("Caladea", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbGameCryptographyKey.Location = new System.Drawing.Point(255, 205);
            this.tbGameCryptographyKey.Name = "tbGameCryptographyKey";
            this.tbGameCryptographyKey.PlaceholderText = "GameCryptographyKey";
            this.tbGameCryptographyKey.Size = new System.Drawing.Size(226, 31);
            this.tbGameCryptographyKey.TabIndex = 0;
            this.tbGameCryptographyKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnGetGameCryptKey
            // 
            this.btnGetGameCryptKey.Font = new System.Drawing.Font("Caladea", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGetGameCryptKey.Location = new System.Drawing.Point(487, 204);
            this.btnGetGameCryptKey.Name = "btnGetGameCryptKey";
            this.btnGetGameCryptKey.Size = new System.Drawing.Size(68, 32);
            this.btnGetGameCryptKey.TabIndex = 3;
            this.btnGetGameCryptKey.Text = "GET";
            this.btnGetGameCryptKey.UseVisualStyleBackColor = true;
            this.btnGetGameCryptKey.Click += new System.EventHandler(this.BtnGetGameCryptKey_Click);
            // 
            // ChangeConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 293);
            this.Controls.Add(this.tbGameCryptographyKey);
            this.Controls.Add(this.tbExecuteInSubFolder);
            this.Controls.Add(this.tbImage);
            this.Controls.Add(this.tbVersion);
            this.Controls.Add(this.tbNameConquerExecutable);
            this.Controls.Add(this.btnGetGameCryptKey);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbLoginPort);
            this.Controls.Add(this.tbGamePort);
            this.Controls.Add(this.tbHostName);
            this.Controls.Add(this.tbHost);
            this.Controls.Add(this.cbUseHostName);
            this.Controls.Add(this.tbServerName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ChangeConfiguration";
            this.Text = "Change Configuration - SCLManager";
            this.Load += new System.EventHandler(this.ChangeUserConfiguration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbServerName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbHostName;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.CheckBox cbUseHostName;
        private System.Windows.Forms.TextBox tbGamePort;
        private System.Windows.Forms.TextBox tbLoginPort;
        private System.Windows.Forms.TextBox tbNameConquerExecutable;
        private System.Windows.Forms.TextBox tbExecuteInSubFolder;
        private System.Windows.Forms.TextBox tbVersion;
        private System.Windows.Forms.TextBox tbImage;
        private System.Windows.Forms.TextBox tbGameCryptographyKey;
        private System.Windows.Forms.Button btnGetGameCryptKey;
    }
}