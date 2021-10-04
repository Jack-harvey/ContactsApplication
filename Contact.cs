using ContactsApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsApplication
{
    public partial class ContactForm : Form
    {
        public ContactForm(Guid ContactGuid)
        {
            InitializeComponent();
            contactGuid = ContactGuid;
        }

        private void Contact_Load(object sender, EventArgs e)
        {
            using (var db = new ContactsApplicationDb())
            {

                
                
                    //var dataCategorySource = (from t in db.Categories
                    //                  select new
                    //                  {
                    //                      t.CategoryDescription,
                    //                      t.CategoryId
                    //                  }).ToList();
                    //lblCategory.DataSource = dataSource;
                    //lbCategory.ValueMember = "CategoryId";
                    //lbCategory.DisplayMember = "CategoryDescription";


                





                var contactCard = db.Cards.Find(contactGuid);
                var contactCardCategoryID = db.Categories.Find(contactCard.CategoryId);
                var birthdayExists = contactCard.Birthday.HasValue;
                if (birthdayExists)
                {
                    lblBirthday.Text = contactCard.Birthday.Value.ToString("dd/MM/yyyy");
                }

                else
                {
                    lblBirthday.Text = "";
                }
                lblName.Text = $"{contactCard.Firstname} {contactCard.Lastname}";
                lblEmail.Text = contactCard.Email;
                lblPhone.Text = contactCard.Mobile;
                lblCompany.Text = contactCard.Company;

                lblCategory.Text = contactCardCategoryID.CategoryDescription;





                if (!string.IsNullOrEmpty(contactCard.Picture))
                {
                    pictureBox1.Image = Image.FromFile(contactCard.Picture);
                }
                txtbNotes.Text = contactCard.Notes;
                
            }
        }

        public Guid contactGuid { get; set; }
    }
}
