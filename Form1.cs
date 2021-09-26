using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using CsvHelper;
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
                

            }
        }

        private void btnAddNewContact_Click(object sender, EventArgs e)
        {
            Form newContact = new AddContact();
            newContact.ShowDialog();
        }
    }
}