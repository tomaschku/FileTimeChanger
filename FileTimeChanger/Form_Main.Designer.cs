namespace FileTimeChanger
{
    partial class Form_Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.Open_File = new System.Windows.Forms.Button();
            this.Picker_Creation = new System.Windows.Forms.DateTimePicker();
            this.Picker_LastChanged = new System.Windows.Forms.DateTimePicker();
            this.Picker_LastAccessed = new System.Windows.Forms.DateTimePicker();
            this.Use_UTC = new System.Windows.Forms.CheckBox();
            this.Apply = new System.Windows.Forms.Button();
            this.Close_File = new System.Windows.Forms.Button();
            this.Label_Pickers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Open_File
            // 
            this.Open_File.AllowDrop = true;
            this.Open_File.Location = new System.Drawing.Point(12, 12);
            this.Open_File.Name = "Open_File";
            this.Open_File.Size = new System.Drawing.Size(113, 47);
            this.Open_File.TabIndex = 0;
            this.Open_File.Text = "Open File";
            this.Open_File.UseVisualStyleBackColor = true;
            this.Open_File.Click += new System.EventHandler(this.Open_File_Click);
            // 
            // Picker_Creation
            // 
            this.Picker_Creation.CustomFormat = "dd (ddd) MM (MMM) yyyy HH:mm:ss";
            this.Picker_Creation.Enabled = false;
            this.Picker_Creation.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Picker_Creation.Location = new System.Drawing.Point(147, 39);
            this.Picker_Creation.Name = "Picker_Creation";
            this.Picker_Creation.Size = new System.Drawing.Size(250, 20);
            this.Picker_Creation.TabIndex = 1;
            this.Picker_Creation.Value = new System.DateTime(2019, 8, 29, 0, 0, 0, 0);
            this.Picker_Creation.ValueChanged += new System.EventHandler(this.Picker_Creation_ValueChanged);
            // 
            // Picker_LastChanged
            // 
            this.Picker_LastChanged.CustomFormat = "dd (ddd) MM (MMM) yyyy HH:mm:ss";
            this.Picker_LastChanged.Enabled = false;
            this.Picker_LastChanged.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Picker_LastChanged.Location = new System.Drawing.Point(147, 65);
            this.Picker_LastChanged.Name = "Picker_LastChanged";
            this.Picker_LastChanged.Size = new System.Drawing.Size(250, 20);
            this.Picker_LastChanged.TabIndex = 2;
            this.Picker_LastChanged.Value = new System.DateTime(2019, 8, 29, 0, 0, 0, 0);
            this.Picker_LastChanged.ValueChanged += new System.EventHandler(this.Picker_LastChanged_ValueChanged);
            // 
            // Picker_LastAccessed
            // 
            this.Picker_LastAccessed.CustomFormat = "dd (ddd) MM (MMM) yyyy HH:mm:ss";
            this.Picker_LastAccessed.Enabled = false;
            this.Picker_LastAccessed.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Picker_LastAccessed.Location = new System.Drawing.Point(147, 91);
            this.Picker_LastAccessed.Name = "Picker_LastAccessed";
            this.Picker_LastAccessed.Size = new System.Drawing.Size(250, 20);
            this.Picker_LastAccessed.TabIndex = 3;
            this.Picker_LastAccessed.Value = new System.DateTime(2019, 8, 29, 0, 0, 0, 0);
            this.Picker_LastAccessed.ValueChanged += new System.EventHandler(this.Picker_LastAccessed_ValueChanged);
            // 
            // Use_UTC
            // 
            this.Use_UTC.AutoSize = true;
            this.Use_UTC.Enabled = false;
            this.Use_UTC.Location = new System.Drawing.Point(147, 12);
            this.Use_UTC.Name = "Use_UTC";
            this.Use_UTC.Size = new System.Drawing.Size(48, 17);
            this.Use_UTC.TabIndex = 4;
            this.Use_UTC.Text = "UTC";
            this.Use_UTC.UseVisualStyleBackColor = true;
            this.Use_UTC.CheckedChanged += new System.EventHandler(this.Use_UTC_CheckedChanged);
            // 
            // Apply
            // 
            this.Apply.Enabled = false;
            this.Apply.Location = new System.Drawing.Point(12, 117);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(113, 43);
            this.Apply.TabIndex = 5;
            this.Apply.Text = "Apply";
            this.Apply.UseVisualStyleBackColor = true;
            this.Apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // Close_File
            // 
            this.Close_File.Enabled = false;
            this.Close_File.Location = new System.Drawing.Point(12, 64);
            this.Close_File.Name = "Close_File";
            this.Close_File.Size = new System.Drawing.Size(113, 47);
            this.Close_File.TabIndex = 6;
            this.Close_File.Text = "Close File";
            this.Close_File.UseVisualStyleBackColor = true;
            this.Close_File.Click += new System.EventHandler(this.Close_File_Click);
            // 
            // Label_Pickers
            // 
            this.Label_Pickers.AutoSize = true;
            this.Label_Pickers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Pickers.Location = new System.Drawing.Point(401, 42);
            this.Label_Pickers.Name = "Label_Pickers";
            this.Label_Pickers.Size = new System.Drawing.Size(90, 65);
            this.Label_Pickers.TabIndex = 7;
            this.Label_Pickers.Text = "Creation\r\n\r\nLast Changed\r\n\r\nLast Accessed";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 170);
            this.Controls.Add(this.Label_Pickers);
            this.Controls.Add(this.Close_File);
            this.Controls.Add(this.Apply);
            this.Controls.Add(this.Use_UTC);
            this.Controls.Add(this.Picker_LastAccessed);
            this.Controls.Add(this.Picker_LastChanged);
            this.Controls.Add(this.Picker_Creation);
            this.Controls.Add(this.Open_File);
            this.Name = "Form_Main";
            this.Text = "File Time Changer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Open_File;
        private System.Windows.Forms.DateTimePicker Picker_Creation;
        private System.Windows.Forms.DateTimePicker Picker_LastChanged;
        private System.Windows.Forms.DateTimePicker Picker_LastAccessed;
        private System.Windows.Forms.CheckBox Use_UTC;
        private System.Windows.Forms.Button Apply;
        private System.Windows.Forms.Button Close_File;
        private System.Windows.Forms.Label Label_Pickers;
    }
}

