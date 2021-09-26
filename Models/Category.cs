using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApplication.Models
{
    public class Category
    {
        [Required(ErrorMessage = "Category ID is Required")]
        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Description is Required")]
        [StringLength(256)]
        public string CategoryDescription { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}
