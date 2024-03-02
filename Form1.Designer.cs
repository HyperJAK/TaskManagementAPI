namespace ClassFormWithDb
{
    partial class Form1
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
            allBooksComboBox = new ComboBox();
            categoryComboBox = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            allInfoBox = new RichTextBox();
            SuspendLayout();
            // 
            // allBooksComboBox
            // 
            allBooksComboBox.FormattingEnabled = true;
            allBooksComboBox.Location = new Point(542, 70);
            allBooksComboBox.Name = "allBooksComboBox";
            allBooksComboBox.Size = new Size(190, 23);
            allBooksComboBox.TabIndex = 2;
            allBooksComboBox.SelectedIndexChanged += allBooksComboBox_SelectedIndexChanged;
            // 
            // categoryComboBox
            // 
            categoryComboBox.FormattingEnabled = true;
            categoryComboBox.Location = new Point(542, 41);
            categoryComboBox.Name = "categoryComboBox";
            categoryComboBox.Size = new Size(190, 23);
            categoryComboBox.TabIndex = 9;
            categoryComboBox.SelectedIndexChanged += categoryComboBox_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(429, 41);
            label5.Name = "label5";
            label5.Size = new Size(107, 15);
            label5.TabIndex = 8;
            label5.Text = "Search by category";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(432, 73);
            label6.Name = "label6";
            label6.Size = new Size(81, 15);
            label6.TabIndex = 10;
            label6.Text = "Search by title";
            // 
            // allInfoBox
            // 
            allInfoBox.Location = new Point(21, 117);
            allInfoBox.Name = "allInfoBox";
            allInfoBox.Size = new Size(457, 265);
            allInfoBox.TabIndex = 11;
            allInfoBox.Text = "";
            allInfoBox.TextChanged += allInfoBox_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(allInfoBox);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(categoryComboBox);
            Controls.Add(allBooksComboBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox allBooksComboBox;
        private ComboBox categoryComboBox;
        private Label label5;
        private Label label6;
        private RichTextBox allInfoBox;
    }
}
