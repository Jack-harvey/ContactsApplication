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
            var data = from t in GetData(textBox1.Text, false)
                       orderby t.Email
                       select t;
            dataGridView2.DataSource = data;
            dataGridView2.Columns[0].Visible = false;
        }
        void displayInformationInDataGridViewOrderCategory()
        {

            var data = from t in GetData(textBox1.Text, false)
                       orderby t.Category
                       select t;
            dataGridView2.DataSource = data;
            dataGridView2.Columns[0].Visible = false;
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
                if (card == null)
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

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedEntry = (Guid)dataGridView2.CurrentRow.Cells[0].Value;
            Form ContactForm = new ContactForm(selectedEntry);
            ContactForm.ShowDialog();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {


            //using (var db = new ContactsApplicationDb())
            //{
            //    var dataSource = (from t in db.Cards.Include(i => i.Category)
            //                      orderby t.Firstname, t.Lastname
            //                      select new
            //                      {
            //                          t.ContactId,
            //                          t.Firstname,
            //                          t.Lastname,
            //                          t.Mobile,
            //                          t.Email,
            //                          Category = t.Category.CategoryDescription
            //                      }).ToList();

            //    dataGridView2.DataSource = dataSource;
            //    dataGridView2.Columns[0].Visible = false;
            //var searchFor = textBox1.Text;

            //using (var db = new ContactsApplicationDb())
            //{
            //    var dataSource = (from t in db.Cards.Include(i => i.Category)
            //                      where t.Firstname.Contains(searchFor) ||
            //                        t.Lastname.Contains(searchFor) ||
            //                        t.Mobile.Contains(searchFor) ||
            //                        t.Email.Contains(searchFor) ||
            //                        t.Category.CategoryDescription.Contains(searchFor)
            //                      orderby t.Firstname, t.Lastname

            //                      select new
            //                      {
            //                          t.ContactId,
            //                          t.Firstname,
            //                          t.Lastname,
            //                          t.Mobile,
            //                          t.Email,
            //                          Category = t.Category.CategoryDescription
            //                      }).ToList();

                



            var data = GetData(textBox1.Text, false);

            //}
            dataGridView2.DataSource = data;
            dataGridView2.Columns[0].Visible = false;

            //for (int i = 1; i < dataGridView2.Columns.Count; i++)
            //{
            //    dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            //}

            //string searchForText = "jack";

            //    DataGridViewRow rowFound = dataGridView2.Rows.OfType<DataGridViewRow>().FirstOrDefault(row => row.Cells.OfType<DataGridViewCell>().Any(cell => ((dynamic)cell.Value).StringID.Contains(searchForText)));
            //    //DataGridViewRow rowFound = dataGridView2.Rows.OfType<DataGridViewRow>().FirstOrDefault(row => row.Cells.OfType<DataGridViewCell>().Select(

            //if (rowFound != null)
            //    {
            //        dataGridView2.Rows[rowFound.Index].Selected = true;
            //        dataGridView2.FirstDisplayedScrollingRowIndex = rowFound.Index;
            //    }
            //}


        }

        private string sortDir = "A";

        private void dataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            

            var dataSource = GetData(textBox1.Text, true);

            
            
            dataGridView2.DataSource = dataSource;
            dataGridView2.Columns[0].Visible = false;
        }

        private List<CardSearchView> OrderData(IQueryable<CardSearchView> data, bool updateSortDir)
        {
            var col = dataGridView2.CurrentCell.OwningColumn;

            if (col.Index == 1)
            {
                if (sortDir == "A")
                {
                    data = data.OrderBy(o => o.Firstname);//.ThenBy(o => o.Category);
                }
                else
                {
                    data = data.OrderByDescending(o => o.Firstname);
                }
            }

            if (col.Index == 2)
            {
                if (sortDir == "A")
                {
                    data = data.OrderBy(o => o.Lastname);
                }
                else
                {
                    data = data.OrderByDescending(o => o.Lastname);
                }
            }

            if (col.Index == 3)
            {
                if (sortDir == "A")
                {
                    data = data.OrderBy(o => o.Mobile);
                }
                else
                {
                    data = data.OrderByDescending(o => o.Mobile);
                }
            }

            if (col.Index == 4)
            {
                if (sortDir == "A")
                {
                    data = data.OrderBy(o => o.Email);
                }
                else
                {
                    data = data.OrderByDescending(o => o.Email);
                }
            }

            if (col.Index == 5)
            {
                if (sortDir == "A")
                {
                    data = data.OrderBy(o => o.Category);
                }
                else
                {
                    data = data.OrderByDescending(o => o.Category);
                }
            }

            if (updateSortDir) 
                sortDir = sortDir == "A" ? "B" : "A";


            return data.ToList();
        }

        private List<CardSearchView> GetData(string searchFor, bool updateSorDir)
        {
            IQueryable<CardSearchView> data = null;

            using (var db = new ContactsApplicationDb())
            {
                data = (from t in db.Cards.Include(i => i.Category)
                                  where t.Firstname.Contains(searchFor) ||
                                    t.Lastname.Contains(searchFor) ||
                                    t.Mobile.Contains(searchFor) ||
                                    t.Email.Contains(searchFor) ||
                                    t.Category.CategoryDescription.Contains(searchFor)
                                  //orderby t.Firstname, t.Lastname
                                  
                                  select new CardSearchView
                                  {
                                      ContactId = t.ContactId,
                                      Firstname = t.Firstname,
                                      Lastname = t.Lastname,
                                      Mobile = t.Mobile,
                                      Email = t.Email,
                                      //FavouriteColour = "Blue",
                                      Category = t.Category.CategoryDescription
                                  });

                return OrderData(data, updateSorDir);
            }

        }
    }
}