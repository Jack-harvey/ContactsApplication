using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ContactsApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

        }
         void displayInformationInDataGridView()
        {

            using (var db = new ContactsApplicationDb())
            {
                var dataSource = (from t in db.Cards.Include(i => i.Category)
                                  orderby t.Firstname, t.Lastname
                                  select new
                                  {
                                      t.ContactId,
                                      t.Firstname,
                                      t.Lastname,
                                      t.Mobile,
                                      t.Email,
                                      Category = t.Category.CategoryDescription
                                  }).ToList();

                dataGridView2.DataSource = dataSource;
                dataGridView2.Columns[0].Visible = false;

            }
               
        }

        void displayInformationInDataGridViewOrderEmail()
        {

            using (var db = new ContactsApplicationDb())
            {
                var dataSource = (from t in db.Cards.Include(i => i.Category)
                                  orderby t.Email
                                  select new
                                  {
                                      t.ContactId,
                                      t.Firstname,
                                      t.Lastname,
                                      t.Mobile,
                                      t.Email,
                                      Category = t.Category.CategoryDescription
                                  }).ToList();

                dataGridView2.DataSource = dataSource;
                dataGridView2.Columns[0].Visible = false;

            }

        }
        void displayInformationInDataGridViewOrderCategory()
        {

            using (var db = new ContactsApplicationDb())
            {
                var dataSource = (from t in db.Cards.Include(i => i.Category)
                                  orderby t.Category.CategoryDescription
                                  select new
                                  {
                                      t.ContactId,
                                      t.Firstname,
                                      t.Lastname,
                                      t.Mobile,
                                      t.Email,
                                      Category = t.Category.CategoryDescription
                                  }).ToList();

                dataGridView2.DataSource = dataSource;
                dataGridView2.Columns[0].Visible = false;

            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // start a new connection to our database
            using (var db = new ContactsApplicationDb())
            {
                // make sure it exits
                //db.Database.EnsureCreated();


                // check if we have any data
                if (!db.Categories.Any())
                {
                    db.Categories.AddRange(new List<Category>()
                    {
                       new Category { CategoryDescription = "Red" },
                       new Category { CategoryDescription = "Blue" },
                       new Category { CategoryDescription = "Green" },
                       new Category { CategoryDescription = "Yellow" }
                    });

                    db.SaveChanges();
                }

                if (db.Cards.Any() == false)
                {
                    // create a bunch of records
                    
                    // add all items in the List of Cards to the Cards table in our database
                    db.Cards.AddRange(new List<Card>()
                    {
                        new Card(){Firstname="jack", Lastname="harvey", Mobile="0123456789", CategoryId = 1},
                        new Card(){Firstname="zorg", Lastname="aarvey", Mobile="0123456789", CategoryId = 2},
                        new Card(){Firstname="zack", Lastname="barvey", Mobile="0123456789", CategoryId = 3},
                        new Card(){Firstname="xack", Lastname="carvey", Mobile="0123456789", CategoryId = 4},
                        new Card(){Firstname="yack", Lastname="darvey", Mobile="0123456789", CategoryId = 2},
                        new Card(){Firstname="wack", Lastname="earvey", Mobile="0123456789", CategoryId = 1}
                    });

                    // persist changes to our database
                    db.SaveChanges();

                }

               

                // eg. of finding a record when the primary key is known 
                //var card = db.Cards.Find("aaa-eee-bb-0");
                // e.g of finding a record when a different property(ies) are known

                var card = db.Cards.FirstOrDefault(f => f.Firstname == "jack");

                // eg of adding a new record
                if(card == null)
                {
                    //db.Add(new Card { Firstname = "jack", Lastname = "harvey", Mobile = "0123456789", CategoryId = 1 });
                    card = new Card { Firstname = "jack", Lastname = "harvey", Mobile = "0123456789", CategoryId = 1 };
                    db.Cards.Add(card);
                    db.Entry(card).State = EntityState.Added;

                    db.SaveChanges();
                }


                // eg of updating a record in db with new values
                //if(card != null)
                //{
                //    card.Firstname = "new name";
                //    //card.Email = "user@dmomain.com";
                //    //..

                //    db.Update(card);

                //    db.SaveChanges();
                //} 

                // eg. of deleting a record from db
                //if(card != null)
                //{

                //    db.Remove(card);
                //    db.SaveChanges();
                //} 

                displayInformationInDataGridView();
            }
        }

        private void btnAddNewContact_Click(object sender, EventArgs e)
        {
            Guid newContactDummyGuid = Guid.Empty;
            Form newContact = new AddContact(newContactDummyGuid);
            newContact.ShowDialog();

            displayInformationInDataGridView();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var editContactGuid = (Guid)dataGridView2.CurrentRow.Cells[0].Value;
            Form newContact = new AddContact(editContactGuid);
            newContact.ShowDialog();

            displayInformationInDataGridView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var firstName = dataGridView2.CurrentRow.Cells[1].Value;
            var lastName = dataGridView2.CurrentRow.Cells[2].Value;
            var messageContent = $"You're about to delete the contact {firstName} {lastName}, this cannot be undone, do you wish to proceed?";

            DialogResult dialogResult = MessageBox.Show(messageContent, "Delete Contact", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var deleteContactGuid = (Guid)dataGridView2.CurrentRow.Cells[0].Value;
                using (var db = new ContactsApplicationDb())
                {
                    var cardToDelete = db.Cards.Find(deleteContactGuid);
                    db.Remove(cardToDelete);
                    db.SaveChanges();
                    displayInformationInDataGridView();
                }

            }
            else if (dialogResult == DialogResult.No)
            {
                displayInformationInDataGridView();
            }
        }
    }
}