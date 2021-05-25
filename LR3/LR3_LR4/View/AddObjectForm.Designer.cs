
namespace View
{
    partial class AddObjectForm
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
            this.EditionComboBox = new System.Windows.Forms.ComboBox();
            this.EditionComboBoxLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.CreateRandomDataButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EditionComboBox
            // 
            this.EditionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EditionComboBox.FormattingEnabled = true;
            this.EditionComboBox.Location = new System.Drawing.Point(81, 30);
            this.EditionComboBox.Name = "EditionComboBox";
            this.EditionComboBox.Size = new System.Drawing.Size(121, 23);
            this.EditionComboBox.TabIndex = 0;
            this.EditionComboBox.SelectionChangeCommitted += new System.EventHandler(this.EditionComboBox_SelectionChangeCommitted);
            // 
            // EditionComboBoxLabel
            // 
            this.EditionComboBoxLabel.AutoSize = true;
            this.EditionComboBoxLabel.Location = new System.Drawing.Point(34, 33);
            this.EditionComboBoxLabel.Name = "EditionComboBoxLabel";
            this.EditionComboBoxLabel.Size = new System.Drawing.Size(41, 15);
            this.EditionComboBoxLabel.TabIndex = 1;
            this.EditionComboBoxLabel.Text = "Editon";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(162, 359);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(81, 359);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CreateRandomDataButton
            // 
            this.CreateRandomDataButton.Location = new System.Drawing.Point(223, 30);
            this.CreateRandomDataButton.Name = "CreateRandomDataButton";
            this.CreateRandomDataButton.Size = new System.Drawing.Size(124, 23);
            this.CreateRandomDataButton.TabIndex = 5;
            this.CreateRandomDataButton.Text = "Create random data";
            this.CreateRandomDataButton.UseVisualStyleBackColor = true;
            this.CreateRandomDataButton.Click += new System.EventHandler(this.CreateRandomDataButton_Click);
            // 
            // AddObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 403);
            this.Controls.Add(this.CreateRandomDataButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.EditionComboBoxLabel);
            this.Controls.Add(this.EditionComboBox);
            this.Name = "AddObjectForm";
            this.Text = "Add editon in edition list";
            this.Load += new System.EventHandler(this.AddObjectForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox EditionComboBox;
        private System.Windows.Forms.Label EditionComboBoxLabel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CreateRandomDataButton;
    }
}