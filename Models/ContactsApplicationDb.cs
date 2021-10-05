using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ContactsApplication.Models
{
    class ContactsApplicationDb : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string connection = ConfigurationManager.ConnectionStrings["databaseConnector"].ConnectionString;
            optionsBuilder.UseSqlServer(connection);
            //optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\JackH\source\repos\ContactsApplication\Data\Contacts.mdf;Integrated Security=True;");



            //base.OnConfiguring(optionsBuilder);
        }
    }
}
