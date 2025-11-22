using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagerApp.Models
{
    public class Kategoria
    {
        [Key]
        [Column("id_kategorii")]
        public int IdKategorii { get; set; }

        [Required]
        public string Nazwa {  get; set; }

        //nawigacyjna wlasciwosc
        public ICollection<Ksiazka> listaKsiazek { get; set; }
        
    }
}
