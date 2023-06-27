using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITTyping.Models
{
    public class Typist
    {

        // Id will be the primary key in the database
        public int Id { get; set; }

        [StringLength(20)]
        public string? UserName { get; set; }

        [StringLength(20)]
        public string? Password { get; set; }

        [RegularExpression(@"[A-Z]+[a-zA-Z\s]*", ErrorMessage = "The first character must be uppercase, no special characters or numbers.")] 
        [StringLength(15), Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [RegularExpression(@"[A-Z]+[a-zA-Z\s]*", ErrorMessage = "The first character must be uppercase, no special characters or numbers.")]
        [StringLength(20), Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string? TypingPackage { get; set; }

        [Column(TypeName = "decimal(18, 2)"), DataType(DataType.Currency)]
        public decimal PriceDue { get; set; }

        [Display(Name = "Last Purchase Date"), DataType(DataType.Date)]
        public DateTime LastPurchaseDate { get; set; }


    }
}
