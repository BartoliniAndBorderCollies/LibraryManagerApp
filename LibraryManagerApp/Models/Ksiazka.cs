using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagerApp.Models
{
    public class Ksiazka
    {
        [Key]
        public int IdKsiazki { get; set; }

        [Required]
        public string Tytul {  get; set; }

        [Column("rok_wydania")]
        public int RokWydania { get; set; }

        [Required]
        public string ISBN {  get; set; }

        public int LiczbaStron {  get; set; }

        public bool Dostepna { get; set; }

        [ForeignKey("Kategoria")]
        [Column("id_kategorii")]
        public int IdKategorii { get; set; }

        //nawigacyjne właściwości dla EF Core
        public Kategoria Kategoria { get; set; }

        //historia wypozyczen
        public ICollection<Wypozyczenie> listaWypozyczen { get; set; }
    }
}
