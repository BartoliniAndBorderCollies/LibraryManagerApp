using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagerApp.Models
{
    public class Reader
    {
        [Key]
        [Column("id_czytelnika")]
        public int ReaderId { get; set; }

        [Required]
        [Column("imie")]
        public string FirstName { get; set; }

        [Required]
        [Column("nazwisko")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [Column("telefon")]
        public string? Telephone { get; set; }

        [DataType(DataType.Date)]
        [Column("data_rejestracji")]
        public DateTime RegistrationDate { get; set; }

        [Column("aktywny")]
        public bool Active { get; set; }

        //nawigacyjna właściwość dla EF Core
        public ICollection<Rental> RentalList { get; set; }
    }
}
