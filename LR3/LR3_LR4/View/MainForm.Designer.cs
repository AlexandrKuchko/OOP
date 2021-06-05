
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
            this.SkipSearchButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.EditionListBox = new System.Windows.Forms.ListBox();
            this.RemoveObjectButton = new System.Windows.Forms.Button();
            this.AddObjectButton = new System.Windows.Forms.Button();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.MainOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.MainSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.MainGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainGroupBox
            // 
            this.MainGroupBox.Controls.Add(this.SkipSearchButton);
            this.MainGroupBox.Controls.Add(this.SearchButton);
            this.MainGroupBox.Controls.Add(this.EditionListBox);
            this.MainGroupBox.Controls.Add(this.RemoveObjectButton);
            this.MainGroupBox.Controls.Add(this.AddObjectButton);
            this.MainGroupBox.Location = new System.Drawing.Point(12, 12);
            this.MainGroupBox.Name = "MainGroupBox";
            this.MainGroupBox.Size = new System.Drawing.Size(517, 329);
            this.MainGroupBox.TabIndex = 0;
            this.MainGroupBox.TabStop = false;
            this.MainGroupBox.Text = "Edition list";
            // 
            // SkipSearchButton
            // 
            this.SkipSearchButton.Location = new System.Drawing.Point(422, 293);
            this.SkipSearchButton.Name = "SkipSearchButton";
            this.SkipSearchButton.Size = new System.Drawing.Size(81, 25);
            this.SkipSearchButton.TabIndex = 5;
            this.SkipSearchButton.Text = "Reset search";
            this.SkipSearchButton.UseVisualStyleBackColor = true;
            this.SkipSearchButton.Click += new System.EventHandler(this.SkipSearchButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(335, 293);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(81, 25);
            this.SearchButton.TabIndex = 4;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // EditionListBox
            // 
            this.EditionListBox.FormattingEnabled = true;
            this.EditionListBox.ItemHeight = 15;
            this.EditionListBox.Location = new System.Drawing.Point(17, 22);
            this.EditionListBox.Name = "EditionListBox";
            this.EditionListBox.Size = new System.Drawing.Size(486, 259);
            this.EditionListBox.TabIndex = 3;
            // 
            // RemoveObjectButton
            // 
            this.RemoveObjectButton.Location = new System.Drawing.Point(105, 293);
            this.RemoveObjectButton.Name = "RemoveObjectButton";
            this.RemoveObjectButton.Size = new System.Drawing.Size(102, 25);
            this.RemoveObjectButton.TabIndex = 2;
            this.RemoveObjectButton.Text = "Remove object";
            this.RemoveObjectButton.UseVisualStyleBackColor = true;
            this.RemoveObjectButton.Click += new System.EventHandler(this.RemoveObjectButton_Click);
            // 
            // AddObjectButton
            // 
            this.AddObjectButton.Location = new System.Drawing.Point(17, 293);
            this.AddObjectButton.Name = "AddObjectButton";
            this.AddObjectButton.Size = new System.Drawing.Size(82, 25);
            this.AddObjectButton.TabIndex = 1;
            this.AddObjectButton.Text = "Add object";
            this.AddObjectButton.UseVisualStyleBackColor = true;
            this.AddObjectButton.Click += new System.EventHandler(this.AddObjectButton_Click);
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveFileButton.Location = new System.Drawing.Point(535, 72);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(74, 26);
            this.SaveFileButton.TabIndex = 5;
            this.SaveFileButton.Text = "Save file";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            this.SaveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(535, 40);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(74, 26);
            this.OpenFileButton.TabIndex = 4;
            this.OpenFileButton.Text = "Open file";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // MainOpenFileDialog
            // 
            this.MainOpenFileDialog.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 355);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.SaveFileButton);
            this.Controls.Add(this.MainGroupBox);
            this.Name = "MainForm";
            this.Text = "Edition data";
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
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.SaveFileDialog MainSaveFileDialog;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button SkipSearchButton;
    }
}

