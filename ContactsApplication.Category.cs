using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ContactsApplication
{
    public class Category
    {
        [Required(ErrorMessage = "Category ID is Required")]
        [StringLength(50)]
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Description is Required")]
        [StringLength(256)]
        public string CategoryDescription { get; set; }

        public virtual ICollection<Card> Cards { get; set; }

    }
}
