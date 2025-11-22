using System.ComponentModel.DataAnnotations;

namespace LibraryManagerApp.Models
{
    public class Czytelnik
    {
        [Key]
        public int IdCzytelnika { get; set; }

        [Required]
        public string Imie { get; set; }

        [Required]
        public string Nazwisko { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string? Telefon { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataRejestracji { get; set; }

        public bool Aktywny { get; set; }

        //nawigacyjna właściwość dla EF Core
        public ICollection<Wypozyczenie> listaWypozyczen { get; set; }
    }
}
