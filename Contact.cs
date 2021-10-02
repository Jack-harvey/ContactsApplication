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
                var contactCard = db.Cards.Find(contactGuid);
                lblName.Text = $"{contactCard.Firstname} {contactCard.Lastname}";
                lblEmail.Text = contactCard.Email;
                lblPhone.Text = contactCard.Mobile;
                lblCompany.Text = contactCard.Company;
                lblBirthday.Text = contactCard.Birthday.Value.ToString();
                //lblCategory.Text = contactCard.CategoryId.
                txtbNotes.Text = contactCard.Notes;
                pictureBox1.Image = Image.FromFile(contactCard.Picture);
            }
        }

        public Guid contactGuid { get; set; }
    }
}
