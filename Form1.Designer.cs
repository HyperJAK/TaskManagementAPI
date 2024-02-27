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
            addBook = new Button();
            bookAdder = new Panel();
            pages = new Label();
            author = new Label();
            category = new Label();
            Title = new Label();
            submitBook = new Button();
            pagesBox = new NumericUpDown();
            categoryBox = new TextBox();
            authorBox = new TextBox();
            titleBox = new TextBox();
            allBooksComboBox = new ComboBox();
            updateBookPanel = new Panel();
            deleteBookBtn = new Button();
            modifyCategory = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            saveChanges = new Button();
            updatePagesBox = new NumericUpDown();
            updateCatBox = new TextBox();
            updateAuthorBox = new TextBox();
            updateTitleBox = new TextBox();
            categoryComboBox = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            bookAdder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pagesBox).BeginInit();
            updateBookPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)updatePagesBox).BeginInit();
            SuspendLayout();
            // 
            // addBook
            // 
            addBook.Location = new Point(150, 70);
            addBook.Name = "addBook";
            addBook.Size = new Size(91, 44);
            addBook.TabIndex = 0;
            addBook.Text = "Add Book";
            addBook.UseVisualStyleBackColor = true;
            addBook.Click += addBook_Click;
            // 
            // bookAdder
            // 
            bookAdder.BackColor = SystemColors.ActiveCaption;
            bookAdder.Controls.Add(pages);
            bookAdder.Controls.Add(author);
            bookAdder.Controls.Add(category);
            bookAdder.Controls.Add(Title);
            bookAdder.Controls.Add(submitBook);
            bookAdder.Controls.Add(pagesBox);
            bookAdder.Controls.Add(categoryBox);
            bookAdder.Controls.Add(authorBox);
            bookAdder.Controls.Add(titleBox);
            bookAdder.Location = new Point(49, 120);
            bookAdder.Name = "bookAdder";
            bookAdder.Size = new Size(300, 250);
            bookAdder.TabIndex = 1;
            bookAdder.Visible = false;
            // 
            // pages
            // 
            pages.AutoSize = true;
            pages.Location = new Point(123, 151);
            pages.Name = "pages";
            pages.Size = new Size(38, 15);
            pages.TabIndex = 7;
            pages.Text = "Pages";
            // 
            // author
            // 
            author.AutoSize = true;
            author.Location = new Point(123, 63);
            author.Name = "author";
            author.Size = new Size(44, 15);
            author.TabIndex = 6;
            author.Text = "Author";
            // 
            // category
            // 
            category.AutoSize = true;
            category.Location = new Point(123, 106);
            category.Name = "category";
            category.Size = new Size(55, 15);
            category.TabIndex = 5;
            category.Text = "Category";
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Location = new Point(123, 15);
            Title.Name = "Title";
            Title.Size = new Size(29, 15);
            Title.TabIndex = 4;
            Title.Text = "Title";
            // 
            // submitBook
            // 
            submitBook.Location = new Point(101, 198);
            submitBook.Name = "submitBook";
            submitBook.Size = new Size(91, 44);
            submitBook.TabIndex = 2;
            submitBook.Text = "Submit";
            submitBook.UseVisualStyleBackColor = true;
            submitBook.Click += submitBook_Click;
            // 
            // pagesBox
            // 
            pagesBox.Location = new Point(101, 169);
            pagesBox.Name = "pagesBox";
            pagesBox.Size = new Size(100, 23);
            pagesBox.TabIndex = 3;
            // 
            // categoryBox
            // 
            categoryBox.Location = new Point(101, 124);
            categoryBox.Name = "categoryBox";
            categoryBox.Size = new Size(100, 23);
            categoryBox.TabIndex = 2;
            // 
            // authorBox
            // 
            authorBox.Location = new Point(101, 81);
            authorBox.Name = "authorBox";
            authorBox.Size = new Size(100, 23);
            authorBox.TabIndex = 1;
            // 
            // titleBox
            // 
            titleBox.Location = new Point(101, 33);
            titleBox.Name = "titleBox";
            titleBox.Size = new Size(100, 23);
            titleBox.TabIndex = 0;
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
            // updateBookPanel
            // 
            updateBookPanel.BackColor = SystemColors.ActiveCaption;
            updateBookPanel.Controls.Add(deleteBookBtn);
            updateBookPanel.Controls.Add(modifyCategory);
            updateBookPanel.Controls.Add(label1);
            updateBookPanel.Controls.Add(label2);
            updateBookPanel.Controls.Add(label3);
            updateBookPanel.Controls.Add(label4);
            updateBookPanel.Controls.Add(saveChanges);
            updateBookPanel.Controls.Add(updatePagesBox);
            updateBookPanel.Controls.Add(updateCatBox);
            updateBookPanel.Controls.Add(updateAuthorBox);
            updateBookPanel.Controls.Add(updateTitleBox);
            updateBookPanel.Location = new Point(432, 120);
            updateBookPanel.Name = "updateBookPanel";
            updateBookPanel.Size = new Size(300, 250);
            updateBookPanel.TabIndex = 8;
            updateBookPanel.Visible = false;
            // 
            // deleteBookBtn
            // 
            deleteBookBtn.Location = new Point(19, 198);
            deleteBookBtn.Name = "deleteBookBtn";
            deleteBookBtn.Size = new Size(91, 44);
            deleteBookBtn.TabIndex = 9;
            deleteBookBtn.Text = "Delete";
            deleteBookBtn.UseVisualStyleBackColor = true;
            deleteBookBtn.Click += deleteBook_Click;
            // 
            // modifyCategory
            // 
            modifyCategory.AutoSize = true;
            modifyCategory.Location = new Point(207, 126);
            modifyCategory.Name = "modifyCategory";
            modifyCategory.Size = new Size(64, 19);
            modifyCategory.TabIndex = 8;
            modifyCategory.Text = "modify";
            modifyCategory.UseVisualStyleBackColor = true;
            modifyCategory.CheckedChanged += modifyCategory_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(123, 151);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 7;
            label1.Text = "Pages";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(123, 63);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 6;
            label2.Text = "Author";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(123, 106);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 5;
            label3.Text = "Category";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(123, 15);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 4;
            label4.Text = "Title";
            // 
            // saveChanges
            // 
            saveChanges.Location = new Point(196, 198);
            saveChanges.Name = "saveChanges";
            saveChanges.Size = new Size(91, 44);
            saveChanges.TabIndex = 2;
            saveChanges.Text = "Save";
            saveChanges.UseVisualStyleBackColor = true;
            saveChanges.Click += saveChanges_Click;
            // 
            // updatePagesBox
            // 
            updatePagesBox.Location = new Point(101, 169);
            updatePagesBox.Name = "updatePagesBox";
            updatePagesBox.Size = new Size(100, 23);
            updatePagesBox.TabIndex = 3;
            // 
            // updateCatBox
            // 
            updateCatBox.Enabled = false;
            updateCatBox.Location = new Point(101, 124);
            updateCatBox.Name = "updateCatBox";
            updateCatBox.Size = new Size(100, 23);
            updateCatBox.TabIndex = 2;
            // 
            // updateAuthorBox
            // 
            updateAuthorBox.Location = new Point(101, 81);
            updateAuthorBox.Name = "updateAuthorBox";
            updateAuthorBox.Size = new Size(100, 23);
            updateAuthorBox.TabIndex = 1;
            // 
            // updateTitleBox
            // 
            updateTitleBox.Location = new Point(101, 33);
            updateTitleBox.Name = "updateTitleBox";
            updateTitleBox.Size = new Size(100, 23);
            updateTitleBox.TabIndex = 0;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(categoryComboBox);
            Controls.Add(updateBookPanel);
            Controls.Add(allBooksComboBox);
            Controls.Add(bookAdder);
            Controls.Add(addBook);
            Name = "Form1";
            Text = "Form1";
            bookAdder.ResumeLayout(false);
            bookAdder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pagesBox).EndInit();
            updateBookPanel.ResumeLayout(false);
            updateBookPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)updatePagesBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addBook;
        private Panel bookAdder;
        private Label pages;
        private Label author;
        private Label category;
        private Label Title;
        private Button submitBook;
        private NumericUpDown pagesBox;
        private TextBox categoryBox;
        private TextBox authorBox;
        private TextBox titleBox;
        private ComboBox allBooksComboBox;
        private Panel updateBookPanel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button saveChanges;
        private NumericUpDown updatePagesBox;
        private TextBox updateCatBox;
        private TextBox updateAuthorBox;
        private TextBox updateTitleBox;
        private CheckBox modifyCategory;
        private Button deleteBookBtn;
        private ComboBox categoryComboBox;
        private Label label5;
        private Label label6;
    }
}
