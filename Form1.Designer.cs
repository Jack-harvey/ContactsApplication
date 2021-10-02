
namespace ContactsApplication
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblNotification = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnAddNewContact = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.radbName = new System.Windows.Forms.RadioButton();
            this.radbEmail = new System.Windows.Forms.RadioButton();
            this.radbCategory = new System.Windows.Forms.RadioButton();
            this.lblSort = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 45);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(719, 328);
            this.dataGridView2.TabIndex = 4;
            this.dataGridView2.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView2_CellContentDoubleClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(337, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 23);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblNotification
            // 
            this.lblNotification.AutoSize = true;
            this.lblNotification.Location = new System.Drawing.Point(12, 485);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(38, 15);
            this.lblNotification.TabIndex = 6;
            this.lblNotification.Text = "label1";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(286, 19);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(45, 15);
            this.lblSearch.TabIndex = 7;
            this.lblSearch.Text = "Search:";
            // 
            // btnAddNewContact
            // 
            this.btnAddNewContact.Location = new System.Drawing.Point(12, 380);
            this.btnAddNewContact.Name = "btnAddNewContact";
            this.btnAddNewContact.Size = new System.Drawing.Size(112, 23);
            this.btnAddNewContact.TabIndex = 8;
            this.btnAddNewContact.Text = "Add Contact";
            this.btnAddNewContact.UseVisualStyleBackColor = true;
            this.btnAddNewContact.Click += new System.EventHandler(this.btnAddNewContact_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(13, 420);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(111, 23);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(757, 474);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // radbName
            // 
            this.radbName.AutoSize = true;
            this.radbName.Location = new System.Drawing.Point(740, 60);
            this.radbName.Name = "radbName";
            this.radbName.Size = new System.Drawing.Size(57, 19);
            this.radbName.TabIndex = 11;
            this.radbName.TabStop = true;
            this.radbName.Text = "Name";
            this.radbName.UseVisualStyleBackColor = true;
            this.radbName.Click += new System.EventHandler(this.radbName_Click);
            // 
            // radbEmail
            // 
            this.radbEmail.AutoSize = true;
            this.radbEmail.Location = new System.Drawing.Point(740, 85);
            this.radbEmail.Name = "radbEmail";
            this.radbEmail.Size = new System.Drawing.Size(54, 19);
            this.radbEmail.TabIndex = 12;
            this.radbEmail.TabStop = true;
            this.radbEmail.Text = "Email";
            this.radbEmail.UseVisualStyleBackColor = true;
            this.radbEmail.Click += new System.EventHandler(this.radbEmail_Click);
            // 
            // radbCategory
            // 
            this.radbCategory.AutoSize = true;
            this.radbCategory.Location = new System.Drawing.Point(740, 110);
            this.radbCategory.Name = "radbCategory";
            this.radbCategory.Size = new System.Drawing.Size(73, 19);
            this.radbCategory.TabIndex = 13;
            this.radbCategory.TabStop = true;
            this.radbCategory.Text = "Category";
            this.radbCategory.UseVisualStyleBackColor = true;
            this.radbCategory.Click += new System.EventHandler(this.radbCategory_Click);
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(740, 42);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(28, 15);
            this.lblSort.TabIndex = 14;
            this.lblSort.Text = "Sort";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 509);
            this.Controls.Add(this.lblSort);
            this.Controls.Add(this.radbCategory);
            this.Controls.Add(this.radbEmail);
            this.Controls.Add(this.radbName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAddNewContact);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblNotification);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblNotification;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnAddNewContact;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.RadioButton radbName;
        private System.Windows.Forms.RadioButton radbEmail;
        private System.Windows.Forms.RadioButton radbCategory;
        private System.Windows.Forms.Label lblSort;
    }
}

