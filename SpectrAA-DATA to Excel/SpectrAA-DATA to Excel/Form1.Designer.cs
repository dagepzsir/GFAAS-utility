namespace SpectrAA_DATA_to_Excel
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fileRadioButton = new System.Windows.Forms.RadioButton();
            this.folderRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.xlsRadioButton = new System.Windows.Forms.RadioButton();
            this.csvRadioButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.folderRadioButton);
            this.groupBox1.Controls.Add(this.fileRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(86, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Open options";
            // 
            // fileRadioButton
            // 
            this.fileRadioButton.AutoSize = true;
            this.fileRadioButton.Checked = true;
            this.fileRadioButton.Location = new System.Drawing.Point(6, 15);
            this.fileRadioButton.Name = "fileRadioButton";
            this.fileRadioButton.Size = new System.Drawing.Size(41, 17);
            this.fileRadioButton.TabIndex = 0;
            this.fileRadioButton.TabStop = true;
            this.fileRadioButton.Text = "File";
            this.fileRadioButton.UseVisualStyleBackColor = true;
            // 
            // folderRadioButton
            // 
            this.folderRadioButton.AutoSize = true;
            this.folderRadioButton.Location = new System.Drawing.Point(6, 38);
            this.folderRadioButton.Name = "folderRadioButton";
            this.folderRadioButton.Size = new System.Drawing.Size(54, 17);
            this.folderRadioButton.TabIndex = 1;
            this.folderRadioButton.Text = "Folder";
            this.folderRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.csvRadioButton);
            this.groupBox2.Controls.Add(this.xlsRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(11, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(86, 59);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output format";
            // 
            // xlsRadioButton
            // 
            this.xlsRadioButton.AutoSize = true;
            this.xlsRadioButton.Checked = true;
            this.xlsRadioButton.Location = new System.Drawing.Point(6, 15);
            this.xlsRadioButton.Name = "xlsRadioButton";
            this.xlsRadioButton.Size = new System.Drawing.Size(37, 17);
            this.xlsRadioButton.TabIndex = 0;
            this.xlsRadioButton.TabStop = true;
            this.xlsRadioButton.Text = "xls";
            this.xlsRadioButton.UseVisualStyleBackColor = true;
            // 
            // csvRadioButton
            // 
            this.csvRadioButton.AutoSize = true;
            this.csvRadioButton.Location = new System.Drawing.Point(6, 38);
            this.csvRadioButton.Name = "csvRadioButton";
            this.csvRadioButton.Size = new System.Drawing.Size(42, 17);
            this.csvRadioButton.TabIndex = 1;
            this.csvRadioButton.Text = "csv";
            this.csvRadioButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 124);
            this.button1.TabIndex = 2;
            this.button1.Text = "Convert";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(91, 142);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sample name:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 177);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton folderRadioButton;
        private System.Windows.Forms.RadioButton fileRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton csvRadioButton;
        private System.Windows.Forms.RadioButton xlsRadioButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

