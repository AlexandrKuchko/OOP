
namespace View
{
    partial class MainForm
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
            this.MainGroupBox = new System.Windows.Forms.GroupBox();
            this.OpenFile = new System.Windows.Forms.Button();
            this.EditionListBox = new System.Windows.Forms.ListBox();
            this.RemoveObjectButton = new System.Windows.Forms.Button();
            this.AddObjectButton = new System.Windows.Forms.Button();
            this.MainOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.MainGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainGroupBox
            // 
            this.MainGroupBox.Controls.Add(this.OpenFile);
            this.MainGroupBox.Controls.Add(this.EditionListBox);
            this.MainGroupBox.Controls.Add(this.RemoveObjectButton);
            this.MainGroupBox.Controls.Add(this.AddObjectButton);
            this.MainGroupBox.Location = new System.Drawing.Point(22, 25);
            this.MainGroupBox.Name = "MainGroupBox";
            this.MainGroupBox.Size = new System.Drawing.Size(517, 366);
            this.MainGroupBox.TabIndex = 0;
            this.MainGroupBox.TabStop = false;
            this.MainGroupBox.Text = "MainGroupBox";
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(68, 38);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(240, 44);
            this.OpenFile.TabIndex = 4;
            this.OpenFile.Text = "OpenFileButton";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // EditionListBox
            // 
            this.EditionListBox.FormattingEnabled = true;
            this.EditionListBox.ItemHeight = 15;
            this.EditionListBox.Location = new System.Drawing.Point(68, 88);
            this.EditionListBox.Name = "EditionListBox";
            this.EditionListBox.Size = new System.Drawing.Size(240, 184);
            this.EditionListBox.TabIndex = 3;
            // 
            // RemoveObjectButton
            // 
            this.RemoveObjectButton.Location = new System.Drawing.Point(192, 278);
            this.RemoveObjectButton.Name = "RemoveObjectButton";
            this.RemoveObjectButton.Size = new System.Drawing.Size(116, 41);
            this.RemoveObjectButton.TabIndex = 2;
            this.RemoveObjectButton.Text = "Remove object";
            this.RemoveObjectButton.UseVisualStyleBackColor = true;
            // 
            // AddObjectButton
            // 
            this.AddObjectButton.Location = new System.Drawing.Point(68, 278);
            this.AddObjectButton.Name = "AddObjectButton";
            this.AddObjectButton.Size = new System.Drawing.Size(110, 41);
            this.AddObjectButton.TabIndex = 1;
            this.AddObjectButton.Text = "Add object";
            this.AddObjectButton.UseVisualStyleBackColor = true;
            this.AddObjectButton.Click += new System.EventHandler(this.AddObjectButton_Click);
            // 
            // MainOpenFileDialog
            // 
            this.MainOpenFileDialog.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainGroupBox);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.MainGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MainGroupBox;
        private System.Windows.Forms.Button AddObjectButton;
        private System.Windows.Forms.Button RemoveObjectButton;
        private System.Windows.Forms.ListBox EditionListBox;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.OpenFileDialog MainOpenFileDialog;
        private System.Windows.Forms.Button OpenFile;
    }
}

