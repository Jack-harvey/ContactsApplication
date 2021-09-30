using System;
using System.ComponentModel.DataAnnotations;

namespace ContactsApplication.Models
{
    public class Card
    {
        public Card()
        {
            ContactId = Guid.NewGuid();
        }

        [Required(ErrorMessage = "Guid is Required")]
        [Key]
        public Guid ContactId { get; set; }

        [Required(ErrorMessage = "a First Name is Required")]
        [StringLength(50)]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "a Last Name is Required")]
        [StringLength(50)]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Mobile is Required")]
        [StringLength(15, MinimumLength = 10)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        //[Required(ErrorMessage = "Email ID is Required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(75)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Birthday { get; set; }

        [StringLength(255)]
        public string Picture { get; set; }
        [StringLength(300)]
        public string Notes { get; set; }

        //[Required(ErrorMessage = "CategoryId is Required")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}
