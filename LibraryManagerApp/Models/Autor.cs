using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagerApp.Models
{
    public class Autor
    {
        [Key]
        [Column("id_autora")]
        public int IdAutora { get; set; }

        [Required]
        public string Imie {  get; set; }

        [Required]
        public string Nazwisko { get; set; }

        public ICollection<Ksiazka_Autor> KsiazkiAutor {  get; set; }
    }
}
