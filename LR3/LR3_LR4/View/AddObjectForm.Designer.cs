
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
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
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
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(226, 30);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(305, 30);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AddObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 379);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.EditionComboBoxLabel);
            this.Controls.Add(this.EditionComboBox);
            this.Name = "AddObjectForm";
            this.Text = "AddObjectForm";
            this.Load += new System.EventHandler(this.AddObjectForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox EditionComboBox;
        private System.Windows.Forms.Label EditionComboBoxLabel;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
    }
}