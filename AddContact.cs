using ContactsApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ContactsApplication
{
    public partial class AddContact : Form
    {
        private DateTimePickerFormat originalDatePickerFormat = DateTimePickerFormat.Short;
        private string originalCustomFormat = "";
        private bool bdayHasVal = false;
        public AddContact(Guid EditingGuid)
        {
            InitializeComponent();
            originalDatePickerFormat = dateBirthday.Format;
            editingGuid = EditingGuid;
            if (editingGuid != Guid.Empty)
            {
                this.Text = "Edit contact";
            }
            else
            {
                this.Text = "New contact";
            }
        }

        // METHODS
        void pictureUrlFileSave()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files| *.jpg; *.jpeg; *.png; *.gif; *.tif; ...";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var sourcePicName = openFileDialog.FileName;
                    contactPicturePath = @"C:\Users\JackH\source\repos\ContactsApplication\ContactsApplication\ContactPictures\" + Path.GetFileName(sourcePicName);
                    File.Copy(sourcePicName, contactPicturePath);
                }
            }
        }

        void pictureUrlEditSaveEdit()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                var confirmDeletionOfImage = MessageBox.Show("If you proceed the current contact image will be really really deleted", "Deletion Confirmation", MessageBoxButtons.YesNo);
                if (confirmDeletionOfImage == DialogResult.Yes)
                {
                    using (var db = new ContactsApplicationDb())
                    {
                        var editCard = db.Cards.Find(editingGuid);
                        var pictureUrlToDelete = editCard.Picture;

                        if (!string.IsNullOrEmpty(pictureUrlToDelete))
                        {
                            pictureBox1.Image.Dispose();
                        }
                        //File.Delete(pictureUrlToDelete);


                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Filter = "Image Files| *.jpg; *.jpeg; *.png; *.gif; *.tif; ...";
                        openFileDialog.FilterIndex = 2;
                        openFileDialog.RestoreDirectory = true;
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            var sourcePicName = openFileDialog.FileName;
                            //var sourcePicName = $"{editCard.Firstname}{editCard.Lastname}";
                            //WHILE LOOP FILE EXISTS? ++(i)
                            contactPicturePath = @"C:\Users\JackH\source\repos\ContactsApplication\ContactsApplication\ContactPictures\" + Path.GetFileName(sourcePicName);
                            //contactPicturePath = Path.Join(Application.StartupPath, @"ContactsApplication\ContactPictures", Path.GetFileName(sourcePicName));
                            File.Copy(sourcePicName, contactPicturePath);
                            File.Delete(pictureUrlToDelete);
                        }
                    }
                }
                else
                {
                    // I don't think I'll need anything here?
                }
            }
        }

        void PictureUrlBoxBtn()
        {
            using (var db = new ContactsApplicationDb())
            {
                var editCard = db.Cards.Find(editingGuid);

                if (editingGuid == Guid.Empty)
                {
                    pictureUrlFileSave();
                }

                else if (string.IsNullOrEmpty(editCard.Picture))
                {
                    pictureUrlFileSave();
                }

                else
                {
                    pictureUrlEditSaveEdit();
                }















                //var editCard = db.Cards.Find(editingGuid);
                //string editCardUrl = editCard.Picture;
                //if (editingGuid != Guid.Empty || !string.IsNullOrEmpty(editCard.Picture))
                //{
                //    pictureUrlEditSaveEdit();
                //}

                //else
                //{
                //    pictureUrlFileSave();
                //}
                
            }
        }

        // NOT METHODS?

        private void AddContact_Load(object sender, EventArgs e)
        {

            using (var db = new ContactsApplicationDb())
            {
                var dataSource = (from t in db.Categories
                                  select new
                                  {
                                      t.CategoryDescription,
                                      t.CategoryId
                                  }).ToList();
                lbCategory.DataSource = dataSource;
                lbCategory.ValueMember = "CategoryId";
                lbCategory.DisplayMember = "CategoryDescription";


            }

            if (editingGuid != Guid.Empty)
            {
                
                using (var db = new ContactsApplicationDb())
                {
                    var editCard = db.Cards.Find(editingGuid);
                    lblMessage.Text = $"You're now editing a contact";
                    
                    txtbFirstName.Text = editCard.Firstname;
                    txtbLastName.Text = editCard.Lastname;
                    txtbPhone.Text = editCard.Mobile;
                    txtbEmail.Text = editCard.Email;
                    txtbCompany.Text = editCard.Company;
                    if (!string.IsNullOrEmpty(editCard.Picture))
                    {
                        pictureBox1.Image = Image.FromFile(editCard.Picture);
                    }

                    txtbNotes.Text = editCard.Notes;

                    if (editCard.Birthday.HasValue)
                    {
                        dateBirthday.Format = originalDatePickerFormat;
                        dateBirthday.CustomFormat = originalCustomFormat;

                        dateBirthday.Value = editCard.Birthday.Value;
                        bdayHasVal = true;
                    }
                    else
                    {
                        originalCustomFormat = dateBirthday.CustomFormat;
                        dateBirthday.Format = DateTimePickerFormat.Custom;
                        dateBirthday.CustomFormat = " ";
                        bdayHasVal = false;
                    }

                    lbCategory.SelectedItem = editCard.CategoryId;
                    //the above does not "select" a category, just displays a name


                    //selectElement('leaveCode', '11')

                    //function selectElement(id, valueToSelect)
                    //{
                    //    let element = document.getElementById(id);
                    //    element.value = valueToSelect;
                    //}



                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var db = new ContactsApplicationDb())
            {

                if (editingGuid != Guid.Empty)
                {
                    var selectedCategoryId = lbCategory.SelectedIndex > -1 ? (int)lbCategory.SelectedValue : 0;
                    var editCard = db.Cards.Find(editingGuid);

                    editCard.Firstname = txtbFirstName.Text;
                    editCard.Lastname = txtbLastName.Text;
                    editCard.Mobile = txtbPhone.Text;
                    editCard.Email = txtbEmail.Text;
                    editCard.Company = txtbCompany.Text;
                    editCard.Picture = contactPicturePath;
                    editCard.Notes = txtbNotes.Text;
                    editCard.Birthday = dateBirthday.Value;
                    editCard.CategoryId = selectedCategoryId;



                    db.Update(editCard);
                    db.Entry(editCard).State = EntityState.Modified;
                }

                else
                {
                    var selectedCategoryId = lbCategory.SelectedIndex > -1 ? (int)lbCategory.SelectedValue : 0;
                    //var selval2 = int.TryParse(lbCategory.SelectedValue.ToString(), out int val) ? val : 0;

                    var newCard = new Card()
                    {
                        Firstname = txtbFirstName.Text,
                        Lastname = txtbLastName.Text,
                        Mobile = txtbPhone.Text,
                        Email = txtbEmail.Text,
                        Company = txtbCompany.Text,
                        Picture = contactPicturePath,
                        Notes = txtbNotes.Text,
                        Birthday = bdayHasVal ? dateBirthday.Value : null,
                        CategoryId = selectedCategoryId
                    };
                    editingGuid = newCard.ContactId;
                    db.Cards.Add(newCard);
                    db.Entry(newCard).State = EntityState.Added;
                }
                db.SaveChanges();
                lblMessage.Text = "You've saved a new contact. Now you're editing that contact.";
                
            }
        }
        private void dateBirthday_VisibleChanged(object sender, EventArgs e)
        {
            dateBirthday.Format = originalDatePickerFormat;
            dateBirthday.CustomFormat = originalCustomFormat;
            bdayHasVal = true;
        }



        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            PictureUrlBoxBtn();
        }

        private void btnLoadPicture_Click(object sender, EventArgs e)
        {
            PictureUrlBoxBtn();
        }

        // FIELDS
        public string contactPicturePath { get; set; }
        public Guid editingGuid { get; set; }
    }
}