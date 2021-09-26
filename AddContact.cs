using ContactsApplication.Models;
using Microsoft.EntityFrameworkCore;
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
    public partial class AddContact : Form
    {
        public AddContact()
        {
            InitializeComponent();
        }

        private void AddContact_Load(object sender, EventArgs e)
        {
            using (var db = new ContactsApplicationDb())
            {
                var dataSource = from t in db.Categories
                                 select new
                                 {
                                     t.CategoryDescription,
                                     t.CategoryId
                                 }.ToList;
                lbCategory.DataSource = dataSource;
                lbCategory.ValueMember = "CategoryId";
                lbCategory.DisplayMember = "CategoryDescription";

            }
                

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var db = new ContactsApplicationDb())
            {

                var card = new Card() { Firstname = txtbFirstName.Text, Lastname = txtbLastName.Text, Mobile = txtbPhone.Text, Email = txtbEmail.Text, Company = txtbCompany.Text, Picture = txtbPictureUrl.Text, Notes = txtbNotes.Text, Birthday = dateBirthday.Value, CategoryId =2 /*lbCategory.MAKE SOME MAGIC LIST TO INT CAST*/ };
                db.Cards.Add(card);
                db.Entry(card).State = EntityState.Added;

                db.SaveChanges();


                //try
                //{
                //    var card = new Card() { Firstname = txtbFirstName.Text, Lastname = txtbLastName.Text, Mobile = txtbPhone.Text, Email = txtbEmail.Text, Company = txtbCompany.Text, Picture = txtbPictureUrl.Text, Notes = txtbNotes.Text, Birthday = dateBirthday.Value, };
                //    db.Cards.Add(card);
                //    db.Entry(card).State = EntityState.Added;

                //    db.SaveChanges();
                //}
                //catch (Exception error)
                //{
                //    lblMessage.Text = error.Message;
                //}
            }
        }
    }
}