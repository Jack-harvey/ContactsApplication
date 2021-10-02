
namespace ContactsApplication
{
    partial class ContactForm
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
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblBirthday = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtbNotes = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblAddLastName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(12, 214);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(53, 15);
            this.lblCategory.TabIndex = 37;
            this.lblCategory.Text = "category";
            // 
            // lblBirthday
            // 
            this.lblBirthday.AutoSize = true;
            this.lblBirthday.Location = new System.Drawing.Point(12, 186);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(51, 15);
            this.lblBirthday.TabIndex = 36;
            this.lblBirthday.Text = "birthday";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(12, 273);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 15);
            this.lblNotes.TabIndex = 35;
            this.lblNotes.Text = "Notes";
            // 
            // txtbNotes
            // 
            this.txtbNotes.Location = new System.Drawing.Point(12, 291);
            this.txtbNotes.Multiline = true;
            this.txtbNotes.Name = "txtbNotes";
            this.txtbNotes.ReadOnly = true;
            this.txtbNotes.Size = new System.Drawing.Size(509, 147);
            this.txtbNotes.TabIndex = 31;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(12, 157);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(57, 15);
            this.lblCompany.TabIndex = 29;
            this.lblCompany.Text = "company";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(12, 128);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(36, 15);
            this.lblEmail.TabIndex = 27;
            this.lblEmail.Text = "email";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(12, 99);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(41, 15);
            this.lblPhone.TabIndex = 25;
            this.lblPhone.Text = "phone";
            // 
            // lblAddLastName
            // 
            this.lblAddLastName.AutoSize = true;
            this.lblAddLastName.Location = new System.Drawing.Point(12, 37);
            this.lblAddLastName.Name = "lblAddLastName";
            this.lblAddLastName.Size = new System.Drawing.Size(0, 15);
            this.lblAddLastName.TabIndex = 23;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(37, 15);
            this.lblName.TabIndex = 21;
            this.lblName.Text = "name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(248, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(273, 276);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // ContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblBirthday);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtbNotes);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblAddLastName);
            this.Controls.Add(this.lblName);
            this.Name = "ContactForm";
            this.Text = "Contact";
            this.Load += new System.EventHandler(this.Contact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblBirthday;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtbNotes;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblAddLastName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}